using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InteracaoHTTP
{
    class Program
    {
        enum Menu { Requisicaotds = 1, RequisicaoUnica, Sair}
        
        static void Main(string[] args)
        {
            bool escolheuSair = false;

            while (escolheuSair == false)
            {
                Console.WriteLine("1 - Requisitar todas tarefas\n2 - Requisitar uma única tarefa\n3 - Sair");
                string coletaOpc = Console.ReadLine();
                int transformaOpc = int.Parse(coletaOpc);
                Menu escolha = (Menu)transformaOpc;
                if (transformaOpc > 0 && transformaOpc < 3)
                {
                    switch (escolha)
                    {
                        case Menu.Requisicaotds:
                            ReqLista();
                            break;
                        case Menu.RequisicaoUnica:
                            ReqUnica();
                            break;
                        case Menu.Sair:
                            escolheuSair = true;
                            break;
                    }
                }
                else
                {
                    escolheuSair = true;
                }
                Console.Clear();
            }
        }

        static void ReqLista()
        {
            Console.Clear();
            var requisicao = WebRequest.Create("https://jsonplaceholder.typicode.com/todos");
            requisicao.Method = "GET";

            using (var resposta = requisicao.GetResponse())
            {
                var stream = resposta.GetResponseStream();
                StreamReader leitor = new StreamReader(stream);
                object dados = leitor.ReadToEnd();

                List<Tarefa> tarefas = JsonConvert.DeserializeObject<List<Tarefa>>(dados.ToString());

                foreach (Tarefa tarefa in tarefas)
                {
                    tarefa.Exibir();
                }
              
                stream.Close();
                resposta.Close();

                Console.ReadLine();
            }
        }

        static void ReqUnica()
        {
            Console.Clear();
            Console.WriteLine("Digite o ID da tarefa desejada: ");
            string id = Console.ReadLine();   
            var requisicao = WebRequest.Create("https://jsonplaceholder.typicode.com/todos/"+id);
            requisicao.Method = "GET";

            using (var resposta = requisicao.GetResponse())
            {
                var stream = resposta.GetResponseStream();
                StreamReader leitor = new StreamReader(stream);
                object dados = leitor.ReadToEnd();

                Tarefa tarefa = JsonConvert.DeserializeObject<Tarefa>(dados.ToString());

                tarefa.Exibir();

                stream.Close();
                resposta.Close();

                Console.ReadLine();
            }
        }
    }
}
