using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

partial class Program
{
    static void EscritaBinaria()
    {
        using (var fluxoDeArquivo = new FileStream("contaCorrente.txt", FileMode.Create))
        using (var escritor = new BinaryWriter(fluxoDeArquivo))
        {
            escritor.Write(456);
            escritor.Write(546544);
            escritor.Write(4000.53);
            escritor.Write("Leonardo Wolber");
        }
    }

    static void LeituraBinaria()
    {
        using (var fluxoDeArquivo = new FileStream("contaCorrente.txt", FileMode.Open))
        using (var leitor = new BinaryReader(fluxoDeArquivo))
        {
            var agencia = leitor.ReadInt32();
            var numero = leitor.ReadInt32();
            var saldo = leitor.ReadDouble();
            var titular = leitor.ReadString();

            Console.WriteLine($"Olá {titular}, seus dados: {agencia}/{numero} R$ {saldo}");
        }
    }
}
