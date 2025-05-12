namespace przykladowy_kolos.Controllers;

using przykladowy_kolos.DTOs;
using przykladowy_kolos.Exceptions;
using przykladowy_kolos.Services;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class StudentsController(IDbService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetStudentsDetails([FromQuery] string? fName)
    {
        return Ok(await service.GetStudentDetailsAsync(fName));
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent([FromBody] StudentCreateDto body)
    {
        try
        {
            var student = await service.CreateStudentAsync(body);
            return Created($"students/{student.Id}", student);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}