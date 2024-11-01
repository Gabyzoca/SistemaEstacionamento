using System;
using System.Collections.Generic;

class Veiculo
{
    public string Placa { get; set; }
    public DateTime HoraEntrada { get; set; }

    public Veiculo(string placa)
    {
        Placa = placa;
        HoraEntrada = DateTime.Now; // Registra a hora de entrada
    }
}

class Estacionamento
{
    private List<Veiculo> veiculos = new List<Veiculo>();
    private const decimal ValorPorHora = 5.0m; // Valor cobrado por hora

    public void AdicionarVeiculo(string placa)
    {
        Veiculo veiculo = new Veiculo(placa);
        veiculos.Add(veiculo);
        Console.WriteLine($"Veículo com placa {placa} adicionado ao estacionamento.");
    }

    public void RemoverVeiculo(string placa)
    {
        Veiculo veiculo = veiculos.Find(v => v.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase));
        if (veiculo != null)
        {
            TimeSpan tempoEstacionado = DateTime.Now - veiculo.HoraEntrada;
            decimal valorCobrado = (decimal)Math.Ceiling(tempoEstacionado.TotalHours) * ValorPorHora; // Cálculo do valor
            veiculos.Remove(veiculo);
            Console.WriteLine($"Veículo com placa {placa} removido. Valor cobrado: R$ {valorCobrado:F2}");
        }
        else
        {
            Console.WriteLine($"Veículo com placa {placa} não encontrado.");
        }
    }

    public void ListarVeiculos()
    {
        if (veiculos.Count == 0)
        {
            Console.WriteLine("Nenhum veículo estacionado.");
        }
        else
        {
            Console.WriteLine("Veículos estacionados:");
            foreach (var veiculo in veiculos)
            {
                Console.WriteLine($"- Placa: {veiculo.Placa}, Hora de entrada: {veiculo.HoraEntrada}");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Estacionamento estacionamento = new Estacionamento();
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1 - Adicionar veículo");
            Console.WriteLine("2 - Remover veículo");
            Console.WriteLine("3 - Listar veículos");
            Console.WriteLine("0 - Sair");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite a placa do veículo: ");
                    string placaAdicionar = Console.ReadLine();
                    estacionamento.AdicionarVeiculo(placaAdicionar);
                    break;
                case "2":
                    Console.Write("Digite a placa do veículo a ser removido: ");
                    string placaRemover = Console.ReadLine();
                    estacionamento.RemoverVeiculo(placaRemover);
                    break;
                case "3":
                    estacionamento.ListarVeiculos();
                    break;
                case "0":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}
