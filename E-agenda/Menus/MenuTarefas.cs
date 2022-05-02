using System;
using static E_agenda.Tarefa;

namespace E_agenda.Telas
{
    public class MenuTarefas : MenuBase<Tarefa>
    {
        private MenuItens telaItens;

        public MenuTarefas()
        {
            telaItens = new MenuItens();
        }

        public override Tarefa ObterEntidade()
        {
            Compartilhados.NovoMenu("Insira a tarefa:");

            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            Prioridade prioridade = ObterPrioridade();

            Tarefa tarefa = new(titulo, prioridade);

            telaItens.Tarefa = tarefa;
            AdicionarItensNaTarefa(tarefa, telaItens);

            return tarefa;
        }

        private static void AdicionarItensNaTarefa(Tarefa tarefa, MenuItens telaItens)
        {
            Compartilhados.NovoMenu("Insira os itens da tarefa: ");

            string opcao = "";

            while (opcao != "s")
            {
                Console.WriteLine("Digite 1 para Inserir novo item" +
                    "\ns para Sair");

                opcao = Console.ReadLine().ToLower();

                switch (opcao)
                {
                    case "s":
                        break;

                    default:
                        Console.WriteLine("Comando inválido,digite novamente!");
                        Console.ReadKey();
                        break;

                    case "1":
                        tarefa.AdicionarItem(telaItens.ObterEntidade());
                        break;
                }
            }
        }

        private Prioridade ObterPrioridade()
        {
            Console.Write("informe o nivel de prioridade: \n" +
                "\n1 para prioridade Baixa" +
                "\n2 para prioridade Normal" +
                "\n3 para prioridade Alta\n");

            string opcao = Console.ReadLine();

            while (opcao != "1" && opcao != "2" && opcao != "3")
            {
                Console.WriteLine("Opção Inválida, digite novamente!");
                return ObterPrioridade();
            }

            switch (opcao)
            {
                default: throw new Exception("exception bicho!");

                case "1":
                    return Prioridade.Baixa;

                case "2":
                    return Prioridade.Normal;

                case "3":
                    return Prioridade.Alta;
            }
        }

        public override void VisualizarEntidades(bool input)
        {
            string opcao = "";

            while (opcao != "s")
            {
                Compartilhados.NovoMenu($"Lista de {NomeEntidade}");

                for (int i = 0; i < repositorioBase.Entidades.Count; i++)
                {
                    Console.WriteLine($"{NomeEntidade} {i + 1}\n{repositorioBase.Entidades[i]}\n");
                }

                if (input)
                {
                    Console.ReadKey();
                }

                Console.WriteLine("Selecionar a tarefa para ver seus itens" +
                                "\ns para Sair");

                opcao = Console.ReadLine().ToLower();

                if (opcao == "s")
                    break;

                Compartilhados.NovoMenu("Opções de itens");

                Tarefa tarefa = repositorioBase.Entidades[Convert.ToInt32(opcao) - 1];

                Console.WriteLine($"{tarefa}");
                VisualizarItensDaTarefa(tarefa);

                OpcoesItem(tarefa);
            }
        }

        private static void VisualizarItensDaTarefa(Tarefa tarefa)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nItens não concluídos: ");
            Console.ResetColor();

            for (int i = 0; i < tarefa.Itens.Count; i++)
            {
                if (tarefa.Itens[i].Concluido == false)
                {
                    Console.WriteLine($"\nItem n{i + 1}\nDescrição: {tarefa.Itens[i]}\n");
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Itens concluídos: \n");
            Console.ResetColor();

            for (int i = 0; i < tarefa.Itens.Count; i++)
            {
                if (tarefa.Itens[i].Concluido == true)
                {
                    Console.WriteLine($"Item {i + 1}\nDescrição: {tarefa.Itens[i]}\n");
                }
            }
        }

        public void OpcoesItem(Tarefa tarefa)
        {
            Console.WriteLine("Digite 1 para Marcar item como concluído" +
                "\n2 para Excluir item" +
                "\n3 para Adicionar item" +
                "\ns para Sair");

            string opcaoAdd = Console.ReadLine();

            switch (opcaoAdd)
            {
                default:
                    break;

                case "1":
                    ConcluirItemDaTarefa(tarefa);
                    break;

                case "2":
                    ExcluirItemDaTarefa(tarefa);
                    break;

                case "3":
                    tarefa.AdicionarItem(telaItens.ObterEntidade());
                    break;


                case "s":
                    break;  
            }
        }

        private static void ConcluirItemDaTarefa(Tarefa tarefa)
        {
            Console.Write("\nSelecione o item para marcar como concluído: ");
            int indiceItem = Convert.ToInt32(Console.ReadLine()) - 1;
            tarefa.Itens[indiceItem].Concluido = true;

            tarefa.VerificarConclusao();
        }

        private static void ExcluirItemDaTarefa(Tarefa tarefa)
        {
            Console.Write("\nSelecione o item para excluir: ");
            int indiceItem = Convert.ToInt32(Console.ReadLine()) - 1;
            tarefa.Itens.RemoveAt(indiceItem);
        }
    }
}

