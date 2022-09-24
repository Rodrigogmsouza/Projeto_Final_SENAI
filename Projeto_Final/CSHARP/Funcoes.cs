using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using Projeto_Final.CSHARP;

namespace Projeto_Final.CSHARP
{
    public class Funcoes
    {
        BancoDeDados Banco = new BancoDeDados();

        // registro aluno
        public static void Registro_Pessoa(pessoa Pessoa)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("INSERT INTO pessoa");
            sb.AppendLine("(cpf, nome, email, telefone, senha, nivel_acesso)");
            sb.AppendLine("VALUES ('" + Pessoa.cpf + "','" + Pessoa.nome + "','" + Pessoa.email + "',");
            sb.AppendLine("'" + Pessoa.telefone + "','" + Pessoa.senha + "','" + Pessoa.nivacesso + "')");
            //open connection
            if (BancoDeDados.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDeDados.conn);
                cmd.ExecuteReader();



                //close connection
                BancoDeDados.CloseConnection();
            }
        }

        // registro setor

        public static void Registro_Setor(setor Setor)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("INSERT INTO setor (nome_setor)");
            sb.AppendLine("VALUES ('" + Setor.nomesetor + "')");
            //open connection
            if (BancoDeDados.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDeDados.conn);
                cmd.ExecuteReader();
                //close connection
                BancoDeDados.CloseConnection();
            }
        }

        // registro sala
        public static void Registro_Sala(sala Sala)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("INSERT INTO sala (numero_sala)");
            sb.AppendLine("VALUES ('" + Sala.numsala + "')");
            //open connection
            if (BancoDeDados.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDeDados.conn);
                cmd.ExecuteReader();
                //close connection
                BancoDeDados.CloseConnection();
            }
        }

        // registro turma

        public static void Registro_Turma(turma Turma)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("INSERT INTO turma");
            sb.AppendLine("(nome_curso, turno, id_sala, id_profe)");
            sb.AppendLine("VALUES ('" + Turma.nome_curso + "','" + Turma.turno + "',");
            sb.AppendLine("'" + Turma.idsala + "','" + Turma.idprofe + "')");
            //open connection
            if (BancoDeDados.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDeDados.conn);
                cmd.ExecuteReader();
                //close connection
                BancoDeDados.CloseConnection();
            }
        }

        // matricula

        public static void Matricula(matricula Matricula)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("INSERT INTO matricula");
            sb.AppendLine("(id_aluno, id_turma)");
            sb.AppendLine("VALUES ('" + Matricula.idaluno + "','" + Matricula.idturma + "')");
            //open connection
            if (BancoDeDados.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDeDados.conn);
                cmd.ExecuteReader();



                //close connection
                BancoDeDados.CloseConnection();
            }
        }

        // listagem
        public static List<pessoa> Listagem_Pessoa()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT cpf, nome, email, telefone, nivel_acesso FROM pessoa");
            //Create a list to store the result
            List<pessoa> listapessoa = new List<pessoa>();

            //Open connection
            if (BancoDeDados.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDeDados.conn);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list

                while (dataReader.Read())
                {
                    pessoa listagempessoa = new pessoa();
                    listagempessoa.cpf = dataReader[0] + "";
                    listagempessoa.nome = dataReader[1] + "";
                    listagempessoa.email = dataReader[2] + "";
                    listagempessoa.telefone = dataReader[3] + "";
                    listagempessoa.nivacesso = dataReader[4] + "";

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

        // listagem ALUNOS
        public static List<pessoa> Listagem_Alunos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT cpf, nome FROM pessoa");
            sb.AppendLine("WHERE nivel_acesso = 'usuario'");
            //Create a list to store the result
            List<pessoa> listaalunos = new List<pessoa>();

            //Open connection
            if (BancoDeDados.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDeDados.conn);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list

                while (dataReader.Read())
                {
                    pessoa listagemalunos = new pessoa();
                    listagemalunos.cpf = dataReader[0] + "";
                    listagemalunos.nome = dataReader[1] + "";
                    listaalunos.Add(listagemalunos);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                BancoDeDados.CloseConnection();

                //return list to be displayed
                return listaalunos;
            }
            else
            {
                return listaalunos;
            }
        }

        // listagem SALAS
        public static List<sala> Listagem_Sala()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT id_sala, numero_sala FROM sala");
            //Create a list to store the result
            List<sala> listasalas = new List<sala>();

            //Open connection
            if (BancoDeDados.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDeDados.conn);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list

                while (dataReader.Read())
                {
                    sala salas = new sala();
                    salas.idsala = dataReader[0] + "";
                    salas.numsala = dataReader[1] + "";

                    listasalas.Add(salas);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                BancoDeDados.CloseConnection();

                //return list to be displayed
                return listasalas;
            }
            else
            {
                return listasalas;
            }
        }

        // listagem SETORES

        public static List<setor> Listagem_Setor()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT * FROM setor");
            //Create a list to store the result
            List<setor> listasetores = new List<setor>();

            //Open connection
            if (BancoDeDados.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDeDados.conn);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list

                while (dataReader.Read())
                {
                    setor setores = new setor();
                    setores.idsetor = dataReader[0] + "";
                    setores.nomesetor = dataReader[1] + "";

                    listasetores.Add(setores);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                BancoDeDados.CloseConnection();

                //return list to be displayed
                return listasetores;
            }
            else
            {
                return listasetores;
            }
        }

        // listagem TURMAS

        public static List<turma> Listagem_Turmas()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT * FROM turma");
            //Create a list to store the result
            List<turma> listaturma = new List<turma>();

            //Open connection
            if (BancoDeDados.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDeDados.conn);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list

                while (dataReader.Read())
                {
                    turma turmas = new turma();
                    turmas.idturma = dataReader[0] + "";
                    turmas.nome_curso = dataReader[1] + "";
                    turmas.turno = dataReader[2] + "";
                    turmas.idsala = dataReader[3] + "";
                    turmas.idprofe = dataReader[4] + "";

                    listaturma.Add(turmas);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                BancoDeDados.CloseConnection();

                //return list to be displayed
                return listaturma;
            }
            else
            {
                return listaturma;
            }
        }

        // listagem PROFESSORES
        public static List<pessoa> Listagem_Professor()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT cpf, nome FROM pessoa");
            sb.AppendLine("WHERE nivel_acesso = 'professor'");
            //Create a list to store the result
            List<pessoa> listaprofe = new List<pessoa>();

            //Open connection
            if (BancoDeDados.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDeDados.conn);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list

                while (dataReader.Read())
                {
                    pessoa listagemprofe = new pessoa();
                    listagemprofe.cpf = dataReader[0] + "";
                    listagemprofe.nome = dataReader[1] + "";

                    listaprofe.Add(listagemprofe);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                BancoDeDados.CloseConnection();

                //return list to be displayed
                return listaprofe;
            }
            else
            {
                return listaprofe;
            }
        }

        // listagem PROFESSORES por TURMA


        // login
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
                    int count = int.Parse(cmd.ExecuteScalar().ToString());

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

        // nivel de acesso
        public static string Nivel_acesso(pessoa usuario)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT nivel_acesso FROM pessoa");
            sb.AppendLine("WHERE cpf = '"+ usuario.cpf +"'");

            string nivel = "";

            //Open Connection
            if (BancoDeDados.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), BancoDeDados.conn);

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
    