namespace crediarioW.Models.Entities;

using System;
using System.ComponentModel.DataAnnotations;

public class Client
{
	[Required]
	public Guid Id { get; private set; }
	public string? ClientName { get; private set; }
	public string? Cpf { get; private set; }
	public string? Phone { get; private set; }
	public string? Address { get; private set; }
    public ICollection<Sale>? Sales { get; private set; }

    public Client() {}

    public Client(string name, string cpf, string phone, string address)
	{
		Id = Guid.NewGuid();
		ClientName = name;
		Cpf = cpf ?? null;
		Phone = phone ?? null;
		Address = address ?? null;
	}
    public Client UpdateData(string? newClientName, string? newCpf, string? newPhone, string? newAddress)
    {
        if (newClientName != null && string.IsNullOrWhiteSpace(newClientName))
            throw new ArgumentException("Se for alterar o nome, ele não pode ser vazio.");

        if (!string.IsNullOrWhiteSpace(newClientName))
            this.ClientName = newClientName;

        if (!string.IsNullOrWhiteSpace(newCpf))
            this.Cpf = newCpf;

        if (!string.IsNullOrWhiteSpace(newPhone))
            this.Phone = newPhone;

        if (!string.IsNullOrWhiteSpace(newAddress))
            this.Address = newAddress;

        return this;
    }
}
