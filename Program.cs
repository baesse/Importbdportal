using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ImportBancoPortal
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex numerosremover = new Regex(@"\d+");

            OleDbConnection Connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\dbportal.mdb");
            Connection.Open();
            OleDbCommand Comand = new OleDbCommand("select * from funcionarios ", Connection);
            OleDbDataReader reader = Comand.ExecuteReader();

            while (reader.Read())
            {



               Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14} {15} {16} {17} {18} {19} {20} {21} {22}{23}{24}{25}{26}{27}{28}{29}{30}{31}{32}{33}{34}{35}{36}",
                    reader.GetValue(1), reader.GetValue(2), reader.GetValue(3),reader.GetValue(4),reader.GetValue(5),
                    reader.GetDateTime(6).ToShortDateString(),reader.GetValue(7),reader.GetValue(8),
                    reader.GetValue(9),reader.GetValue(10), reader.GetValue(11), reader.GetValue(12),
                    reader.GetValue(13),reader.GetValue(14),reader.GetValue(15), reader.GetValue(16),
                    reader.GetValue(17),reader.GetValue(18), reader.GetValue(19), reader.GetValue(20), 
                    reader.GetValue(21), reader.GetValue(22), reader.GetValue(23), reader.GetValue(24), 
                    reader.GetValue(25), reader.GetValue(26), reader.GetValue(27), reader.GetValue(28),
                    reader.GetValue(29), reader.GetValue(30), reader.GetValue(31), reader.GetValue(32),
                    reader.GetValue(33), reader.GetValue(34), reader.GetValue(35), reader.GetValue(36), 
                    reader.GetValue(37));




              
                Funcionario Cadfuncionario = new Funcionario();

                Cadfuncionario.nome = reader.GetValue(1).ToString();
                Cadfuncionario.sexo = reader.GetValue(2).ToString();
                Cadfuncionario.setor = reader.GetValue(3).ToString();
                Cadfuncionario.estadocivil = reader.GetValue(4).ToString();
                Cadfuncionario.numdoc = reader.GetValue(5).ToString();
                Cadfuncionario.nascimento =Convert.ToDateTime( reader.GetValue(6).ToString());
                Cadfuncionario.nomepai = reader.GetString(7);
                Cadfuncionario.nomemae = reader.GetString(8);
                Cadfuncionario.cep = reader.GetString(9);
                Cadfuncionario.endereco = reader.GetString(10);
                Cadfuncionario.cidade = reader.GetString(11);
                Cadfuncionario.uf = reader.GetString(12);
                Cadfuncionario.naturalidade = reader.GetString(13);
                Cadfuncionario.escolaridade = reader.GetString(14);
                Cadfuncionario.cpf = Limparcpf(reader.GetString(15));
                Cadfuncionario.bairro = reader.GetString(16);
                Cadfuncionario.obs = reader.GetString(17);
                Cadfuncionario.ultimaatualizacao = reader.GetDateTime(18);
                Cadfuncionario.admissao = Convert.ToString(reader.GetValue(19));
                Cadfuncionario.inativo = reader.GetBoolean(20);

                if (reader.GetValue(21) != null)
                {


                    Cadfuncionario.salariobase = 0;

                }
                else
                {
                    Cadfuncionario.salariobase = reader.GetDecimal(21);

                }


                Cadfuncionario.pontos = Convert.ToString( reader.GetValue(22));
                Cadfuncionario.banco = Convert.ToString( reader.GetValue(23));
                
                Cadfuncionario.aniversario =Convert.ToString( reader.GetValue(25));
              
                Cadfuncionario.cargo =Convert.ToString( reader.GetValue(27));
                Cadfuncionario.pis = Convert.ToString(reader.GetValue(28));
                Cadfuncionario.tituloeleitor = Convert.ToString(reader.GetValue(29));
                Cadfuncionario.ctpsserie = Convert.ToString(reader.GetValue(30));
                Cadfuncionario.ctps = Convert.ToString(reader.GetValue(31));
                Cadfuncionario.telefone = Convert.ToString(reader.GetValue(32));
                Cadfuncionario.celular = Convert.ToString(reader.GetValue(33));
                Cadfuncionario.nomeconjuge = Convert.ToString(reader.GetValue(34));
               Cadfuncionario.cpfconjuge =Convert.ToString( reader.GetValue(35));
                Cadfuncionario.substituto = Convert.ToString(reader.GetValue(37));

                   









            }





        }

        static long Limparcpf(String cpf)
        {
            if (!cpf.Equals(""))
            {
                string cpfreplaced = cpf.Replace(".", "");
                cpfreplaced = cpfreplaced.Replace("-", "");
                return Convert.ToInt64(cpfreplaced);
            }
            else
            {
                return 0;

            }
        }
    }
}
