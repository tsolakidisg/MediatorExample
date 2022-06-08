using MediatorExample.Models;
using NLog;
using System;
using System.Collections.Generic;

namespace MediatorExample.Controllers
{
    public static class Logger
    {
        public static void InsertHead(HeadLog headLog)
        {
            var loggerH = LogManager.GetLogger("Head_Table");

            LogEventInfo headLogEvent = new LogEventInfo(LogLevel.Info, "Head_Table", "");
            headLogEvent.Properties.Add("GUID", headLog.Guid);
            headLogEvent.Properties.Add("OrderType", headLog.OrderType);
            headLogEvent.Properties.Add("OrderStatus", headLog.OrderStatus);

            loggerH.Info(headLogEvent);
        }

        public static void InsertDetail(DetailLog detailLog)
        {
            var loggerD = LogManager.GetLogger("Details_Table");

            if (detailLog.State == "Error")
            {
                LogEventInfo detailsLogEvent = new LogEventInfo(LogLevel.Error, "Details_Table", null, "", null, new Exception(detailLog.Exception));
                detailsLogEvent.Properties.Add("GUID", detailLog.Guid);
                detailsLogEvent.Properties.Add("OrderType", detailLog.OrderType);
                detailsLogEvent.Properties.Add("UUID", detailLog.Uuid);
                detailsLogEvent.Properties.Add("Service", detailLog.Service);
                detailsLogEvent.Properties.Add("EndSystem", detailLog.EndSystem);
                detailsLogEvent.Properties.Add("State", detailLog.State);
                detailsLogEvent.Properties.Add("Payload", "");
                loggerD.Log(detailsLogEvent);
            }
            else
            {
                LogEventInfo detailsLogEvent = new LogEventInfo(LogLevel.Info, "Details_Table", "");
                detailsLogEvent.Properties.Add("GUID", detailLog.Guid);
                detailsLogEvent.Properties.Add("OrderType", detailLog.OrderType);
                detailsLogEvent.Properties.Add("UUID", detailLog.Uuid);
                detailsLogEvent.Properties.Add("Service", detailLog.Service);
                detailsLogEvent.Properties.Add("EndSystem", detailLog.EndSystem);
                detailsLogEvent.Properties.Add("State", detailLog.State);
                detailsLogEvent.Properties.Add("Payload", detailLog.Payload);
                loggerD.Info(detailsLogEvent);
            }
        }
    }
}