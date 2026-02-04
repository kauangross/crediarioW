namespace crediarioW.Models;

using System;
using System.ComponentModel.DataAnnotations;

public class Client
{
	[Required]
	public Guid Id { get; private set; }
	public string? ClientName { get; private set; }
	public string? Cpf { get; private set; }
	public string? Phone { get; private set; }
	public string? Adress { get; private set; }
    public ICollection<Venda>? Vendas { get; private set; }

    public Client() {}

    public Client(string name, string cpf, string phone, string adress)
	{
		Id = Guid.NewGuid();
		ClientName = name;
		Cpf = cpf ?? null;
		Phone = phone ?? null;
		Adress = adress ?? null;
	}
}
