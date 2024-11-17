namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verificar se a capacidade da suíte é maior ou igual ao número de hóspedes
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                // Lançar uma exceção caso a capacidade seja menor
                throw new Exception("A capacidade da suíte é menor do que o número de hóspedes.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes na reserva
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // Cálculo do valor da diária: DiasReservados x Suite.ValorDiaria
            decimal valorTotal = DiasReservados * Suite.ValorDiaria;

            // Aplicar desconto de 10% se os dias reservados forem 10 ou mais
            if (DiasReservados >= 10)
            {
                valorTotal -= valorTotal * 0.10m; // Desconto de 10%
            }

            return valorTotal;
        }
    }
}
