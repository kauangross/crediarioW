namespace crediarioW.Services;

using crediarioW.Dtos;
using crediarioW.Models.Entities;
using crediarioW.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

public class ClientService
{
    private readonly ClientRepository _clientRepository;
    public ClientService(ClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<ClientResponseDto> CreateAsync(ClientRequestDto clientRequest)
    {
        if(clientRequest.ClientName != null && clientRequest.ClientName.Length < 3)
        { 
            throw new ArgumentException("O nome do cliente deve ter pelo menos 3 caracteres.", 
                nameof(clientRequest.ClientName));
        } else if (clientRequest.Cpf != null && clientRequest.Cpf.Length != 11)
        {
            throw new ArgumentException("O CPF deve conter exatamente 11 caracteres.",
                nameof(clientRequest.Cpf));
        }
        else if (clientRequest.Phone != null && clientRequest.Phone.Length < 10)
        {
            throw new ArgumentException("O telefone deve conter pelo menos 10 caracteres.",
                nameof(clientRequest.Phone));
        }

        var client = new Client(clientRequest.ClientName, 
            clientRequest.Cpf, 
            clientRequest.Phone, 
            clientRequest.Address);

        await _clientRepository.AddAsync(client);

        return new ClientResponseDto(client.Id, 
            client.ClientName, 
            client.Cpf, 
            client.Phone, 
            client.Address);
    }

    public async Task<ClientResponseDto> UpdateAsync(Guid id, ClientUpdateDto clientUpdateDto)
    {
        if(!(await _clientRepository.ClientExists(id)))
            throw new ArgumentException("Cliente não encontrado.");

        if (clientUpdateDto.NewClientName != null && clientUpdateDto.NewClientName.Length < 3) { 
            throw new ArgumentException("O nome do cliente deve ter pelo menos 3 caracteres.", 
                clientUpdateDto.NewClientName);
        } else if (clientUpdateDto.NewCpf != null && clientUpdateDto.NewCpf.Length != 11) {
            throw new ArgumentException("O CPF deve conter exatamente 11 caracteres.", 
                clientUpdateDto.NewCpf);
        } else if (clientUpdateDto.NewPhone != null && clientUpdateDto.NewPhone.Length < 10) {
            throw new ArgumentException("O telefone deve conter pelo menos 10 caracteres.", 
                nameof(clientUpdateDto.NewPhone));
        }

        Client client = await _clientRepository.UpdateAsync(id, clientUpdateDto);

        return new ClientResponseDto(client.Id,
            client.ClientName,
            client.Cpf,
            client.Phone,
            client.Address);
    }

    public async Task<ClientResponseDto?> GetByIdAsync(Guid id)
    {
        Client client = await _clientRepository.GetByIdAsync(id);

        if (client == null) throw new KeyNotFoundException("Client not found");
        
        return new ClientResponseDto(client.Id,
            client.ClientName,
            client.Cpf,
            client.Phone,
            client.Address);
    }

    public async Task<List<ClientResponseDto>> GetAllAsync()
    {
        var clientList = await _clientRepository.GetAllAsync();

        return clientList.Select(client => new ClientResponseDto(
            client.Id,
            client.ClientName,
            client.Cpf,
            client.Phone,
            client.Address
        )).ToList();
    }

    public async Task DeleteAsync(Guid id)
    {
        var client = await _clientRepository.GetByIdAsync(id);

        if(client is null) throw new KeyNotFoundException("Client not found.");
        
        await _clientRepository.DeleteAsync(client);
    }
}