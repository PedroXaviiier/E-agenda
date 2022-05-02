using System;



namespace E_agenda.Telas
{
    public class MenuCompromissos : MenuBase<Compromisso>
    {
        public MenuContatos TelaContatos;

        public MenuCompromissos(MenuContatos telaContatos)
        {
            TelaContatos = telaContatos;
        }

        public override Compromisso ObterEntidade()
        {
            Compartilhados.NovoMenu("Cadastrando novo compromisso: ");

            TelaContatos.VisualizarEntidades(false);
            Console.Write("Selecione o contato do compromisso: ");

            Contato contato = TelaContatos.repositorioBase.Entidades[Convert.ToInt32(Console.ReadLine()) - 1];
            Console.WriteLine();

            Console.Write("Assunto: ");
            string assunto = Console.ReadLine();

            Console.Write("Local: ");
            string local = Console.ReadLine();

            Console.Write("Data: ");
            DateTime data = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Hora inicio: ");
            string horaI = Console.ReadLine();

            Console.Write("Hora término: ");
            string horaT = Console.ReadLine();

            Compromisso compromisso = new Compromisso(assunto, local, data, horaI, horaT, contato);

            return compromisso;
        }
    }
}
