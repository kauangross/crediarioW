namespace crediarioW.Models;

using System;

public class Venda
{
    public Guid Id { get; private set; }
    public Guid ClienteId { get; private set; }
	public Client Cliente { get; private set;  }
    
	public decimal ValorTotal { get; private set; }
	public DateTime DataVenda { get; private set; }
	public FormaPagamento Pagamento { get; private set; }


	public Venda() {}

    public Venda(Guid clientID, decimal valorTotal, FormaPagamento pagamento)
	{
        Id = Guid.NewGuid();
		ClienteId = clientID;
		DataVenda = DateTime.UtcNow;
		ValorTotal = valorTotal;
		Pagamento = pagamento;
	}
}
