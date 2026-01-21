namespace crediarioW.Models;

using System;

public class Client
{
	public Guid Id { get; private set; }
	public string? ClientName { get; private set; }
	public string? Cpf { get; private set; }
	public string? Phone { get; private set; }
	public string? Adress { get; private set; }

	public Client() {}

    public Client(Guid Id, string name, string cpf, string phone, string adress)
	{
		Id = Guid.NewGuid();
		ClientName = name;
		Cpf = cpf ?? null;
		Phone = phone ?? null;
		Adress = adress ?? null;
	}
}
