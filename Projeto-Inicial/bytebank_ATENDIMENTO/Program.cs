using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Atendimento;
using bytebank_ATENDIMENTO.bytebank.Util;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

#region Exemplos Arrays em C#

#region amostra
Array amostra = Array.CreateInstance(typeof(double), 5);
amostra.SetValue(5.9, 0);
amostra.SetValue(1.8, 1);
amostra.SetValue(7.1, 2);
amostra.SetValue(10, 3);
amostra.SetValue(6.9, 4);
#endregion

//TestaArrayInt();
//TestaBuscarPalavra();
//TestaMediana(amostra);
//TestaArrayDeContasCorrentes();

void TestaArrayInt()
{
    int[] idades = new int[5];
    idades[0] = 30;
    idades[1] = 40;
    idades[2] = 17;
    idades[3] = 21;
    idades[4] = 18;

    Console.WriteLine($"Tamanho do Array {idades.Length}");

    int acumlador = 0;

    for (int i = 0; i < idades.Length; i++)
    {
        int idade = idades[i];
        Console.WriteLine($"Indice [{i}] = {idade}");

        acumlador += idade;
    }

    var media = acumlador / idades.Length;
    Console.WriteLine($"Média = {media}");
}

void TestaBuscarPalavra()
{
    string[] arrayDePalavras = new string[5];

    for (var i = 0; i < arrayDePalavras.Length; i++)
    {
        Console.Write($"Digite a {i + 1}º Palavra: ");
        arrayDePalavras[i] = Console.ReadLine();
    }

    Console.Write($"Digite a Palavra a ser encontrada: ");
    var busca = Console.ReadLine();

    foreach (var palavra in arrayDePalavras)
    {
        if (palavra.Equals(arrayDePalavras))
        {
            Console.Write($"Palavra encontrada: {busca}");
            break;
        }
    }
}

void TestaMediana(Array array)
{
    if (array == null || array.Length == 0)
    {
        Console.WriteLine("Array para cálculo da mediana está vazio ou nulo.");
    }

    double[] numerosOrdenados = (double [])array.Clone();
    Array.Sort(numerosOrdenados);

    int tamanho = numerosOrdenados.Length;
    int meio = tamanho / 2;

    double mediana = numerosOrdenados[meio];
    Console.WriteLine($"Mediana = {mediana}");
}

void TestaArrayDeContasCorrentes()
{
    ListaDeContasCorrentes listaDeContas = new ListaDeContasCorrentes();
    listaDeContas.Adicionar(new ContaCorrente(874, "5679787-A"));
    listaDeContas.Adicionar(new ContaCorrente(874, "5679787-B"));
    listaDeContas.Adicionar(new ContaCorrente(874, "5679787-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "5679787-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "5679787-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "5679787-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "5679787-C"));

    var contaLeonardo = new ContaCorrente(963, "5679787-C");
    listaDeContas.Adicionar(contaLeonardo);
    //listaDeContas.ExibeLista();
    //Console.WriteLine("=========================");
    //listaDeContas.Remover(contaLeonardo);
    //listaDeContas.ExibeLista();

    for (int i = 0; i < listaDeContas.Tamanho; i++)
    {
        ContaCorrente conta = listaDeContas[i];

        Console.WriteLine($"Indice [{i}] = {conta.Conta}/{conta.Numero_agencia}");
    }
}

#endregion

new ByteBankAtendimento().AtendimentoCliente();

#region Métodos Disponíveis

List<ContaCorrente> _listaDeContas2 = new List<ContaCorrente>()
{
    new ContaCorrente(874, "123456-A"),
    new ContaCorrente(874, "123456-B"),
    new ContaCorrente(874, "123456-C"),
};

List<ContaCorrente> _listaDeContas3 = new List<ContaCorrente>()
{
    new ContaCorrente(951, "123456-D"),
    new ContaCorrente(962, "123456-E"),
    new ContaCorrente(973, "123456-F"),
};

_listaDeContas2.AddRange(_listaDeContas3);
_listaDeContas2.Reverse();

for (int i = 0; i < _listaDeContas2.Count; i++)
{
    Console.WriteLine($"Indice[{i}] = conta [{_listaDeContas2[i].Conta}]");
}

var range = _listaDeContas3.GetRange(0, 1);

for (int i = 0; i < range.Count; i++)
{
    Console.WriteLine($"Indice[{i}] = conta [{_listaDeContas2[i].Conta}]");
}

#endregion

#region Classe Genérica

//Generic<int> teste1 = new Generic<int>();
//teste1.MostrarMensagem(10);

//Generic<string> teste2 = new Generic<string>();
//teste2.MostrarMensagem("Olá Mundo!");

//public class Generic<T>
//{
//    public void MostrarMensagem(T t)
//    {
//        Console.WriteLine($"Exibindo {t}");
//    }
//}

#endregion

