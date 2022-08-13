using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeamWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IOrganizationService service = ConnectionFactory.GetService();

            Entity conta = new Entity("account");
            Console.WriteLine("Nome da conta: ");
            var name = (Console.ReadLine());
            conta["name"] = (name);
            service.Create(conta);
        }
    }
}
