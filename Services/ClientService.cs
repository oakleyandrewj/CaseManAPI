using CaseManAPI.Models;

namespace CaseManAPI.Services;

public static class ClientService
{
    static List<Client> Clients {get;}
    static int nextId = 3;
    static ClientService()
    {
        Clients = new List<Client>
        {
            new Client {Id = 1, 
            FirstName = "John",
            SecondName = "Smith",
            Initial = "A",
            Salutation = "Dear Mr Smith",
            Title = "Mr",
            HomeTel = "039284092834",
            Mobile = "092384098234",
            Email = "jsmith@test.com",
            PrefContact = "email",
            IsClientIDChecked = false},
            new Client {Id = 2, 
            FirstName = "Jane",
            SecondName = "Doe",
            Initial = "B",
            Salutation = "Dear Ms Doe",
            Title = "Ms",
            HomeTel = "0432324423432",
            Mobile = "05685687965",
            Email = "jdoe@test.com",
            PrefContact = "mobile",
            IsClientIDChecked = true},
        };
    }

    public static List<Client> GetAll() => Clients;

    public static Client? Get(int Id) => Clients.FirstOrDefault(p => p.Id == Id);

    public static void Add(Client client)
    {
        client.Id = nextId++;
        Clients.Add(client);
    }
public static void Delete(int id)
{
    var client = Get(id);
    if(client is null)
    return;

    Clients.Remove(client);
}

public static void Update(Client client)
{
    var index = Clients.FindIndex(p => p.Id == client.Id);
    if(index == -1)
    return;

    Clients[index] = client;
}
}