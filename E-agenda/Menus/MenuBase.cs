using E_agenda.Repositorios;
using System;


namespace E_agenda.Telas
{
    public abstract class MenuBase<T>
    {
        public RepositorioBase<T> repositorioBase = new();
        public static readonly string NomeEntidade = typeof(T).Name;

        public void Menu(string titulo)
        {
            string opcao = "";

            while (opcao != "s")
            {
                Compartilhados.NovoMenu(titulo);

                Console.WriteLine("Digite 1 para Cadastrar" +
                    "\n2 para Editar" +
                    "\n3 para Excluir" +
                    "\n4 para Visualizar" +
                    "\ns para Sair");

                opcao = Console.ReadLine().ToLower();

                switch (opcao)
                {
                    case "s": break;

                    default:
                        Console.WriteLine("Opção Inválida, Digite novamente!");
                        break;

                    case "1":
                        CadastrarEntidade();
                        break;

                    case "2":
                        EditarEntidade();
                        break;

                    case "3":
                        ExcluirEntidade();
                        break;

                    case "4":
                        VisualizarEntidades(input: true);
                        break;
                }
            }
        }

        private void EditarEntidade()
        {
            Compartilhados.NovoMenu($"Editando {NomeEntidade}");

            VisualizarEntidades(input: false);

            Console.Write($"Selecionar {NomeEntidade}: ");
            int indice = Convert.ToInt32(Console.ReadLine()) - 1;
            EditarEntidade(indice);
        }

        private void EditarEntidade(int indice)
        {
            T entidade = ObterEntidade();
            repositorioBase.AlterarEntidade(indice, entidade);
        }

        private void ExcluirEntidade()
        {
            Compartilhados.NovoMenu($"Excluindo {NomeEntidade}");

            VisualizarEntidades(input: false);

            Console.WriteLine($"Selecione o(a) {NomeEntidade} que deseja excluir: ");
            int indice = Convert.ToInt32(Console.ReadLine()) - 1;

            T entidade = repositorioBase.Entidades[indice];

            repositorioBase.RemoverEntidade(entidade);
        }

        public virtual void VisualizarEntidades(bool input)
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
        }

        public void CadastrarEntidade()
        {
            repositorioBase.InserirEntidade(ObterEntidade());
        }

        public abstract T ObterEntidade();
    }
}

