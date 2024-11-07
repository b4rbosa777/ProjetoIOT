namespace Estufa.Models
{
    public class Umidade
    {
        public int Id { get; set; }
        public double NivelAtual { get; set; }  // Nível de umidade atual
        public double NivelIdeal { get; set; }  // Nível ideal de umidade
        public DateTime UltimaMedicao { get; set; }  // Data e hora da última medição
    }
}
