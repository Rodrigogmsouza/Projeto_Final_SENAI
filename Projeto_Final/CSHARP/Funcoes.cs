using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace Projeto_Final.CSHARP
{
    public class Funcoes
    {
        BancoDeDados Banco = new BancoDeDados();

        //registro aluno
        public static void Registro_Pessoa(pessoa Pessoa)
        {
            string query = "INSERT INTO `pessoa`(`cpf`, `nome`, `email`, `telefone`, `senha`, `nivel_acesso`) VALUES ('" + Pessoa.cpf + "','" + Pessoa.nome + "','" + Pessoa.email + "','" + Pessoa.telefone + "','" + Pessoa.senha + "','" + Pessoa.nivacesso + "')";
            //open connection
            if (BancoDeDados.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, BancoDeDados.conn);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                BancoDeDados.CloseConnection();
            }
        }

        public static List<pessoa> Listagem_Pessoa()
        {
            string query = "SELECT cpf, nome FROM pessoa";

            //Create a list to store the result
            List<pessoa> listapessoa = new List<pessoa>();

            //Open connection
            if (BancoDeDados.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, BancoDeDados.conn);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list

                while (dataReader.Read())
                {
                    pessoa listagempessoa = new pessoa();
                    listagempessoa.cpf = dataReader[0] + "";
                    listagempessoa.nome = dataReader[1] + "";
                    listapessoa.Add(listagempessoa);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                BancoDeDados.CloseConnection();

                //return list to be displayed
                return listapessoa;
            }
            else
            {
                return listapessoa;
            }
        }

        public static bool Login(string cpf, string senha)
        {
            string query = "SELECT Count(*) FROM pessoa WHERE cpf = '" + cpf + "' AND Senha = '" + senha + "'";

            //Open connection
            if (BancoDeDados.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, BancoDeDados.conn);
                //Create a data reader and Execute the command
                try
                {
                    //Recebe o numero de usuários encontrados com os parametros enviados
                    int count = int.Parse(cmd.ExecuteScalar() + "");

                    //close Connection
                    BancoDeDados.CloseConnection();

                    //Se encontrou o usuário no BD seta a resposta para true
                    if (count > 0)
                    {
                        return true;
                    }
                    return false;

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static string Nivel_acesso(pessoa usuario)
        {

            string query = "SELECT nivel_acesso FROM pessoa WHERE cpf = '" + usuario.cpf + "'";

            string nivel = "";

            //Open Connection
            if (BancoDeDados.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, BancoDeDados.conn);

                //ExecuteScalar will return one value
                nivel = cmd.ExecuteScalar() + "";

                //close Connection
                BancoDeDados.CloseConnection();

                return nivel;
            }
            else
            {
                return nivel;
            }
        }
    }
}
    