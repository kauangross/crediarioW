namespace crediarioW.Models;

using System;
using System.ComponentModel.DataAnnotations;

public class Venda
{
	[Required]
    public Guid Id { get; private set; }
    [Required]
    public Guid ClienteId { get; private set; }
    [Required]
	public Client Cliente { get; private set;  } // Preciso? Se sim, preciso no dto?

    [Required]
    public decimal ValorTotal { get; private set; }
    [Required]
    public DateTime DataVenda { get; private set; }
    [Required]
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
