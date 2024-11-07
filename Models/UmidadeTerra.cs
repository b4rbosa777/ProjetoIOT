namespace Estufa.Models
{
    public class UmidadeTerra
    {
        public int Id { get; set; }
        public double NivelAtual { get; set; }  // Nível de umidade do solo atual
        public double NivelIdeal { get; set; }  // Nível ideal de umidade do solo
        public DateTime UltimaMedicao { get; set; }  // Data e hora da última medição
    }
}
