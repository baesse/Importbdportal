using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportBancoPortal
{
    class bdsql
    {
        public SqlConnection GetConexao()
        {
            SqlConnection Conexao = new SqlConnection("");
            Conexao.Open();

            return Conexao;

        }

        public SqlCommand GetComando(SqlConnection Conexao)
        {
            SqlCommand Comando = Conexao.CreateCommand();
            return Comando;
        }

        public SqlDataReader GetReader(SqlCommand Comando)
        {
            SqlDataReader Reader = Comando.ExecuteReader();
            return Reader;

        }

       
    }
}
