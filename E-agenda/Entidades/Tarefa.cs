using System;
using System.Collections.Generic;

namespace E_agenda
{
    public class Tarefa
    {
        public enum Prioridade
        {
            Alta, Normal, Baixa
        }

        public string Titulo;
        public Prioridade NivelPrioridade;
        public List<Item> Itens;
        public DateTime DataDeCriacao;
        public DateTime DataDeConclusao;
        public double PercentualDeConclusao;

        public Tarefa()
        {

        }

        public Tarefa(string titulo, Prioridade nivelPrioridade)
        {
            Titulo = titulo;
            NivelPrioridade = nivelPrioridade;
            Itens = new();
            DataDeCriacao = DateTime.Now;
            PercentualDeConclusao = 0;
        }

        internal void AdicionarItem(Item item)
        {
            Itens.Add(item);
        }

        public void VerificarConclusao()
        {
            var percItem = 100 / Itens.Count;

            foreach(var item in Itens)
                
                if (item.Concluido == true)
                {
                    PercentualDeConclusao += percItem;
                }
        }




    }
}
