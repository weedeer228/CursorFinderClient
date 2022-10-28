﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CursorFinderClient.CursorFinderService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MouseActionType", Namespace="http://schemas.datacontract.org/2004/07/CursorFinder.Models")]
    public enum MouseActionType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Shift = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        LeftButtonClick = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        RightButtonClick = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        MiddleButtonClick = 3,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CursorPosition", Namespace="http://schemas.datacontract.org/2004/07/CursorFinder.Models")]
    [System.SerializableAttribute()]
    public partial class CursorPosition : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private CursorFinderClient.CursorFinderService.MouseActionType ActionTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int XPosField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int YPosField;
        
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
        public CursorFinderClient.CursorFinderService.MouseActionType ActionType {
            get {
                return this.ActionTypeField;
            }
            set {
                if ((this.ActionTypeField.Equals(value) != true)) {
                    this.ActionTypeField = value;
                    this.RaisePropertyChanged("ActionType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DateTime {
            get {
                return this.DateTimeField;
            }
            set {
                if ((this.DateTimeField.Equals(value) != true)) {
                    this.DateTimeField = value;
                    this.RaisePropertyChanged("DateTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int XPos {
            get {
                return this.XPosField;
            }
            set {
                if ((this.XPosField.Equals(value) != true)) {
                    this.XPosField = value;
                    this.RaisePropertyChanged("XPos");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int YPos {
            get {
                return this.YPosField;
            }
            set {
                if ((this.YPosField.Equals(value) != true)) {
                    this.YPosField = value;
                    this.RaisePropertyChanged("YPos");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CursorFinderService.ICursorFinderService")]
    public interface ICursorFinderService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICursorFinderService/AddNewCursorPosition", ReplyAction="http://tempuri.org/ICursorFinderService/AddNewCursorPositionResponse")]
        void AddNewCursorPosition(int xPos, int Ypos, CursorFinderClient.CursorFinderService.MouseActionType actionType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICursorFinderService/AddNewCursorPosition", ReplyAction="http://tempuri.org/ICursorFinderService/AddNewCursorPositionResponse")]
        System.Threading.Tasks.Task AddNewCursorPositionAsync(int xPos, int Ypos, CursorFinderClient.CursorFinderService.MouseActionType actionType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICursorFinderService/StartRecord", ReplyAction="http://tempuri.org/ICursorFinderService/StartRecordResponse")]
        bool StartRecord();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICursorFinderService/StartRecord", ReplyAction="http://tempuri.org/ICursorFinderService/StartRecordResponse")]
        System.Threading.Tasks.Task<bool> StartRecordAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICursorFinderService/StopRecord", ReplyAction="http://tempuri.org/ICursorFinderService/StopRecordResponse")]
        bool StopRecord();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICursorFinderService/StopRecord", ReplyAction="http://tempuri.org/ICursorFinderService/StopRecordResponse")]
        System.Threading.Tasks.Task<bool> StopRecordAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICursorFinderService/GetAllCursorPositions", ReplyAction="http://tempuri.org/ICursorFinderService/GetAllCursorPositionsResponse")]
        CursorFinderClient.CursorFinderService.CursorPosition[] GetAllCursorPositions();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICursorFinderService/GetAllCursorPositions", ReplyAction="http://tempuri.org/ICursorFinderService/GetAllCursorPositionsResponse")]
        System.Threading.Tasks.Task<CursorFinderClient.CursorFinderService.CursorPosition[]> GetAllCursorPositionsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICursorFinderService/Auth", ReplyAction="http://tempuri.org/ICursorFinderService/AuthResponse")]
        int Auth(bool isAdmin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICursorFinderService/Auth", ReplyAction="http://tempuri.org/ICursorFinderService/AuthResponse")]
        System.Threading.Tasks.Task<int> AuthAsync(bool isAdmin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICursorFinderService/ClearDb", ReplyAction="http://tempuri.org/ICursorFinderService/ClearDbResponse")]
        bool ClearDb(int userAuthToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICursorFinderService/ClearDb", ReplyAction="http://tempuri.org/ICursorFinderService/ClearDbResponse")]
        System.Threading.Tasks.Task<bool> ClearDbAsync(int userAuthToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICursorFinderService/IsUSerAdmin", ReplyAction="http://tempuri.org/ICursorFinderService/IsUSerAdminResponse")]
        bool IsUSerAdmin(int userAuthToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICursorFinderService/IsUSerAdmin", ReplyAction="http://tempuri.org/ICursorFinderService/IsUSerAdminResponse")]
        System.Threading.Tasks.Task<bool> IsUSerAdminAsync(int userAuthToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICursorFinderService/GetDbRecordsCount", ReplyAction="http://tempuri.org/ICursorFinderService/GetDbRecordsCountResponse")]
        int GetDbRecordsCount();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICursorFinderService/GetDbRecordsCount", ReplyAction="http://tempuri.org/ICursorFinderService/GetDbRecordsCountResponse")]
        System.Threading.Tasks.Task<int> GetDbRecordsCountAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICursorFinderService/EnableNotification", ReplyAction="http://tempuri.org/ICursorFinderService/EnableNotificationResponse")]
        void EnableNotification();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICursorFinderService/EnableNotification", ReplyAction="http://tempuri.org/ICursorFinderService/EnableNotificationResponse")]
        System.Threading.Tasks.Task EnableNotificationAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICursorFinderService/DisableNotification", ReplyAction="http://tempuri.org/ICursorFinderService/DisableNotificationResponse")]
        void DisableNotification();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICursorFinderService/DisableNotification", ReplyAction="http://tempuri.org/ICursorFinderService/DisableNotificationResponse")]
        System.Threading.Tasks.Task DisableNotificationAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICursorFinderServiceChannel : CursorFinderClient.CursorFinderService.ICursorFinderService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CursorFinderServiceClient : System.ServiceModel.ClientBase<CursorFinderClient.CursorFinderService.ICursorFinderService>, CursorFinderClient.CursorFinderService.ICursorFinderService {
        
        public CursorFinderServiceClient() {
        }
        
        public CursorFinderServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CursorFinderServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CursorFinderServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CursorFinderServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void AddNewCursorPosition(int xPos, int Ypos, CursorFinderClient.CursorFinderService.MouseActionType actionType) {
            base.Channel.AddNewCursorPosition(xPos, Ypos, actionType);
        }
        
        public System.Threading.Tasks.Task AddNewCursorPositionAsync(int xPos, int Ypos, CursorFinderClient.CursorFinderService.MouseActionType actionType) {
            return base.Channel.AddNewCursorPositionAsync(xPos, Ypos, actionType);
        }
        
        public bool StartRecord() {
            return base.Channel.StartRecord();
        }
        
        public System.Threading.Tasks.Task<bool> StartRecordAsync() {
            return base.Channel.StartRecordAsync();
        }
        
        public bool StopRecord() {
            return base.Channel.StopRecord();
        }
        
        public System.Threading.Tasks.Task<bool> StopRecordAsync() {
            return base.Channel.StopRecordAsync();
        }
        
        public CursorFinderClient.CursorFinderService.CursorPosition[] GetAllCursorPositions() {
            return base.Channel.GetAllCursorPositions();
        }
        
        public System.Threading.Tasks.Task<CursorFinderClient.CursorFinderService.CursorPosition[]> GetAllCursorPositionsAsync() {
            return base.Channel.GetAllCursorPositionsAsync();
        }
        
        public int Auth(bool isAdmin) {
            return base.Channel.Auth(isAdmin);
        }
        
        public System.Threading.Tasks.Task<int> AuthAsync(bool isAdmin) {
            return base.Channel.AuthAsync(isAdmin);
        }
        
        public bool ClearDb(int userAuthToken) {
            return base.Channel.ClearDb(userAuthToken);
        }
        
        public System.Threading.Tasks.Task<bool> ClearDbAsync(int userAuthToken) {
            return base.Channel.ClearDbAsync(userAuthToken);
        }
        
        public bool IsUSerAdmin(int userAuthToken) {
            return base.Channel.IsUSerAdmin(userAuthToken);
        }
        
        public System.Threading.Tasks.Task<bool> IsUSerAdminAsync(int userAuthToken) {
            return base.Channel.IsUSerAdminAsync(userAuthToken);
        }
        
        public int GetDbRecordsCount() {
            return base.Channel.GetDbRecordsCount();
        }
        
        public System.Threading.Tasks.Task<int> GetDbRecordsCountAsync() {
            return base.Channel.GetDbRecordsCountAsync();
        }
        
        public void EnableNotification() {
            base.Channel.EnableNotification();
        }
        
        public System.Threading.Tasks.Task EnableNotificationAsync() {
            return base.Channel.EnableNotificationAsync();
        }
        
        public void DisableNotification() {
            base.Channel.DisableNotification();
        }
        
        public System.Threading.Tasks.Task DisableNotificationAsync() {
            return base.Channel.DisableNotificationAsync();
        }
    }
}