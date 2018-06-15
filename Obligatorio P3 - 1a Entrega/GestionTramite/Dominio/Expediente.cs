
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using AccesosDB;

namespace Dominio
{
    public class Expediente
    {
        public DateTime FechaActual { get; set; }
        public int Id { get; set; }
        public static int NroId = 0;
        public bool Abierto { get; set; }
        public Solicitante unSolicitante { get; set; }
        public Tramite unTramite { get; set; }

        #region CONTRUCTOR

        public Expediente()
        {
            Expediente.NroId++;
            this.Id = Expediente.NroId;
        }
        #endregion

    }
}
