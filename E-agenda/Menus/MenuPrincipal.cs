using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_agenda.Telas
{
    public class MenuPrincipal
    {

        static MenuTarefas telaTarefas = new();
        static MenuContatos telaContatos = new();
        static MenuCompromissos telaCompromissos = new(telaContatos);

        public void Menu()
        {
            string opcao = "";

            while (opcao != "s")
            {
                Compartilhados.NovoMenu("E-agenda:");

                Console.WriteLine("Digite 1 para acessar o menu de Tarefas" +
                    "\n2 para menu de Contatos" +
                    "\n3 para menu de Compromissos" +
                    "\ns para Sair");

                opcao = Console.ReadLine().ToLower();

                switch (opcao)
                {
                    case "s":
                        break;

                    default:
                        Console.WriteLine("Comando inválido, digite novamente!");
                        break;

                    case "1":
                        telaTarefas.Menu("Tarefas:");
                        break;

                    case "2":
                        telaContatos.Menu("Contatos: ");
                        break;

                    case "3":
                        telaCompromissos.Menu("Compromissos: ");
                        break;
                }
            }
        }

        public void Fechando(object sender, EventArgs e)
        {
            telaTarefas.repositorioBase.Salvar();
            telaContatos.repositorioBase.Salvar();
            telaCompromissos.repositorioBase.Salvar();
        }
    }
}
