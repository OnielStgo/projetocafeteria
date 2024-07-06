using Repo;


namespace Model {
    public class Funcionario {
        public int IdFuncionario { get; set; }
        public string Nome { set; get; }
        public string Idade { set; get; }
        public string Cpf { set; get; }
        public string Telefone { set; get; }

        public Funcionario() {}

        public Funcionario(string nome, string idade, string cpf, string telefone) {
            Nome = nome;
            Idade = idade;
            Cpf = cpf;
            Telefone = telefone;
            ListFuncionario.Criar(this);
        }

        public static List<Funcionario> Sincronizar() {
            return ListFuncionario.Sincronizar();
        }

        public static List<Funcionario> ListarFuncionario() {
            return ListFuncionario.funcionarios;
        }

        public static void AlterarFuncionario(
            int indice,
            string nome,
            string idade,
            string cpf,
            string telefone
        ){  
            ListFuncionario.Update(indice, nome, idade, cpf, telefone);
        }

        public static void DeletarFuncionario(int indice) {
            ListFuncionario.Delete(indice);
        }

    }
}















/*
namespace Model {
    public class Pessoa {
        public int Id { get; set; }
        public string Titulo { set; get; }
        public string Data { set; get; }
        public string Hora { set; get; }
        public string Concluida { set; get; }

        public Pessoa() {}

        public Pessoa(string titulo, string data, string hora) {
            Titulo = titulo;
            Data = data;
            Hora = hora;
            Concluida = "Não";

            ListPessoa.Criar(this);
        }

        public static List<Pessoa> Sincronizar() {
            return ListPessoa.Sincronizar();
        }

        public static List<Pessoa> ListarPessoa() {
            return ListPessoa.pessoas;
        }

        public static void AlterarPessoa(
            int indice,
            string titulo,
            string data,
            string hora,
            string concluida
        ){  
            ListPessoa.Update(indice, titulo, data, hora, concluida);
        }

        public static void DeletarPessoa(int indice) {
            ListPessoa.Delete(indice);
        }

        // public void Apresentar() {
        //     Console.WriteLine($"Olá, meu nome é {Nome}, Idade: {Idade}");
        // }
    }
}

*/









/*
using Repo;
namespace Programa {

  public class Tarefa {
    public string Titulo { set; get; }
    public string Data { set; get; }
    public string Hora { set; get; }
    public bool Concluida { set; get; }
    public Tarefa(string titulo, string data, string hora) {
      Titulo = titulo;
      Data = data;
      Hora = hora;
      Concluida = false;  
      RepoTarefa.tarefas.Add(this);
    }

    public static void MudarStadoDaTarefa(int indice) {
        Tarefa tarefa = RepoTarefa.tarefas[indice];

        tarefa.Concluida = tarefa.Concluida ? false : true;
        RepoTarefa.tarefas[indice] = tarefa;
    }

    public static List<Tarefa> Listar() {
      return RepoTarefa.tarefas;
    }

    public static void Alterar(int indice, string titulo, string data, string hora, bool concluida) {
      Tarefa tarefa = RepoTarefa.tarefas[indice];
      tarefa.Titulo = titulo;
      tarefa.Data = data;
      tarefa.Hora = hora;
      tarefa.Concluida = concluida;

      RepoTarefa.tarefas[indice] = tarefa;      
    }
    public static void Deletar(int indice) {
      RepoTarefa.tarefas.RemoveAt(indice);
    }
  }
}
*/
















/*
using Repo;

namespace Model {
    public class Pessoa {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }

        public Pessoa() {}

        public Pessoa(string nome, int idade, string cpf) {
            Nome = nome;
            Idade = idade;
            Cpf = cpf;

            ListPessoa.Criar(this);
        }

        public static List<Pessoa> Sincronizar() {
            return ListPessoa.Sincronizar();
        }

        public static List<Pessoa> ListarPessoa() {
            return ListPessoa.pessoas;
        }

        public static void AlterarPessoa(
            int indice,
            string nome,
            int idade,
            string cpf
        ){  
            ListPessoa.Update(indice, nome, idade, cpf);
        }

        public static void DeletarPessoa(int indice) {
            ListPessoa.Delete(indice);
        }

        public void Apresentar() {
            Console.WriteLine($"Olá, meu nome é {Nome}, Idade: {Idade}");
        }
    }
}
*/




/*

CREATE TABLE tarefas (
     id INT AUTO_INCREMENT PRIMARY KEY,
     titulo VARCHAR(255) NOT NULL,
     data VARCHAR(255) NOT NULL,
     hora VARCHAR (255) NOT NULL,
     concluida VARCHAR (255) NOT NULL,
);
 

 INSERT INTO tarefas (titulo, data, hora, concluida) VALUES ('Tarefa1', '01/01/2024', '01:00', 'Não');

 INSERT INTO tarefas (titulo, data, hora, concluida) VALUES ('Tarefa2', '02/02/2024', '02:00', 'Não');

 INSERT INTO tarefas (titulo, data, hora, concluida) VALUES ('Tarefa3', '03/03/2024', '03:00', 'Não');

 INSERT INTO tarefas (titulo, data, hora, concluida) VALUES ('Tarefa4', '04/04/2024', '04:00', 'Não');

*/