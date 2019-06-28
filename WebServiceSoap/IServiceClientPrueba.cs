using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceSoap
{
    [ServiceContract]
    public interface IServiceClientPrueba
    {
        [OperationContract]
        List<Cliente> ListarCliente();

        [OperationContract]
        int AgregarCliente(Cliente cliente);

        [OperationContract]
        bool ActualizarCliente(Cliente cliente);

        [OperationContract]
        bool BorrarCliente(int SharedKey);
        
    }
}
