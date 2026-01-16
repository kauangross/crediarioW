namespace crediarioW.Models;

using System;

public class Client
{
	public Guid Id { get; }
	public string ClientName { get; }
	public string? Cpf { get; private set; }
	public string? Phone { get; private set; }
	public string? Adress { get; private set; }

    public Client(Guid Id, string name, string cpf, string phone, string adress)
	{
		Id = Guid.NewGuid();
		ClientName = name;
		Cpf = cpf ?? null;
		Phone = phone ?? null;
		Adress = adress ?? null;
	}
}
