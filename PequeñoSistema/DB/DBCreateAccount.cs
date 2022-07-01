using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows;

namespace PequeñoSistema.DB
{
    class DBCreateAccount : DBConexion
    {
        public void CreateAccount(string usuario, string nombre, string apellidos, string correo, string contraseña)
        {
            try
            {
                string query = "insert into usuarios values ('" + usuario + "','" + nombre + "','" + apellidos + "','" + correo + "','" + contraseña + "','no')";

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
