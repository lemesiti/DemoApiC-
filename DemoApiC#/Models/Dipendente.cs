

namespace DemoApiC_.Models
{
    public class Dipendente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public int eta { get; set; }

        public Dipendente() { }

        public Dipendente(int id, string nome, string cognome, int eta)
        {
            this.id = id;
            this.nome = nome;
            this.cognome = cognome;
            this.eta = eta;
        }


    }
}