using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_agenda.Telas
{
    public class MenuItens : MenuBase<Item>
    {
        public Tarefa Tarefa { get; set; }

        public MenuItens()
        {
        }

        public override Item ObterEntidade()
        {
            Compartilhados.NovoMenu("Novo item da tarefa:");

            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            Console.WriteLine();

            Item item = new(descricao);

            return item;
        }
    }
}
