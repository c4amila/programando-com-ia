using System;

class Trabalhador
{
    public string? Nome { get; set; }
    public string? CPF { get; set; }
    public string? CEP { get; set; }
    public int NumeroDependentes { get; set; }
    public decimal SalarioBruto { get; set; }
    public decimal DescontoINSS { get; set; }
    public decimal TotalDescontosIRRF { get; set; }

    public decimal CalcularIRRF()
    {

        decimal salarioBase = SalarioBruto - DescontoINSS - (NumeroDependentes * 189.59m) - TotalDescontosIRRF;
        decimal irrf = 0;

        // Calcular IRRF
        if (salarioBase <= 1903.98m)
        {
            irrf = 0;
        }
        else if (salarioBase <= 2826.65m)
        {
            irrf = salarioBase * 0.075m - 142.80m;
        }
        else if (salarioBase <= 3751.05m)
        {
            irrf = salarioBase * 0.15m - 354.80m;
        }
        else if (salarioBase <= 4664.68m)
        {
            irrf = salarioBase * 0.225m - 636.13m;
        }
        else
        {
            irrf = salarioBase * 0.275m - 869.36m;
        }

        // Garantir que o IRRF não seja negativo
        return irrf > 0 ? irrf : 0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Trabalhador trabalhador = new Trabalhador();

        Console.Write("Digite o nome do trabalhador: ");
        trabalhador.Nome = Console.ReadLine();

        trabalhador.SalarioBruto = LerDecimal("Digite o salário bruto: ");
        trabalhador.DescontoINSS = LerDecimal("Digite o desconto do INSS: R$ ");
        trabalhador.NumeroDependentes = LerInt("Digite o número de dependentes: ");
        trabalhador.TotalDescontosIRRF = LerDecimal("Digite o valor total de descontos para dedução de IRRF: R$ ");

        Console.Write("Digite o CPF: ");
        trabalhador.CPF = Console.ReadLine();

        Console.Write("Digite o CEP: ");
        trabalhador.CEP = Console.ReadLine();

        // Calcular o IRRF
        decimal irrf = trabalhador.CalcularIRRF();

        // Exibir as informações do trabalhador no final
        Console.WriteLine("\n---------------------------");
        Console.WriteLine("\nINFORMAÇÕES DO TRABALHADOR:");
        Console.WriteLine($"Nome: {trabalhador.Nome}");
        Console.WriteLine($"Salário Bruto: {trabalhador.SalarioBruto:C}");
        Console.WriteLine($"Desconto do INSS: {trabalhador.DescontoINSS:C}");
        Console.WriteLine($"Número de Dependentes: {trabalhador.NumeroDependentes}");
        Console.WriteLine($"Total de Descontos para Dedução de IRRF: {trabalhador.TotalDescontosIRRF:C}");
        Console.WriteLine($"CPF: {trabalhador.CPF}");
        Console.WriteLine($"CEP: {trabalhador.CEP}");
        Console.WriteLine($"Imposto de Renda Retido na Fonte (IRRF): {irrf:C}");
    }

    // Método para ler valores decimais com validação
    static decimal LerDecimal(string mensagem)
    {
        decimal valor;
        while (true)
        {
            Console.Write(mensagem);
            if (decimal.TryParse(Console.ReadLine(), out valor))
            {
                break;
            }
            else
            {
                Console.WriteLine("Entrada inválida. Por favor, digite um número decimal.");
            }
        }
        return valor;
    }

    // Método para ler valores inteiros com validação
    static int LerInt(string mensagem)
    {
        int valor;
        while (true)
        {
            Console.Write(mensagem);
            if (int.TryParse(Console.ReadLine(), out valor))
            {
                break;
            }
            else
            {
                Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro.");
            }
        }
        return valor;
    }
}