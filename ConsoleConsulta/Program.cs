using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Api;

namespace restaurante
{
    class Program
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static readonly ConsultarTemp _consultarTemp = new ConsultarTemp();

        static async Task Main(string[] args)
        {
            List<Pedidos> pedidos = new List<Pedidos>();

            Console.WriteLine("Informe seu pedido.");

            Console.WriteLine("Qual o nome do cliente?");
            string nomeCliente = Console.ReadLine();

            Console.WriteLine("Qual o valor do pedido?");
            decimal valor = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Qual a cidade da entrega?");
            string cidade = Console.ReadLine();

            decimal temperatura = await _consultarTemp.GetTempCidade(cidade);

            Pedidos pedido = new Pedidos(nomeCliente, valor, cidade, temperatura);
            pedidos.Add(pedido);

            if (pedido.Valor < 0)
            {
                pedido.ExibirInfo();
            }
        }
    }
}
