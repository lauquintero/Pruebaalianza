using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceSoap
{
    [DataContract]
    public class Cliente
    {
        /// <summary>
        /// (identificador del cliente)
        /// </summary>
        private int _SharedKey;

        [DataMember(EmitDefaultValue = false)]        
        public int SharedKey
        {
            get { return _SharedKey; }
            set { _SharedKey = value; }
        }

        /// <summary>
        /// (Nombre del cliente)
        /// </summary>
        private string _BusinessID;

        [DataMember]
        public string BusinessID
        {
            get { return _BusinessID; }
            set { _BusinessID = value; }
        }

        /// <summary>
        /// Email
        /// </summary>
        private string _Email;

        [DataMember]
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        /// <summary>
        /// Telefono
        /// </summary>
        private string _Phone;

        [DataMember]
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private DateTime _DataAdded;

        [DataMember]
        public DateTime DataAdded
        {
            get { return _DataAdded; }
            set { _DataAdded = value; }
        }

        private DateTime _StartDate;

        [DataMember]
        public DateTime StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }

        private DateTime _EndDate;

        [DataMember]
        public DateTime EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }

        public string _State;

        [DataMember]
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }
        
    }
}