using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyFirstPlugin
{
    public abstract class ActionImplement : CodeActivity
    {
        public IWorkflowContext WorkflowContext;
        public IOrganizationServiceFactory ServiceFactory;
        public IOrganizationService Service;

        protected override void Execute(CodeActivityContext context)
        {
            WorkflowContext = context.GetExtension<IWorkflowContext>();
            ServiceFactory = context.GetExtension<IOrganizationServiceFactory>();
            Service = ServiceFactory.CreateOrganizationService(WorkflowContext.UserId);

            Execute(context);
        }

        public abstract void ExecuteAction(CodeActivityContext context);

    }
}
