using System;


namespace E_agenda
{
    public class Compromisso
    {
        public string Assunto;
        public Contato Contato;
        public string Local;
        public DateTime Data;
        public string HoraInicio;
        public string HoraTermino;
        

        public Compromisso(string assunto, string local, DateTime data, string horaInicio, string horaTermino, Contato contato)
        {
            Assunto = assunto;
            Contato = contato;
            Local = local;
            Data = data;
            HoraInicio = horaInicio;
            HoraTermino = horaTermino;
            
        }

        public Compromisso()
        {

        }

        public override string ToString()
        {
            return $"\nAssunto: {Assunto}" +
                $"\nLocal: {Local}" +
                $"\nData: {Data}, das {HoraInicio} às {HoraTermino}" +
                $"\nContato: {Contato}";
        }
    }
}
