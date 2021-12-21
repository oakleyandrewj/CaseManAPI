using CaseManAPI.Models;
using CaseManAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CaseManAPI.Controllers;

//ApiController]
[Route("[controller]")]
public class EntityController:ControllerBase
{
    public EntityController()
    {

    }

    [HttpGet]
    public ActionResult<List<Entity>> GetAll() => 
        EntityService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Entity> Get(int id)
    {
        var entity = EntityService.Get(id);

        if(entity == null)
            return NotFound();

        return entity;
    }

    [HttpPost]
    public IActionResult Create(Entity entity)
    {
        EntityService.Add(entity);
        return CreatedAtAction(nameof(Create), new {id = entity.Id}, entity);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Entity entity)
    {
        if(id != entity.Id)
            return BadRequest();

        var existingEntity = EntityService.Get(id);
        if(existingEntity is null)
            return NotFound();

        EntityService.Update(entity);

        return NoContent();
    }

    //DELETE action
    [HttpDelete("{id}")]
    public  IActionResult Delete(int id)
    {
        var entity = EntityService.Get(id);

        if(entity is null)
            return NotFound();

        EntityService.Delete(id);

        return NoContent();
    }
}
