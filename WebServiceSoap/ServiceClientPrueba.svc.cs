using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WebServiceSoap.DataAccess;

namespace WebServiceSoap
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceClientPrueba" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceClientPrueba.svc o ServiceClientPrueba.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceClientPrueba : IServiceClientPrueba
    {
        /// <summary>
        /// Actualizar un cliente existente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>true si es satisactorio el cambio</returns>
        public bool ActualizarCliente(Cliente cliente)
        {
            PostgreDataAccess PsDB = new PostgreDataAccess();
  
            DAOClients DaoClient = new DAOClients() {
                SharedKey = cliente.SharedKey,
                BusinessID = cliente.BusinessID,
                Email = cliente.Email,
                Phone = cliente.Phone,
                DataAdded = cliente.DataAdded,
                StartDate = cliente.StartDate,
                EndDate = cliente.EndDate,
                State = cliente.State.ToLower().Trim() == "activo" ? true : false
            };           

            return PsDB.ActualizarCliente(DaoClient); ;
        }

        /// <summary>
        /// Agergar un cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>1 si es satisactorio el cambio</returns>
        public int AgregarCliente(Cliente cliente)
        {
            PostgreDataAccess PsDB = new PostgreDataAccess();

            DAOClients DaoClient = new DAOClients()
            {
                BusinessID = cliente.BusinessID,
                Email = cliente.Email,
                Phone = cliente.Phone,
                DataAdded = cliente.DataAdded,
                StartDate = cliente.StartDate,
                EndDate = cliente.EndDate,
                State = cliente.State.ToLower().Trim() == "activo" ? true : false
            };
            
            return PsDB.CreateCliente(DaoClient);
        }        

        /// <summary>
        /// Borrar un cliente Existente
        /// </summary>
        /// <param name="SharedKey"></param>
        /// <returns>true si es satisactorio el cambio</returns>
        public bool BorrarCliente(int SharedKey)
        {
            PostgreDataAccess PsDB = new PostgreDataAccess();

            return PsDB.BorrarCliente(SharedKey);           
        }       

        /// <summary>
        /// lista todos los clientes
        /// </summary>
        /// <returns>Listado de clientes</returns>
        public List<Cliente> ListarCliente()
        {
            PostgreDataAccess PsDB = new PostgreDataAccess();

            List<Cliente> ListaCliente = new List<Cliente>();

            foreach (var item in PsDB.ListarClientes())
            {
                Cliente cliente = new Cliente()
                {
                    SharedKey = item.SharedKey,
                    BusinessID = item.BusinessID,
                    Email = item.Email,
                    Phone = item.Phone,
                    DataAdded = item.DataAdded,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    State = item.State == true ? "Activo" : "Inactivo"
                };

                ListaCliente.Add(cliente);
            }
            return ListaCliente;
        }
    }
}
