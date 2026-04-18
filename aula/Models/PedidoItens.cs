using System;
using System.Collections.Generic;

public class Pedido
{
    public int Id { get; set; }
    public DateTime Data { get; set; }

    public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
}

public class ItemPedido
{
    public int Id { get; set; }
    public string Produto { get; set; }
    public int Quantidade { get; set; }

    public int PedidoId { get; set; }
    public Pedido Pedido { get; set; }
}