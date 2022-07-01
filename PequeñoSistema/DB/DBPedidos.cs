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
    class DBPedidos : DBConexion
    {
        public void Pedidos()
        {
            try
            {
                LimpiarLista();
                string query = "select * from pedidos " +
                    "order by fentrega desc";

                conn.Open();
                NpgsqlCommand conector = new NpgsqlCommand(query, conn);
                NpgsqlDataReader dr = conector.ExecuteReader();

                while (dr.Read())
                {
                    ListaDePedidos.Cliente.Add(dr[0]);
                    ListaDePedidos.NPedido.Add(dr[1]);
                    ListaDePedidos.Descripcion.Add(dr[2]);
                    ListaDePedidos.FEntrega.Add(dr[3]);
                    ListaDePedidos.Precio.Add(dr[4]);
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        public void PedidosUser()
        {
            try
            {
                LimpiarLista();
                string query = "select * from pedidos " +
                    "where cliente = '" + Usuario.Nombre + " " + Usuario.Apellidos + "' " +
                    "order by fentrega desc";

                conn.Open();
                NpgsqlCommand conector = new NpgsqlCommand(query, conn);
                NpgsqlDataReader dr = conector.ExecuteReader();

                while (dr.Read())
                {
                    ListaDePedidos.Cliente.Add(dr[0]);
                    ListaDePedidos.NPedido.Add(dr[1]);
                    ListaDePedidos.Descripcion.Add(dr[2]);
                    ListaDePedidos.FEntrega.Add(dr[3]);
                    ListaDePedidos.Precio.Add(dr[4]);
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        public void BuscarPedido(string ped)
        {
            try
            {
                LimpiarLista();
                string query = "select * from pedidos where npedido ilike '%" + ped + "%' " +
                       "order by fentrega desc";

                conn.Open();
                NpgsqlCommand conector = new NpgsqlCommand(query, conn);
                NpgsqlDataReader dr = conector.ExecuteReader();

                while (dr.Read())
                {
                    ListaDePedidos.Cliente.Add(dr[0]);
                    ListaDePedidos.NPedido.Add(dr[1]);
                    ListaDePedidos.Descripcion.Add(dr[2]);
                    ListaDePedidos.FEntrega.Add(dr[3]);
                    ListaDePedidos.Precio.Add(dr[4]);
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void BuscarPedidoUser(string ped)
        {
            try
            {
                LimpiarLista();
                string query = "select * from pedidos where npedido ilike '%" + ped + "%' and " +
                    "cliente = '"+ Usuario.Nombre + " " + Usuario.Apellidos + "' " +
                       "order by fentrega desc";

                conn.Open();
                NpgsqlCommand conector = new NpgsqlCommand(query, conn);
                NpgsqlDataReader dr = conector.ExecuteReader();

                while (dr.Read())
                {
                    ListaDePedidos.Cliente.Add(dr[0]);
                    ListaDePedidos.NPedido.Add(dr[1]);
                    ListaDePedidos.Descripcion.Add(dr[2]);
                    ListaDePedidos.FEntrega.Add(dr[3]);
                    ListaDePedidos.Precio.Add(dr[4]);
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LimpiarLista()
        {
            ListaDePedidos.Cliente.Clear();
            ListaDePedidos.NPedido.Clear();
            ListaDePedidos.Descripcion.Clear();
            ListaDePedidos.FEntrega.Clear();
            ListaDePedidos.Precio.Clear();
        }
    }
}
