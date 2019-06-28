using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceSoap.DataAccess
{
    public class DAOClients
    {
        /// <summary>
        /// (identificador del cliente)
        /// </summary>
        public int SharedKey { get; set; }
        /// <summary>
        /// (Nombre del cliente)
        /// </summary>
        public string BusinessID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DataAdded { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        /// <summary>
        /// (Activo o Inactivo)
        /// </summary>
        public bool State { get; set; }
       

    }
}