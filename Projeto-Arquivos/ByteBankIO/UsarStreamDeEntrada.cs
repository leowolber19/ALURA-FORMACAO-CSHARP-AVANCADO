using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

partial class Program
{
    static void UsarStreamDeEntrada()
    {
        using (var fluxoDeArquivo = Console.OpenStandardInput())
        using (var fs = new FileStream("EntradaConsole.txt", FileMode.Create))
        {
            var buffer = new byte[1024]; // 1KB

            while (true) 
            {
                var bytesLidos = fluxoDeArquivo.Read(buffer, 0, 1024);

                fs.Write(buffer, 0, bytesLidos);
                fs.Flush();

                Console.WriteLine($"Bytes lidos na console: {bytesLidos}");
            }
        }
    }
}
