namespace crediarioW.Services;

using System;
using crediarioW.Models;

public class ClientService
{ 
    public Client CreateClient(
        Guid Id,
        string ClientName,
        string Cpf,
        string Phone,
        string Adress)
    {
        if(ClientName != null && ClientName.Length < 3)
            throw new ArgumentException("O nome do cliente deve ter pelo menos 3 caracteres.", nameof(ClientName));

        Client client = new Client(Id, ClientName, Cpf, Phone, Adress);

        return client;
    }
}
