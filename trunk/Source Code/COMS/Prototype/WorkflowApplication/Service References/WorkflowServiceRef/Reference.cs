﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorkflowApplication.WorkflowServiceRef {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WorkflowServiceRef.IWorkflow")]
    public interface IWorkflow {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWorkflow/createStep", ReplyAction="http://tempuri.org/IWorkflow/createStepResponse")]
        void createStep(string StepName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWorkflow/createWorkflow", ReplyAction="http://tempuri.org/IWorkflow/createWorkflowResponse")]
        void createWorkflow(string WorkflowName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWorkflow/getWorkFlows", ReplyAction="http://tempuri.org/IWorkflow/getWorkFlowsResponse")]
        string[] getWorkFlows();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWorkflow/getSteps", ReplyAction="http://tempuri.org/IWorkflow/getStepsResponse")]
        string[] getSteps();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWorkflow/insertStep", ReplyAction="http://tempuri.org/IWorkflow/insertStepResponse")]
        void insertStep(string WorkflowName, string StepName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWorkflowChannel : WorkflowApplication.WorkflowServiceRef.IWorkflow, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WorkflowClient : System.ServiceModel.ClientBase<WorkflowApplication.WorkflowServiceRef.IWorkflow>, WorkflowApplication.WorkflowServiceRef.IWorkflow {
        
        public WorkflowClient() {
        }
        
        public WorkflowClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WorkflowClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WorkflowClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WorkflowClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void createStep(string StepName) {
            base.Channel.createStep(StepName);
        }
        
        public void createWorkflow(string WorkflowName) {
            base.Channel.createWorkflow(WorkflowName);
        }
        
        public string[] getWorkFlows() {
            return base.Channel.getWorkFlows();
        }
        
        public string[] getSteps() {
            return base.Channel.getSteps();
        }
        
        public void insertStep(string WorkflowName, string StepName) {
            base.Channel.insertStep(WorkflowName, StepName);
        }
    }
}