using Microsoft.Xrm.Sdk.Workflow;
using Microsoft.Xrm.Sdk;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk.Query;
using SharedProject.Models;

namespace MyFirstPlugin.MyFirstAction
{
    public class SomaOportunidadesDoCliente : ActionImplement
    {
        [Output("Sucesso")]
        public OutArgument<bool> Sucesso { get; set; }

        public override void ExecuteAction(CodeActivityContext context)
        {
            Guid accountId = this.WorkflowContext.PrimaryEntityId;

            Oportunidade oportunidade = new Oportunidade(this.Service);
            EntityCollection opportunities = oportunidade.GetOpportunities(accountId);
            int numOpportunities = opportunities.Entities.Count();
            decimal totalValue = oportunidade.SumTotalValue(opportunities);

            Entity accountToUpdate = new Entity("account", accountId);
            accountToUpdate["dyp_totaldeoportunidades"] = new Money(totalValue);
            accountToUpdate["dyp_numerototaldeoportunidades"] = numOpportunities;
            this.Service.Update(accountToUpdate);

            Sucesso.Set(context, true);
        }

    }
}
