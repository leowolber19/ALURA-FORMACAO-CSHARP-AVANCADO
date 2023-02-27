using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

partial class Program
{
    static void CriarArquivo()
    {
        var caminhoNovoArquivo = "contasExportadas.csv";

        using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        {
            var contaComoString = "456;7895;4785.45;Gustavo Santos";

            var encoding = Encoding.UTF8;

            var bytes = encoding.GetBytes(contaComoString);

            fluxoDeArquivo.Write(bytes, 0, bytes.Length);
        }
    }

    static void CriarArquivoComWriter()
    {
        var caminhoNovoArquivo = "contasExportadas2.csv";

        using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        using (var escritor = new StreamWriter(fluxoDeArquivo))
        {
            escritor.Write("456 7895 4785.45 Gustavo Santos");
        }
    }

    static void TestaEscrita()
    {
        var caminhoNovoArquivo = "teste.txt";

        using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        using (var escritor = new StreamWriter(fluxoDeArquivo))
        {
            for (int i = 0; i < 1000000; i++)
            {
                escritor.WriteLine($"Linha {i} ");
                escritor.Flush();

                Console.WriteLine($"Linha {i} foi escrita no arquivo. Tecle enter...");
                Console.ReadLine();
            }
        }
    }
}
