using System.ComponentModel.DataAnnotations;

namespace crediarioW.Dtos;

public class ClientUpdateDto
{
    [MaxLength(150)]
    public string? NewClientName { get; set; }
    [MaxLength(11)]
    public string? NewCpf { get; set; }
    public string? NewPhone { get; set; }
    public string? NewAddress { get; set; }

    public ClientUpdateDto() { }
}
