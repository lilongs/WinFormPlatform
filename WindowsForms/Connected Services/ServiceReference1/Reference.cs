﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections.Generic;

namespace WindowsForms.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IPermissionInterface")]
    public interface IPermissionInterface {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPermissionInterface/Login", ReplyAction="http://tempuri.org/IPermissionInterface/LoginResponse")]
        bool Login(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPermissionInterface/Login", ReplyAction="http://tempuri.org/IPermissionInterface/LoginResponse")]
        System.Threading.Tasks.Task<bool> LoginAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPermissionInterface/UpdatePassword", ReplyAction="http://tempuri.org/IPermissionInterface/UpdatePasswordResponse")]
        bool UpdatePassword(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPermissionInterface/UpdatePassword", ReplyAction="http://tempuri.org/IPermissionInterface/UpdatePasswordResponse")]
        System.Threading.Tasks.Task<bool> UpdatePasswordAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPermissionInterface/Operatelog", ReplyAction="http://tempuri.org/IPermissionInterface/OperatelogResponse")]
        void Operatelog(string username, string ip, string computername, string formname);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPermissionInterface/Operatelog", ReplyAction="http://tempuri.org/IPermissionInterface/OperatelogResponse")]
        System.Threading.Tasks.Task OperatelogAsync(string username, string ip, string computername, string formname);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPermissionInterface/CheckUsername", ReplyAction="http://tempuri.org/IPermissionInterface/CheckUsernameResponse")]
        bool CheckUsername(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPermissionInterface/CheckUsername", ReplyAction="http://tempuri.org/IPermissionInterface/CheckUsernameResponse")]
        System.Threading.Tasks.Task<bool> CheckUsernameAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPermissionInterface/Register", ReplyAction="http://tempuri.org/IPermissionInterface/RegisterResponse")]
        bool Register(string username, string password, string realname, string telephone, int deptno, int roleid, string createby);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPermissionInterface/Register", ReplyAction="http://tempuri.org/IPermissionInterface/RegisterResponse")]
        System.Threading.Tasks.Task<bool> RegisterAsync(string username, string password, string realname, string telephone, int deptno, int roleid, string createby);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPermissionInterface/UpdateUser", ReplyAction="http://tempuri.org/IPermissionInterface/UpdateUserResponse")]
        bool UpdateUser(string username, string realname, string telephone, int deptno, int roleid, string updateby);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPermissionInterface/UpdateUser", ReplyAction="http://tempuri.org/IPermissionInterface/UpdateUserResponse")]
        System.Threading.Tasks.Task<bool> UpdateUserAsync(string username, string realname, string telephone, int deptno, int roleid, string updateby);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPermissionInterface/GetUserMenuInfo", ReplyAction="http://tempuri.org/IPermissionInterface/GetUserMenuInfoResponse")]
        System.Data.DataTable GetUserMenuInfo(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPermissionInterface/GetUserMenuInfo", ReplyAction="http://tempuri.org/IPermissionInterface/GetUserMenuInfoResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetUserMenuInfoAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPermissionInterface/GetUserInfo", ReplyAction="http://tempuri.org/IPermissionInterface/GetUserInfoResponse")]
        System.Data.DataTable GetUserInfo(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPermissionInterface/GetUserInfo", ReplyAction="http://tempuri.org/IPermissionInterface/GetUserInfoResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetUserInfoAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPermissionInterface/StopUser", ReplyAction="http://tempuri.org/IPermissionInterface/StopUserResponse")]
        bool StopUser(List<string> listusername);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPermissionInterface/StopUser", ReplyAction="http://tempuri.org/IPermissionInterface/StopUserResponse")]
        System.Threading.Tasks.Task<bool> StopUserAsync(List<string> listusername);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPermissionInterfaceChannel : WindowsForms.ServiceReference1.IPermissionInterface, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PermissionInterfaceClient : System.ServiceModel.ClientBase<WindowsForms.ServiceReference1.IPermissionInterface>, WindowsForms.ServiceReference1.IPermissionInterface {
        
        public PermissionInterfaceClient() {
        }
        
        public PermissionInterfaceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PermissionInterfaceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PermissionInterfaceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PermissionInterfaceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Login(string username, string password) {
            return base.Channel.Login(username, password);
        }
        
        public System.Threading.Tasks.Task<bool> LoginAsync(string username, string password) {
            return base.Channel.LoginAsync(username, password);
        }
        
        public bool UpdatePassword(string username, string password) {
            return base.Channel.UpdatePassword(username, password);
        }
        
        public System.Threading.Tasks.Task<bool> UpdatePasswordAsync(string username, string password) {
            return base.Channel.UpdatePasswordAsync(username, password);
        }
        
        public void Operatelog(string username, string ip, string computername, string formname) {
            base.Channel.Operatelog(username, ip, computername, formname);
        }
        
        public System.Threading.Tasks.Task OperatelogAsync(string username, string ip, string computername, string formname) {
            return base.Channel.OperatelogAsync(username, ip, computername, formname);
        }
        
        public bool CheckUsername(string username) {
            return base.Channel.CheckUsername(username);
        }
        
        public System.Threading.Tasks.Task<bool> CheckUsernameAsync(string username) {
            return base.Channel.CheckUsernameAsync(username);
        }
        
        public bool Register(string username, string password, string realname, string telephone, int deptno, int roleid, string createby) {
            return base.Channel.Register(username, password, realname, telephone, deptno, roleid, createby);
        }
        
        public System.Threading.Tasks.Task<bool> RegisterAsync(string username, string password, string realname, string telephone, int deptno, int roleid, string createby) {
            return base.Channel.RegisterAsync(username, password, realname, telephone, deptno, roleid, createby);
        }
        
        public bool UpdateUser(string username, string realname, string telephone, int deptno, int roleid, string updateby) {
            return base.Channel.UpdateUser(username, realname, telephone, deptno, roleid, updateby);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateUserAsync(string username, string realname, string telephone, int deptno, int roleid, string updateby) {
            return base.Channel.UpdateUserAsync(username, realname, telephone, deptno, roleid, updateby);
        }
        
        public System.Data.DataTable GetUserMenuInfo(string username) {
            return base.Channel.GetUserMenuInfo(username);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetUserMenuInfoAsync(string username) {
            return base.Channel.GetUserMenuInfoAsync(username);
        }
        
        public System.Data.DataTable GetUserInfo(string username) {
            return base.Channel.GetUserInfo(username);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetUserInfoAsync(string username) {
            return base.Channel.GetUserInfoAsync(username);
        }
        
        public bool StopUser(List<string> listusername) {
            return base.Channel.StopUser(listusername);
        }
        
        public System.Threading.Tasks.Task<bool> StopUserAsync(List<string> listusername) {
            return base.Channel.StopUserAsync(listusername);
        }
    }
}
