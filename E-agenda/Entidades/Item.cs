using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_agenda
{
    public class Item
    {
        public string Descricao;
        public bool Concluido;
        public Tarefa tarefa;

        public Item()
        {

        }

        public Item(string descricao)
        {
            Descricao = descricao;
            Concluido = false;
            
        }

        public override string ToString()
        {
            return $"\n{Descricao}" +
                $"\nConcluído: {Concluido}";
                
        }
    }

    

}
