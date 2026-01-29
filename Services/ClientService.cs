namespace crediarioW.Services;

using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using crediarioW.Models;
using crediarioW.Dtos;
using crediarioW.Repository;

public class ClientService
{
    private readonly ClientRepository _clientRepository;
    public ClientService(ClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<ClientResponseDto> CreateClient(ClientRequestDto clientRequest)
    {
        if(clientRequest.ClientName != null && clientRequest.ClientName.Length < 3)
            throw new ArgumentException("O nome do cliente deve ter pelo menos 3 caracteres.", nameof(clientRequest.ClientName));

        Client client = new Client(clientRequest.ClientName, 
            clientRequest.Cpf, 
            clientRequest.Phone, 
            clientRequest.Address);

        await _clientRepository.AddAsync(client);

        return new ClientResponseDto(client.Id, client.ClientName, client.Cpf, client.Phone, client.Adress);
    }
}