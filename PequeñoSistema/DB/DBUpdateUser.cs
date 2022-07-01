using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PequeñoSistema.Clases;
using Npgsql;
using System.Windows;

namespace PequeñoSistema.DB
{
    class DBUpdateUser : DBConexion
    {
        public void ActulizarDatos(string u, string n, string a, string c, string p)
        {
            try
            {
                string query = "update usuarios set usuario='" + u + "', nombre='" + n + "', apellidos='" + a + "', correo='" + c + "', contraseña='" + p + "' " +
                "where usuario='" + Usuario.UsuarioN + "' ";

                conn.Open();
                NpgsqlCommand conexion = new NpgsqlCommand(query, conn);
                conexion.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
