using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows;

namespace PequeñoSistema.DB
{
    class DBAddProducts : DBConexion
    {
        public void AddProduct(string nombre, string tamaño, string precio, string fotografia, string ingredientes)
        {
            try
            {
                string query = "insert into productos (nombre, tamaño, precio, imagen, ingredientes) " +
                "values ('" + nombre + "','" + tamaño + "','" + precio + "','" + fotografia + "','" + ingredientes + "')";

                conn.Open();
                NpgsqlCommand comand = new NpgsqlCommand(query, conn);
                comand.ExecuteNonQuery();
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
