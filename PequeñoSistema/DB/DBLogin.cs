using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using PequeñoSistema.Clases;
using System.Windows;

namespace PequeñoSistema.DB
{
    class DBLogin : DBConexion
    {
        public bool Login(string usuario, string contraseña)
        {
            try
            {
                string query = "select * from usuarios " +
               "where usuario = '" + usuario + "' and contraseña = '" + contraseña + "'";

                conn.Open();
                NpgsqlCommand conector = new NpgsqlCommand(query, conn);
                NpgsqlDataReader dr = conector.ExecuteReader();

                if (dr.Read())
                {
                    Usuario.UsuarioN = dr.GetString(0);
                    Usuario.Nombre = dr.GetString(1);
                    Usuario.Apellidos = dr.GetString(2);
                    Usuario.Correo = dr.GetString(3);
                    Usuario.Contraseña = dr.GetString(4);
                    Usuario.Administrador = dr.GetString(5);
                    dr.Close();
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }               
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
                return false;
            }         
        }
    }
}
