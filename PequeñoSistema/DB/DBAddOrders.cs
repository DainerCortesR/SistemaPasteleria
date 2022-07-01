using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PequeñoSistema.Clases;
using System.Windows;
using Npgsql;

namespace PequeñoSistema.DB
{
    class DBAddOrders : DBConexion
    {
        public void RealizarPedido(string cliente, string npedido, string descripcion, string fentrega, decimal precio)
        {
            try
            {
                string query = "insert into pedidos (cliente, npedido, descripcion, fentrega, precio) " +
                    "values ('" + cliente + "','" + npedido + "','" + descripcion + "','" + fentrega + "','" + precio + "')";

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
