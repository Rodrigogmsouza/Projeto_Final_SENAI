using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto_Final.CSHARP;

namespace Projeto_Final.CSHARP
{
    public class BancoDeDados
    {
        private static MySqlConnection conn;
        private static string server;
        private static string database;
        private static string uid;
        private static string password;

        //Constructor
        public static void DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private static void Initialize()
        {
            //server = "localhost";
            server = "10.200.119.241";
            //database = "connectcsharptomysql";
            database = "rodrigo_pf";
            //uid = "username";
            uid = "admin";
            //password = "password";
            password = "senai";
            string myConnectionString;
            myConnectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                //conn.Open();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                //MessageBox.Show(ex.Message);
            }
        }

        //open connection to database
        private static bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }

        }

        //Close connection
        private static bool CloseConnection()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //registro aluno
        public static void Registro_Pessoa(pessoa Pessoa)
        {
            string query = "INSERT INTO `pessoa`(`cpf`, `nome`, `email`, `telefone`, `senha`, `nivel_acesso`) VALUES ('" + Pessoa.cpf + "','" + Pessoa.nome + "','" + Pessoa.email + "','" + Pessoa.telefone + "','" + Pessoa.senha + "','" + Pessoa.nivacesso + "')";
            //open connection
            if (OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, conn);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                CloseConnection();
            }
        }

        public static int CountPessoa()
        {

            string query = "SELECT Count(*) FROM pessoa";
            int Count = -1;

            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);

                Count = int.Parse(cmd.ExecuteScalar() + "");

                CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        public static List<pessoa> Listagem_Pessoa()
        {
            string query = "SELECT cpf, nome FROM pessoa";

            //Create a list to store the result
            List < pessoa > listapessoa = new List<pessoa>();

            //Open connection
            if (OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, conn);
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
                CloseConnection();

                //return list to be displayed
                return listapessoa;
            }
            else
            {
                return listapessoa;
            }
        }




    }
}