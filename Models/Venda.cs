namespace crediarioW.Models;

using System;

public class Venda
{
    public Guid Id { get; }
    public Guid ClienteId { get; }

	public decimal ValorTotal { get; }
	public DateTime DataVenda { get; }
	public FormaPagamento Pagamento { get; }

    public Venda(Guid clientID, decimal valorTotal, FormaPagamento pagamento)
	{
        Id = Guid.NewGuid();
		ClienteId = clientID;
		DataVenda = DateTime.Now;
		ValorTotal = valorTotal;

	}
}
