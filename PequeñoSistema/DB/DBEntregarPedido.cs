using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PequeñoSistema.Ventana;
using System.Windows;
using Npgsql;

namespace PequeñoSistema.DB
{
    class DBEntregarPedido : DBConexion
    {
        public void Entregar()
        {
            try
            {
                string query = "delete from pedidos where npedido = '" + OrderDetails.Codigo + "'";

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
