//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference1
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:sap-com:document:sap:soap:functions:mc-style", ConfigurationName="ServiceReference1.ZWAPP_GET_POD_FINANCIAL_DATA")]
    public interface ZWAPP_GET_POD_FINANCIAL_DATA
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ServiceReference1.ZWappGetPodFinancialDataResponse1> ZWappGetPodFinancialDataAsync(ServiceReference1.ZWappGetPodFinancialDataRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class ZWappGetPodFinancialData
    {
        
        private string podField;
        
        private string sourceField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string Pod
        {
            get
            {
                return this.podField;
            }
            set
            {
                this.podField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string Source
        {
            get
            {
                return this.sourceField;
            }
            set
            {
                this.sourceField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class ZwappPodFinDataDetail
    {
        
        private string contractAccountField;
        
        private string contractTypeField;
        
        private string legacyKeyField;
        
        private string bstatusField;
        
        private decimal totalOpenItemsField;
        
        private decimal settledAmountField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string ContractAccount
        {
            get
            {
                return this.contractAccountField;
            }
            set
            {
                this.contractAccountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string ContractType
        {
            get
            {
                return this.contractTypeField;
            }
            set
            {
                this.contractTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string LegacyKey
        {
            get
            {
                return this.legacyKeyField;
            }
            set
            {
                this.legacyKeyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string Bstatus
        {
            get
            {
                return this.bstatusField;
            }
            set
            {
                this.bstatusField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public decimal TotalOpenItems
        {
            get
            {
                return this.totalOpenItemsField;
            }
            set
            {
                this.totalOpenItemsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public decimal SettledAmount
        {
            get
            {
                return this.settledAmountField;
            }
            set
            {
                this.settledAmountField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class ZwappPodFinancialData
    {
        
        private ZwappPodFinDataDetail[] detailsField;
        
        private decimal totalDebtAmountField;
        
        private decimal totalSettledAmountField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public ZwappPodFinDataDetail[] Details
        {
            get
            {
                return this.detailsField;
            }
            set
            {
                this.detailsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public decimal TotalDebtAmount
        {
            get
            {
                return this.totalDebtAmountField;
            }
            set
            {
                this.totalDebtAmountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public decimal TotalSettledAmount
        {
            get
            {
                return this.totalSettledAmountField;
            }
            set
            {
                this.totalSettledAmountField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class ZWappGetPodFinancialDataResponse
    {
        
        private ZwappPodFinancialData podFinancialDataField;
        
        private string resultCodeField;
        
        private string resultMessageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public ZwappPodFinancialData PodFinancialData
        {
            get
            {
                return this.podFinancialDataField;
            }
            set
            {
                this.podFinancialDataField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string ResultCode
        {
            get
            {
                return this.resultCodeField;
            }
            set
            {
                this.resultCodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string ResultMessage
        {
            get
            {
                return this.resultMessageField;
            }
            set
            {
                this.resultMessageField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ZWappGetPodFinancialDataRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:sap-com:document:sap:soap:functions:mc-style", Order=0)]
        public ServiceReference1.ZWappGetPodFinancialData ZWappGetPodFinancialData;
        
        public ZWappGetPodFinancialDataRequest()
        {
        }
        
        public ZWappGetPodFinancialDataRequest(ServiceReference1.ZWappGetPodFinancialData ZWappGetPodFinancialData)
        {
            this.ZWappGetPodFinancialData = ZWappGetPodFinancialData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ZWappGetPodFinancialDataResponse1
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:sap-com:document:sap:soap:functions:mc-style", Order=0)]
        public ServiceReference1.ZWappGetPodFinancialDataResponse ZWappGetPodFinancialDataResponse;
        
        public ZWappGetPodFinancialDataResponse1()
        {
        }
        
        public ZWappGetPodFinancialDataResponse1(ServiceReference1.ZWappGetPodFinancialDataResponse ZWappGetPodFinancialDataResponse)
        {
            this.ZWappGetPodFinancialDataResponse = ZWappGetPodFinancialDataResponse;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public interface ZWAPP_GET_POD_FINANCIAL_DATAChannel : ServiceReference1.ZWAPP_GET_POD_FINANCIAL_DATA, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public partial class ZWAPP_GET_POD_FINANCIAL_DATAClient : System.ServiceModel.ClientBase<ServiceReference1.ZWAPP_GET_POD_FINANCIAL_DATA>, ServiceReference1.ZWAPP_GET_POD_FINANCIAL_DATA
    {
        
        public ZWAPP_GET_POD_FINANCIAL_DATAClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference1.ZWappGetPodFinancialDataResponse1> ServiceReference1.ZWAPP_GET_POD_FINANCIAL_DATA.ZWappGetPodFinancialDataAsync(ServiceReference1.ZWappGetPodFinancialDataRequest request)
        {
            return base.Channel.ZWappGetPodFinancialDataAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.ZWappGetPodFinancialDataResponse1> ZWappGetPodFinancialDataAsync(ServiceReference1.ZWappGetPodFinancialData ZWappGetPodFinancialData)
        {
            ServiceReference1.ZWappGetPodFinancialDataRequest inValue = new ServiceReference1.ZWappGetPodFinancialDataRequest();
            inValue.ZWappGetPodFinancialData = ZWappGetPodFinancialData;
            return ((ServiceReference1.ZWAPP_GET_POD_FINANCIAL_DATA)(this)).ZWappGetPodFinancialDataAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
    }
}
