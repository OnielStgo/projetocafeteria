using Repo;


namespace Model {
    public class PedidoProduto {
        public int IdPed_Prod { set; get; }
        public int IdPedido { set; get; }
        public int IdProduto { set; get; }
        public int Quantidade { set; get; }
        public decimal Total { set; get; }

        public PedidoProduto() {}

        public PedidoProduto(int idPedido, int idproduto, int quantidade, decimal total) {
            IdPedido = idPedido;
            IdProduto = idproduto;
            Quantidade = quantidade;
            Total = total;
            
            // ListPedidoProduto.Criar(this);
        }

        public static List<PedidoProduto>  ObterDetalhesDeUmPedido(int idPedido){
            return ListPedidoProduto.ObterDetalhesDeUmPedido(idPedido);
        }


        // public static List<PedidoProduto> Sincronizar() {
        //     return ListPedidoProduto.Sincronizar();
        // }

        // public static List<PedidoProduto> ListarPedidoProduto() {
        //     return ListPedidoProduto.pedidoprodutos;
        // }

        // public static void AlterarPedido(
        //     int indice,
        //     string idCliente,
        //     string idFuncionario,
        //     string cpf,
        //     string Total
        // ){  
        //     ListPedido.Update(indice, idCliente, idFuncionario, cpf, Total);
        // }

        // public static void DeletarPedido(int indice) {
        //     ListPedido.Delete(indice);
        // }

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
        //     Console.WriteLine($"Olá, meu idCliente é {IdCliente}, IdFuncionario: {IdFuncionario}");
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
        public string IdCliente { get; set; }
        public int IdFuncionario { get; set; }
        public string Cpf { get; set; }

        public Pessoa() {}

        public Pessoa(string idCliente, int idFuncionario, string cpf) {
            IdCliente = idCliente;
            IdPedido = idFuncionario;
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
            string idCliente,
            int idFuncionario,
            string cpf
        ){  
            ListPessoa.Update(indice, idCliente, idFuncionario, cpf);
        }

        public static void DeletarPessoa(int indice) {
            ListPessoa.Delete(indice);
        }

        public void Apresentar() {
            Console.WriteLine($"Olá, meu idCliente é {IdCliente}, IdPedido: {IdPedido}");
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