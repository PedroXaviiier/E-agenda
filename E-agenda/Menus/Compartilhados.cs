using System;

namespace E_agenda.Telas
{
    public static class Compartilhados
    {
        public static void NovoMenu(string titulo)
        {
            Console.Clear();

            MostrarTitulo(titulo);
        }

        public static void MostrarTitulo(string titulo)
        {
            Console.WriteLine(titulo);

            Console.WriteLine();
        }
    }
}
