using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace PequeñoSistema.DB
{
    class DBConexion
    {
        protected NpgsqlConnection conn = new NpgsqlConnection("Server = ec2-3-223-213-207.compute-1.amazonaws.com; Port= 5432; User Id= ixhftyuylrdsgd; Password= 840c4b08a37f68152193553195b32a8c57e15da57f6b78d644c6bf0376aa7c23; Database= d1e27ald7o4rcr;");

        public bool ValidarInternet()
        {
            bool validar = false;

            try
            {
                conn.Open();
                conn.Close();
                validar = true;
            }
            catch (Exception)
            {
                conn.Close();
                validar = false;
            }
            return validar;
        }    
    }
}
