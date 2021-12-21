using CaseManAPI.Models;
using CaseManAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CaseManAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController:ControllerBase
{
    public ClientController()
    {

    }

    [HttpGet]
    public ActionResult<List<Client>> GetAll() => 
        ClientService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Client> Get(int id)
    {
        var client = ClientService.Get(id);

        if(client == null)
            return NotFound();

        return client;
    }

    [HttpPost]
    public IActionResult Create(Client client)
    {
        ClientService.Add(client);
        return CreatedAtAction(nameof(Create), new {id = client.Id}, client);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Client client)
    {
        if(id != client.Id)
            return BadRequest();

        var existingClient = ClientService.Get(id);
        if(existingClient is null)
            return NotFound();

        ClientService.Update(client);

        return NoContent();
    }

    //DELETE action
    [HttpDelete("{id}")]
    public  IActionResult Delete(int id)
    {
        var client = ClientService.Get(id);

        if(client is null)
            return NotFound();

        ClientService.Delete(id);

        return NoContent();
    }
}
