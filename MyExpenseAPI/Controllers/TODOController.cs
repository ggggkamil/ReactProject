using TODO.Models;
using TODO.Services;
using Microsoft.ASPNetCore.Mvc;
namespace TODO.Controllers;
[ApiController]
[Route("[controller]")]
public class TODOController : ControllerBase
{
    public TODOController()
    {

    }
    [HttpGet]
    public ActionResult<List<TODO>> GetAll() =>
    TODOService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<TODO> Get(int id)
    {
        var exercise = TODOService.Get(id);

        if (exercise == null)
            return NotFound();

        return exercise;
    }

    [HttpPost]
    public IActionResult Create(Exercise exercise)
    {
        TODOService.Add(exercise);
        return CreatedAtAction(nameof(Create), new { id = exercise.Id }, exercise);
    }
    [HttpPut("{id}")]
    public IActionResult Update(int id, Exercise exercise)
    {
        if (id != exercise.Id)
            return BadRequest();

        var existingTODO = TODOService.Get(id);
        if (existingTODO is null)
            return NotFound();

        TODOService.Update(exercise);

        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var exercise = TODOService.Get(id);

        if (exercise is null)
            return NotFound();

        TODOService.Delete(id);

        return NoContent();
    }

}