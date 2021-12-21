using CaseManAPI.Models;
using CaseManAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CaseManAPI.Controllers;

//ApiController]
[Route("[controller]")]
public class MatterController:ControllerBase
{
    public MatterController()
    {

    }

    [HttpGet]
    public ActionResult<List<Matter>> GetAll() => 
        MatterService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Matter> Get(int id)
    {
        var matter = MatterService.Get(id);

        if(matter == null)
            return NotFound();

        return matter;
    }

    [HttpPost]
    public IActionResult Create(Matter matter)
    {
        MatterService.Add(matter);
        return CreatedAtAction(nameof(Create), new {id = matter.Id}, matter);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Matter matter)
    {
        if(id != matter.Id)
            return BadRequest();

        var existingMatter = MatterService.Get(id);
        if(existingMatter is null)
            return NotFound();

        MatterService.Update(matter);

        return NoContent();
    }

    //DELETE action
    [HttpDelete("{id}")]
    public  IActionResult Delete(int id)
    {
        var matter = MatterService.Get(id);

        if(matter is null)
            return NotFound();

        MatterService.Delete(id);

        return NoContent();
    }
}
