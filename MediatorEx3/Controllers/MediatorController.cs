using MediatorEx3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MediatorEx3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediatorController : ControllerBase
    {
        private readonly MonitoringContext _context;

        public MediatorController(MonitoringContext context)
        {
            _context = context;
        }

        //POST api/<MediatorController>
        [HttpPost]
        public async Task<ActionResult> PostOrder([FromBody] Orders orderObj)
        {
            // Stack trace
            System.Diagnostics.StackTrace t = new System.Diagnostics.StackTrace();
            string stackTrace = t.ToString();


            var head = _context.HeadLogs.Count(a => a.Guid == orderObj.Header.Id);
            if (head == 0)
            {
                // Order object reaches mediator for the first time and has not been created in the HEAD_Log Table

                // Create HEAD Log object for insertion
                HeadLog headLog = new HeadLog
                {
                    OrderId = orderObj.Header.OrderId,
                    Guid = orderObj.Header.Id,
                    OrderType = orderObj.Header.OrderType,
                    OrderStatus = "Submitted"
                };
                //_context.HeadLogs.Add(headLog);
                //await _context.SaveChangesAsync();
                if (!InsertHead(headLog))
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }

                // Mediator logic, based on order's type
                if (orderObj.Header.OrderType == "New")
                {
                    var detailList = _context.DetailLogs.Where(a => a.Guid == orderObj.Header.Id).ToList();
                    if (detailList.Count == 0)
                    {
                        // Order object reaches mediator for the first time and has not been created in the DETAIL_Log Table

                        // Generate new request based on step calculation
                        var nextStep = _context.Steps.Where(a => a.OrderType == orderObj.Header.OrderType && a.StepId == 1);
                        // OP: How will the mediator hold the request format for each step?
                        //      -> Read from file template?
                        //      -> Read from DB template?
                        //      -> Enormous if-else ?

                        // Generate request for first call invocation
                        WebRequest request = WebRequest.Create("http://localhost:59526/api/Mediator");

                        // Create DETAIL_Log object for insertion 
                        DetailLog detailLog = new DetailLog
                        {
                            Guid = orderObj.Header.Id,
                            Uuid = Guid.NewGuid().ToString(),
                            OrderType = orderObj.Header.OrderType,
                            Payload = JsonSerializer.Serialize(orderObj),
                            Service = "",
                            EndSystem = "SAP IS-U",
                            Exception = String.Empty,
                            State = "Pending"
                        };
                        //_context.DetailLogs.Add(detailLog);
                        //await _context.SaveChangesAsync();
                        if (!InsertDetail(detailLog))
                        {
                            return StatusCode(StatusCodes.Status503ServiceUnavailable);
                        }

                        


                        // Invoke the publisher method to write the message on the queue
                        if (!QueuePublish(JsonSerializer.Serialize(orderObj)))
                        {
                            return StatusCode(StatusCodes.Status503ServiceUnavailable);
                        }
                        else
                        {
                            return StatusCode(StatusCodes.Status200OK);
                        }
                    }
                    else
                    {
                        // Order has reached mediator in a previous step and must proceed with the provisioning flow

                        // Find the record in DETAIL_Log table and mark it as Completed
                        foreach (DetailLog log in detailList)
                        {
                            if (log.State != "Completed")
                            {
                                DetailLog updatedLog = log;
                                updatedLog.State = "Completed";
                                //_context.DetailLogs.Add(updatedLog);
                                //await _context.SaveChangesAsync();
                                Boolean updated = InsertDetail(updatedLog);
                                break;
                            }
                        }

                        // Generate new request based on step calculation
                        var stepsList = _context.Steps.Where(a => a.OrderType == orderObj.Header.OrderType).ToList();
                        //foreach (Step step in stepsList)
                        //{
                        //    if (step.StepDescription == )
                        //    {

                        //    }
                        //}
                        // Generate new Request for next WS call


                    }
                }
                else if (orderObj.Header.OrderType == "Update")
                {

                }
                else if (orderObj.Header.OrderType == "Terminate")
                {

                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Invalid Order Type");
                }
            }
            else
            {
                // Order has reached mediator in a previous step and must proceed with the provisioning flow


            }

            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<MediatorController>/5
        [HttpPut]
        [Route("HEAD/Insert")]
        public IActionResult InsertHead()
        {
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPut]
        [Route("HEAD/Update")]
        public IActionResult UpdateHead()
        {
            return StatusCode(StatusCodes.Status201Created);
        }

        public Boolean InsertHead(HeadLog headObj)
        {
            // POST JSON Object
            string jsonRequest = JsonSerializer.Serialize(headObj);
            var url = "https://localhost:44305/weatherforecast";
            var HttpRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpRequest.Method = "POST";
            HttpRequest.ContentType = "application/json";
            using (var streamWriter = new StreamWriter(HttpRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonRequest);
            }

            var HttpResponse = (HttpWebResponse)HttpRequest.GetResponse();
            using (var streamReader = new StreamReader(HttpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                if (result != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Boolean UpdateHead(HeadLog headObj)
        {
            // PUT JSON Object
            string jsonRequest = JsonSerializer.Serialize(headObj);
            var url = "https://localhost:44305/weatherforecast";
            var HttpRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpRequest.Method = "PUT";
            HttpRequest.ContentType = "application/json";
            using (var streamWriter = new StreamWriter(HttpRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonRequest);
            }

            var HttpResponse = (HttpWebResponse)HttpRequest.GetResponse();
            using (var streamReader = new StreamReader(HttpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                if (result != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Boolean InsertDetail(DetailLog detailObj)
        {
            // POST JSON Object
            string jsonRequest = JsonSerializer.Serialize(detailObj);
            var url = "https://localhost:44305/weatherforecast";
            var HttpRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpRequest.Method = "POST";
            HttpRequest.ContentType = "application/json";
            using (var streamWriter = new StreamWriter(HttpRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonRequest);
            }

            var HttpResponse = (HttpWebResponse)HttpRequest.GetResponse();
            using (var streamReader = new StreamReader(HttpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                if (result != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Boolean QueuePublish(string message)
        {
            var url = "https://localhost:44352/weatherforecast";
            var HttpRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpRequest.Method = "POST";
            HttpRequest.ContentType = "application/json";
            using (var streamWriter = new StreamWriter(HttpRequest.GetRequestStream()))
            {
                streamWriter.Write(message);
            }

            var HttpResponse = (HttpWebResponse)HttpRequest.GetResponse();
            using (var streamReader = new StreamReader(HttpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                if (result != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
