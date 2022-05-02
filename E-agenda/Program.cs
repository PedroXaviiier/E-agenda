using E_agenda.Telas;
using System;

namespace E_agenda
{
    internal class Program
    {

        public static MenuPrincipal MenuPrincipal = new();
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += MenuPrincipal.Fechando;

            MenuPrincipal.Menu();
        }
    }
}
