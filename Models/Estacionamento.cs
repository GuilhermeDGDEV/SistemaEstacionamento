namespace SistemaEstacionamento.Models;

public class Estacionamento(decimal precoInicial, decimal precoPorHora)
{
    private readonly decimal PrecoInicial = precoInicial;
    private readonly decimal PrecoPorHora = precoPorHora;
    private readonly List<string> Veiculos = [];

    public void AdicionarVeiculo()
    {
        Console.WriteLine("Digite a placa do veículo para estacionar:");
        var placa = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(placa))
        {
            Console.WriteLine("Placa inválida! Digite novamente");
            placa = Console.ReadLine();
        }
        Veiculos.Add(placa);
    }

    public void RemoverVeiculo()
    {
        Console.WriteLine("Digite a placa do veículo para remover:");

        string placa = Console.ReadLine();

        if (Veiculos.Any(x => x.Equals(placa, StringComparison.CurrentCultureIgnoreCase)))
        {
            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

            if (int.TryParse(Console.ReadLine(), out int horas))
            {
                decimal valorTotal = horas * PrecoPorHora + PrecoInicial;

                if (Veiculos.Remove(placa))
                {
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Erro ao remover placa");
                }
            }
            else
            {
                Console.WriteLine("Horas informadas inválidas");
            }
        }
        else
        {
            Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
        }
    }

    public void ListarVeiculos()
    {
        if (Veiculos.Count > 0)
        {
            Console.WriteLine("Os veículos estacionados são:");
            Console.WriteLine(string.Join("\n", Veiculos));
        }
        else
        {
            Console.WriteLine("Não há veículos estacionados.");
        }
    }
}
