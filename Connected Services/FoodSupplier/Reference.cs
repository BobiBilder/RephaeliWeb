﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MasterProject.FoodSupplier {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Food", Namespace="http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    public partial class Food : MasterProject.FoodSupplier.BaseModel {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FoodDescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FoodNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FoodPictureField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double FoodPriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private MasterProject.FoodSupplier.FoodType FoodTypeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FoodDescription {
            get {
                return this.FoodDescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.FoodDescriptionField, value) != true)) {
                    this.FoodDescriptionField = value;
                    this.RaisePropertyChanged("FoodDescription");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FoodName {
            get {
                return this.FoodNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FoodNameField, value) != true)) {
                    this.FoodNameField = value;
                    this.RaisePropertyChanged("FoodName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FoodPicture {
            get {
                return this.FoodPictureField;
            }
            set {
                if ((object.ReferenceEquals(this.FoodPictureField, value) != true)) {
                    this.FoodPictureField = value;
                    this.RaisePropertyChanged("FoodPicture");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double FoodPrice {
            get {
                return this.FoodPriceField;
            }
            set {
                if ((this.FoodPriceField.Equals(value) != true)) {
                    this.FoodPriceField = value;
                    this.RaisePropertyChanged("FoodPrice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public MasterProject.FoodSupplier.FoodType FoodType {
            get {
                return this.FoodTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.FoodTypeField, value) != true)) {
                    this.FoodTypeField = value;
                    this.RaisePropertyChanged("FoodType");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseModel", Namespace="http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(MasterProject.FoodSupplier.FoodType))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(MasterProject.FoodSupplier.Order))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(MasterProject.FoodSupplier.Food))]
    public partial class BaseModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FoodType", Namespace="http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    public partial class FoodType : MasterProject.FoodSupplier.BaseModel {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FoodTypeNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FoodTypeName {
            get {
                return this.FoodTypeNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FoodTypeNameField, value) != true)) {
                    this.FoodTypeNameField = value;
                    this.RaisePropertyChanged("FoodTypeName");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Order", Namespace="http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    public partial class Order : MasterProject.FoodSupplier.BaseModel {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int[] FoodIDsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsPaidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string buisnessIDField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Date {
            get {
                return this.DateField;
            }
            set {
                if ((object.ReferenceEquals(this.DateField, value) != true)) {
                    this.DateField = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int[] FoodIDs {
            get {
                return this.FoodIDsField;
            }
            set {
                if ((object.ReferenceEquals(this.FoodIDsField, value) != true)) {
                    this.FoodIDsField = value;
                    this.RaisePropertyChanged("FoodIDs");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsPaid {
            get {
                return this.IsPaidField;
            }
            set {
                if ((this.IsPaidField.Equals(value) != true)) {
                    this.IsPaidField = value;
                    this.RaisePropertyChanged("IsPaid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string buisnessID {
            get {
                return this.buisnessIDField;
            }
            set {
                if ((object.ReferenceEquals(this.buisnessIDField, value) != true)) {
                    this.buisnessIDField = value;
                    this.RaisePropertyChanged("buisnessID");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FoodSupplier.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAllFood", ReplyAction="http://tempuri.org/IService/GetAllFoodResponse")]
        MasterProject.FoodSupplier.Food[] GetAllFood();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAllFood", ReplyAction="http://tempuri.org/IService/GetAllFoodResponse")]
        System.Threading.Tasks.Task<MasterProject.FoodSupplier.Food[]> GetAllFoodAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeleteOrder", ReplyAction="http://tempuri.org/IService/DeleteOrderResponse")]
        bool DeleteOrder(string[] orderIDs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DeleteOrder", ReplyAction="http://tempuri.org/IService/DeleteOrderResponse")]
        System.Threading.Tasks.Task<bool> DeleteOrderAsync(string[] orderIDs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAllOrders", ReplyAction="http://tempuri.org/IService/GetAllOrdersResponse")]
        MasterProject.FoodSupplier.Order[] GetAllOrders(string businessID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAllOrders", ReplyAction="http://tempuri.org/IService/GetAllOrdersResponse")]
        System.Threading.Tasks.Task<MasterProject.FoodSupplier.Order[]> GetAllOrdersAsync(string businessID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/PutOrder", ReplyAction="http://tempuri.org/IService/PutOrderResponse")]
        bool PutOrder(MasterProject.FoodSupplier.Order order);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/PutOrder", ReplyAction="http://tempuri.org/IService/PutOrderResponse")]
        System.Threading.Tasks.Task<bool> PutOrderAsync(MasterProject.FoodSupplier.Order order);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : MasterProject.FoodSupplier.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<MasterProject.FoodSupplier.IService>, MasterProject.FoodSupplier.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public MasterProject.FoodSupplier.Food[] GetAllFood() {
            return base.Channel.GetAllFood();
        }
        
        public System.Threading.Tasks.Task<MasterProject.FoodSupplier.Food[]> GetAllFoodAsync() {
            return base.Channel.GetAllFoodAsync();
        }
        
        public bool DeleteOrder(string[] orderIDs) {
            return base.Channel.DeleteOrder(orderIDs);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteOrderAsync(string[] orderIDs) {
            return base.Channel.DeleteOrderAsync(orderIDs);
        }
        
        public MasterProject.FoodSupplier.Order[] GetAllOrders(string businessID) {
            return base.Channel.GetAllOrders(businessID);
        }
        
        public System.Threading.Tasks.Task<MasterProject.FoodSupplier.Order[]> GetAllOrdersAsync(string businessID) {
            return base.Channel.GetAllOrdersAsync(businessID);
        }
        
        public bool PutOrder(MasterProject.FoodSupplier.Order order) {
            return base.Channel.PutOrder(order);
        }
        
        public System.Threading.Tasks.Task<bool> PutOrderAsync(MasterProject.FoodSupplier.Order order) {
            return base.Channel.PutOrderAsync(order);
        }
    }
}
