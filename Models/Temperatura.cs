namespace Estufa.Models
{
    public class Temperatura
    {
        public int Id { get; set; }
        public double TemperaturaAtual { get; set; }  // Temperatura atual
        public double TemperaturaIdeal { get; set; }  // Temperatura ideal
        public DateTime UltimaMedicao { get; set; }  // Data e hora da última medição
    }
}