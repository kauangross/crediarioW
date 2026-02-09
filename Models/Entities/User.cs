namespace crediarioW.Models.Entities;

using System;

public class User
{
    public Guid Id { get; }
    public string Username { get; }
    public string PasswordHash { get; }
   
    public User(string username, string passwordHash)
    {
        Id = Guid.NewGuid();
        Username = username;
        PasswordHash = passwordHash;

    }
}
