using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace E_agenda.Repositorios
{
    public class RepositorioBase<T>
    {
        public List<T> Entidades;

        public RepositorioBase()
        {
            Entidades = Carregar();
        }

        public void InserirEntidade(T entidade)
        {
            Entidades.Add(entidade);
        }

        internal void RemoverEntidade(T entidade)
        {
            Entidades.Remove(entidade);
        }

        internal List<T> Carregar()
        {
            if (!File.Exists($"..//..//..//SaveState{typeof(T).Name}.xml"))
            {
                return new List<T>();
            }

            XmlSerializer reader = new(typeof(List<T>));
            StreamReader file = new($"..//..//..//SaveState{typeof(T).Name}.xml");
            List<T> lista = (List<T>)reader.Deserialize(file);
            file.Close();

            return lista;
        }

        internal void Salvar()
        {
            XmlSerializer writer = new(typeof(List<T>));
            var path = $"..//..//..//SaveState{typeof(T).Name}.xml";
            FileStream file = File.Create(path);

            writer.Serialize(file, Entidades);
            file.Close();
        }

        public void AlterarEntidade(int indice, T entidade)
        {
            Entidades[indice] = entidade;
        }
    }
}
