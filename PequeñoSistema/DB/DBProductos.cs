using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Npgsql;
using PequeñoSistema.Clases;

namespace PequeñoSistema.DB
{
    class DBProductos : DBConexion
    {
        public void Productoss()
        {
            try
            {
                LimpiarLista();
                string query = "select * from productos " +
                    "order by nombre asc";

                conn.Open();
                NpgsqlCommand conector = new NpgsqlCommand(query, conn);
                NpgsqlDataReader dr = conector.ExecuteReader();

                while (dr.Read())
                {

                    TotalProductos.ListID.Add(dr[0]);
                    TotalProductos.ListNombre.Add(dr[1]);
                    TotalProductos.ListTamaño.Add(dr[2]);
                    TotalProductos.ListPrecio.Add(dr[3]);
                    TotalProductos.ListImagen.Add(dr[4]);
                    TotalProductos.ListIngredientes.Add(dr[5]);

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

        public void BuscarProductos(string nom)
        {
            try
            {
                LimpiarLista();
                string query = "select * from productos where nombre ilike '%" + nom + "%' " +
                       "order by nombre asc";

                conn.Open();
                NpgsqlCommand conector = new NpgsqlCommand(query, conn);
                NpgsqlDataReader dr = conector.ExecuteReader();

                while (dr.Read())
                {

                    TotalProductos.ListID.Add(dr[0]);
                    TotalProductos.ListNombre.Add(dr[1]);
                    TotalProductos.ListTamaño.Add(dr[2]);
                    TotalProductos.ListPrecio.Add(dr[3]);
                    TotalProductos.ListImagen.Add(dr[4]);
                    TotalProductos.ListIngredientes.Add(dr[5]);

                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }         
        }

        private void LimpiarLista()
        {
            TotalProductos.ListID.Clear();
            TotalProductos.ListNombre.Clear();
            TotalProductos.ListTamaño.Clear();
            TotalProductos.ListPrecio.Clear();
            TotalProductos.ListImagen.Clear();
            TotalProductos.ListIngredientes.Clear();
        }
    }
}
