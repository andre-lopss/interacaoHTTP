using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteracaoHTTP
{
    class Tarefa
    {
        public int userId;
        public int id;
        public string title;
        public bool completed;

        public void Exibir()
        {
            Console.WriteLine("OBJETO TAREFA");
            Console.WriteLine($"User Id: {userId}");
            Console.WriteLine($"Id: {id}");
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Finalizou?: {completed}");
            Console.WriteLine("==================================================");
            Console.WriteLine("");

        }
    }
}
