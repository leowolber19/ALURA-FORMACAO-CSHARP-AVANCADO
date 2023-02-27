using ByteBankIO;

partial class Program
{
    static void Main(string[] args)
    {
        //var enderecoDoArquivo = "contas.txt";

        //using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        //{
        //    var leitor = new StreamReader(fluxoDeArquivo);

        //    while (!leitor.EndOfStream)
        //    {
        //        var linha = leitor.ReadLine();

        //        var contaCorrente = ConverterStringParaContaCorrente(linha);

        //        var msg = $" Olá {contaCorrente.Titular.Nome}, seus dados são: \n Conta Nº {contaCorrente.Numero}, Agência Nº {contaCorrente.Agencia}, Saldo R$ {contaCorrente.Saldo} \n\n";

        //        Console.WriteLine(msg);
        //    }
        //}

        //CriarArquivo();
        //CriarArquivoComWriter();
        //TestaEscrita();

        //var caminhoNovoArquivo = "TestaEscrita.txt";

        //using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        //using (var escritor = new StreamWriter(fluxoDeArquivo))
        //{
        //    escritor.WriteLine(true);
        //    escritor.WriteLine(false);
        //    escritor.WriteLine(454545454545);
        //}

        //EscritaBinaria();
        //LeituraBinaria();
        //UsarStreamDeEntrada();

        var linhas = File.ReadAllLines("contas.txt");
        //Console.WriteLine(linhas.Length);
        //foreach (var line in linhas) 
        //{
        //    Console.WriteLine(line);
        //}

        Console.WriteLine("\nAplicação Finalizada...");
        Console.ReadLine();
    }

    static ContaCorrente ConverterStringParaContaCorrente(string linha)
    {

        var listaLinha = linha.Split(";");

        var agencia = listaLinha[0];
        var numero = listaLinha[1];
        var saldo = listaLinha[2].Replace(".", ",");
        var nomeTitular = listaLinha[3];

        var titular = new Cliente()
        {
            Nome = nomeTitular
        };

        var resultado = new ContaCorrente(int.Parse(agencia), int.Parse(numero));

        resultado.Depositar(double.Parse(saldo));
        resultado.Titular = titular;

        return resultado;
    }
}