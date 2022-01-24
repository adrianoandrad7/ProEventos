

namespace ProEventos.API.Models
{
    public class Evento
    {
        public int EventoId { get; private set; }
        public string Local { get; private set; }
        public string DataEvento { get; private set; }
        public string Tema { get; private set; }
        public int QtdPessoas { get; private set; }
        public string Lote { get; private set; }
        public string ImagemURL {get; private set; }

    }
}