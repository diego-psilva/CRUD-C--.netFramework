using Crud.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Crud.Dao
{
    public class ClienteDao
    {
		//IBRVant
        //private static readonly string servidor = "DESKTOP-14PB3D8";
        //private static readonly string bd = "Db_cliente";
        //private static readonly string usuario = "admim";
        //private static readonly string senha = "123";
			
		private static readonly string servidor = "DELL_VOSTRO";
        private static readonly string bd = "Db_cliente";
        private static readonly string usuario = "admim";
        private static readonly string senha = "123456";
        


        public static List<Cliente> ListarClientes()
        {

            var ret = new List<Cliente>();

            using (var conexao = new SqlConnection())
            {

                conexao.ConnectionString = @"Data Source=" + servidor + "\\SQLEXPRESS; Initial Catalog=" + bd +";User Id=" + usuario + ";Password=" + senha + "";
                conexao.Open();
                using (var comando = new SqlCommand())
                {

                    comando.Connection = conexao;
                    comando.CommandText = "select * from cliente order by idCliente";
                    var reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        ret.Add(new Cliente
                        {
                            IdCliente = (int)reader["idCliente"],
                            Nome = (string)reader["nome"],
                            Email = (string)reader["email"]
                        });
                    }
                }
            }

            return ret;
        }

        public static Cliente ConsultarClientePorId(int idCliente)
        {
            Cliente cliente = null;

            using (var conexao = new SqlConnection())
            {

                conexao.ConnectionString = @"Data Source=" + servidor + "\\SQLEXPRESS; Initial Catalog=" + bd + ";User Id=" + usuario + ";Password=" + senha + "";
                conexao.Open();
                using (var comando = new SqlCommand())
                {

                    comando.Connection = conexao;
                    comando.CommandText = string.Format(
                        "select * from cliente where idCliente={0}", idCliente);

                    var reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        cliente = new Cliente
                        {
                            IdCliente = (int)reader["idCliente"],
                            Nome = (string)reader["nome"],
                            Email = (string)reader["email"]

                        };

                    }
                }
            }

            return cliente;
        }

        public static void CadastrarCliente(Cliente cliente)
        {

            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = @"Data Source=" + servidor + "\\SQLEXPRESS; Initial Catalog=" + bd + ";User Id=" + usuario + ";Password=" + senha + "";

                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = string.Format(
                    "insert into cliente (nome, email) values ('{0}','{1}');", cliente.Nome, cliente.Email);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public static void AtualizarCliente(Cliente cliente)
        {
            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = @"Data Source=" + servidor + "\\SQLEXPRESS; Initial Catalog=" + bd + ";User Id=" + usuario + ";Password=" + senha + "";

                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = string.Format(
                    "UPDATE cliente SET nome = '{0}', email = '{1}' WHERE idCliente = " + cliente.IdCliente + ";", cliente.Nome, cliente.Email);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public static void ExcluirCliente(int idCliente)
        {
            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = @"Data Source=" + servidor + "\\SQLEXPRESS; Initial Catalog=" + bd + ";User Id=" + usuario + ";Password=" + senha + "";

                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = string.Format(
                    "DELETE FROM cliente WHERE idCliente = " + idCliente + ";");
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}