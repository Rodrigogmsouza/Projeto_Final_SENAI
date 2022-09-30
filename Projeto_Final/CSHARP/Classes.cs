using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Final.CSHARP
{
    public class pessoa
    {
        public string nivacesso { get; set; }
        public string cpf { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string senha { get; set; }
    }

    public class turma
    {
        public string idturma { get; set; }
        public string nome_curso { get; set; }
        public string turno { get; set; }
        public string idsala { get; set; }
        public string idprofe { get; set; }
    }

    public class sala
    {
        public string idsala { get; set; }
        public string numsala { get; set; }
    }

    public class matricula
    {
        public string idmatricula { get; set; }
        public string idaluno { get; set; }
        public string idturma { get; set; }
    }
    
    


    public class setor
    {
        public string idsetor { get; set; }
        public string nomesetor { get; set; }

    }
}