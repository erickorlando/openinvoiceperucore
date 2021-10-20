﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsultasSunat
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://service.sunat.gob.pe", ConfigurationName="ConsultasSunat.billService")]
    public interface billService
    {
        
        // CODEGEN: Parameter 'statusCdr' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'Microsoft.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="urn:getStatusCdr", ReplyAction="http://service.sunat.gob.pe/billService/getStatusCdrResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="statusCdr")]
        ConsultasSunat.getStatusCdrResponse getStatusCdr(ConsultasSunat.getStatusCdrRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:getStatusCdr", ReplyAction="http://service.sunat.gob.pe/billService/getStatusCdrResponse")]
        System.Threading.Tasks.Task<ConsultasSunat.getStatusCdrResponse> getStatusCdrAsync(ConsultasSunat.getStatusCdrRequest request);
        
        // CODEGEN: Parameter 'status' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'Microsoft.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="urn:getStatus", ReplyAction="http://service.sunat.gob.pe/billService/getStatusResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="status")]
        ConsultasSunat.getStatusResponse getStatus(ConsultasSunat.getStatusRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:getStatus", ReplyAction="http://service.sunat.gob.pe/billService/getStatusResponse")]
        System.Threading.Tasks.Task<ConsultasSunat.getStatusResponse> getStatusAsync(ConsultasSunat.getStatusRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://service.sunat.gob.pe")]
    public partial class statusResponse
    {
        
        private byte[] contentField;
        
        private string statusCodeField;
        
        private string statusMessageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary", Order=0)]
        public byte[] content
        {
            get
            {
                return this.contentField;
            }
            set
            {
                this.contentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string statusCode
        {
            get
            {
                return this.statusCodeField;
            }
            set
            {
                this.statusCodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string statusMessage
        {
            get
            {
                return this.statusMessageField;
            }
            set
            {
                this.statusMessageField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getStatusCdr", WrapperNamespace="http://service.sunat.gob.pe", IsWrapped=true)]
    public partial class getStatusCdrRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string rucComprobante;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string tipoComprobante;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string serieComprobante;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=3)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int numeroComprobante;
        
        public getStatusCdrRequest()
        {
        }
        
        public getStatusCdrRequest(string rucComprobante, string tipoComprobante, string serieComprobante, int numeroComprobante)
        {
            this.rucComprobante = rucComprobante;
            this.tipoComprobante = tipoComprobante;
            this.serieComprobante = serieComprobante;
            this.numeroComprobante = numeroComprobante;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getStatusCdrResponse", WrapperNamespace="http://service.sunat.gob.pe", IsWrapped=true)]
    public partial class getStatusCdrResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ConsultasSunat.statusResponse statusCdr;
        
        public getStatusCdrResponse()
        {
        }
        
        public getStatusCdrResponse(ConsultasSunat.statusResponse statusCdr)
        {
            this.statusCdr = statusCdr;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getStatus", WrapperNamespace="http://service.sunat.gob.pe", IsWrapped=true)]
    public partial class getStatusRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string rucComprobante;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string tipoComprobante;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string serieComprobante;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=3)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int numeroComprobante;
        
        public getStatusRequest()
        {
        }
        
        public getStatusRequest(string rucComprobante, string tipoComprobante, string serieComprobante, int numeroComprobante)
        {
            this.rucComprobante = rucComprobante;
            this.tipoComprobante = tipoComprobante;
            this.serieComprobante = serieComprobante;
            this.numeroComprobante = numeroComprobante;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getStatusResponse", WrapperNamespace="http://service.sunat.gob.pe", IsWrapped=true)]
    public partial class getStatusResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service.sunat.gob.pe", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ConsultasSunat.statusResponse status;
        
        public getStatusResponse()
        {
        }
        
        public getStatusResponse(ConsultasSunat.statusResponse status)
        {
            this.status = status;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    public interface billServiceChannel : ConsultasSunat.billService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    public partial class billServiceClient : System.ServiceModel.ClientBase<ConsultasSunat.billService>, ConsultasSunat.billService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public billServiceClient() : 
                base(billServiceClient.GetDefaultBinding(), billServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BillConsultServicePort.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public billServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(billServiceClient.GetBindingForEndpoint(endpointConfiguration), billServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public billServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(billServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public billServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(billServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public billServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ConsultasSunat.getStatusCdrResponse ConsultasSunat.billService.getStatusCdr(ConsultasSunat.getStatusCdrRequest request)
        {
            return base.Channel.getStatusCdr(request);
        }
        
        public ConsultasSunat.statusResponse getStatusCdr(string rucComprobante, string tipoComprobante, string serieComprobante, int numeroComprobante)
        {
            ConsultasSunat.getStatusCdrRequest inValue = new ConsultasSunat.getStatusCdrRequest();
            inValue.rucComprobante = rucComprobante;
            inValue.tipoComprobante = tipoComprobante;
            inValue.serieComprobante = serieComprobante;
            inValue.numeroComprobante = numeroComprobante;
            ConsultasSunat.getStatusCdrResponse retVal = ((ConsultasSunat.billService)(this)).getStatusCdr(inValue);
            return retVal.statusCdr;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ConsultasSunat.getStatusCdrResponse> ConsultasSunat.billService.getStatusCdrAsync(ConsultasSunat.getStatusCdrRequest request)
        {
            return base.Channel.getStatusCdrAsync(request);
        }
        
        public System.Threading.Tasks.Task<ConsultasSunat.getStatusCdrResponse> getStatusCdrAsync(string rucComprobante, string tipoComprobante, string serieComprobante, int numeroComprobante)
        {
            ConsultasSunat.getStatusCdrRequest inValue = new ConsultasSunat.getStatusCdrRequest();
            inValue.rucComprobante = rucComprobante;
            inValue.tipoComprobante = tipoComprobante;
            inValue.serieComprobante = serieComprobante;
            inValue.numeroComprobante = numeroComprobante;
            return ((ConsultasSunat.billService)(this)).getStatusCdrAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ConsultasSunat.getStatusResponse ConsultasSunat.billService.getStatus(ConsultasSunat.getStatusRequest request)
        {
            return base.Channel.getStatus(request);
        }
        
        public ConsultasSunat.statusResponse getStatus(string rucComprobante, string tipoComprobante, string serieComprobante, int numeroComprobante)
        {
            ConsultasSunat.getStatusRequest inValue = new ConsultasSunat.getStatusRequest();
            inValue.rucComprobante = rucComprobante;
            inValue.tipoComprobante = tipoComprobante;
            inValue.serieComprobante = serieComprobante;
            inValue.numeroComprobante = numeroComprobante;
            ConsultasSunat.getStatusResponse retVal = ((ConsultasSunat.billService)(this)).getStatus(inValue);
            return retVal.status;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ConsultasSunat.getStatusResponse> ConsultasSunat.billService.getStatusAsync(ConsultasSunat.getStatusRequest request)
        {
            return base.Channel.getStatusAsync(request);
        }
        
        public System.Threading.Tasks.Task<ConsultasSunat.getStatusResponse> getStatusAsync(string rucComprobante, string tipoComprobante, string serieComprobante, int numeroComprobante)
        {
            ConsultasSunat.getStatusRequest inValue = new ConsultasSunat.getStatusRequest();
            inValue.rucComprobante = rucComprobante;
            inValue.tipoComprobante = tipoComprobante;
            inValue.serieComprobante = serieComprobante;
            inValue.numeroComprobante = numeroComprobante;
            return ((ConsultasSunat.billService)(this)).getStatusAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BillConsultServicePort))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BillConsultServicePort))
            {
                return new System.ServiceModel.EndpointAddress("https://e-factura.sunat.gob.pe/ol-it-wsconscpegem/billConsultService");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return billServiceClient.GetBindingForEndpoint(EndpointConfiguration.BillConsultServicePort);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return billServiceClient.GetEndpointAddress(EndpointConfiguration.BillConsultServicePort);
        }
        
        public enum EndpointConfiguration
        {
            
            BillConsultServicePort,
        }
    }
}