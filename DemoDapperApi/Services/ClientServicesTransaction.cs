using DemoDapperApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoDapperApi.Services
{
    public partial class ClientServices
    {
        public ClientServices()
        {

        }
        public void AddClientTransaction(Cliente cliente)
        {
            //declarar el contexto
            //inicializar la transaccion
            using var context = new ClienteIXContext();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.Clientes.Add(cliente);
                context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }

        }

        public void AddClientWithSavePoint(Cliente cliente)
        {
            using var transaction = clienteIXContext.Database.BeginTransaction();
            try
            {
                //Save Point
                transaction.CreateSavepoint("BeforeSave");
                clienteIXContext.Clientes.Add(cliente);
                clienteIXContext.SaveChanges();
                throw new Exception();
                //transaction.Commit();
            }
            catch (Exception)
            {
                transaction.RollbackToSavepoint("BeforeSave");
                throw;
            }
        }
        public void AddClientWithSavePointManyContext(Cliente cliente)
        {
            DemoTriggerUdeoContext DemoTrigger = new DemoTriggerUdeoContext();
            using var transaction = clienteIXContext.Database.BeginTransaction();
            using var transaction2 = DemoTrigger.Database.BeginTransaction();
            try
            {

                clienteIXContext.Clientes.Add(cliente);
                clienteIXContext.SaveChanges();
                //Save Point
                transaction2.CreateSavepoint("BeforeSave");
                DemoTrigger.Employees.Add(new Employee { FirstName = "Ana", LastName = "Valencia" });
                DemoTrigger.CallOutcomes.Add(new CallOutcome { OutcomeText = "Llamada de prueba" });
                DemoTrigger.CallOutcomes.Add(new CallOutcome { OutcomeText = "Llamada de prueba 2 " });
                DemoTrigger.SaveChanges();
                transaction.Commit();
                transaction2.Commit();
            }
            catch (Exception)
            {
                transaction2.RollbackToSavepoint("BeforeSave");
                throw;
            }
            finally
            {
                transaction.Commit();
            }
        }
    }
}
