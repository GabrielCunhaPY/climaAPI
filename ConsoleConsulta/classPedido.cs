using System;

namespace restaurante
{
    public class Pedidos
    {
        public string NomeCliente { get; set; }
        public decimal Valor { get; set; }
        public string Cidade { get; set; }
        public decimal Temperatura { get; set; }

        public Pedidos(string nomeCliente, decimal valor, string cidade, decimal temperatura)
        {
            NomeCliente = nomeCliente;
            Valor = valor;
            Cidade = cidade;
            Temperatura = temperatura;
        }

        public void ExibirInfo()
        {
            Console.WriteLine("----- Informações do Pedido -----");
            Console.WriteLine($"Nome do Cliente: {this.NomeCliente}");
            Console.WriteLine($"Valor do Pedido: {Valor}");
            Console.WriteLine($"Cidade de Entrega: {Cidade}");
            Console.WriteLine($"Temperatura na Cidade: {Temperatura} °C");
            Console.WriteLine("-----");
        }
    }
}