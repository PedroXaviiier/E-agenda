namespace E_agenda
{
    public class Contato
    {
        public string Nome;
        public string Telefone;
        public string Email;
        public string Empresa;
        public string Cargo;

        public Contato(string nome, string telefone, string email, string empresa, string cargo)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Empresa = empresa;
            Cargo = cargo;
        }

        public Contato()
        {

        }

        public override string ToString()
        {
            return $"\nNome: {Nome}" +
                    $"\n{Cargo} da {Empresa}" +
                    $"\nTelefone: {Telefone}" +
                    $"\nEmail: {Email}";
        }
    }
}
