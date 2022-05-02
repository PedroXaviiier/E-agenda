using System;

namespace E_agenda.Telas
{
    public class MenuContatos : MenuBase<Contato>
    {
        public MenuContatos()
        {

        }

        public override Contato ObterEntidade()
        {
            Compartilhados.NovoMenu("Cadastrando novo contato: ");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("E-mail: ");
            string email = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Empresa: ");
            string empresa = Console.ReadLine();

            Console.Write("Cargo: ");
            string cargo = Console.ReadLine();

            Contato contato = new(nome, email, telefone, empresa, cargo);

            return contato;
        }
    }
}
