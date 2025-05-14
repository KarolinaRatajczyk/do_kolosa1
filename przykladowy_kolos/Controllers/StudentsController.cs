namespace przykladowy_kolos.Controllers;

using przykladowy_kolos.DTOs;
using przykladowy_kolos.Exceptions;
using przykladowy_kolos.Services;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]         //ustawia trase na /students, oznacza ze nazwa kontrolera z uciętym students
public class StudentsController(IDbService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetStudentsDetails([FromQuery] string? fName)
    {
        return Ok(await service.GetStudentDetailsAsync(fName));
    }

    //[FromQuery] string? fName to oznacza ze /students?fName=... tez zadziala
    // [HttpGet]
    // public async Task<IActionResult> GetAllStudents()
    // {
    //     var students = await service.GetAllStudentsAsync();
    //     return Ok(students);
    // } wszystkie elementy
    
    // [HttpGet("{id}")]
    // public async Task<IActionResult> GetStudentById(int id)
    // {
    //     var student = await service.GetStudentByIdAsync(id);
    //     if (student == null) return NotFound();
    //     return Ok(student);
    // }po id

    
    
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

//[FromBody] StudentCreateDto body 
//to oznacza ze dane przechodzą z ciała żadania JSON 
//StudentCreateDto zawiera to co potrzebne do utworzenia studenta

//var student = await service.CreateStudentAsync(body);
//nowy student; IDbService tworzy, await czeka za stworzy

//return Created($"students/{student.Id}", student);
//przyjmuje URL nowego zasobu i dane i zwraca HTTP 201 Created


// [HttpPost]
// public async Task<IActionResult> CreateStudent([FromBody] StudentCreateDto body)
// {
//     if (!ModelState.IsValid)
//         return BadRequest(ModelState);
//
//     var student = await service.CreateStudentAsync(body);
//     return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
// } wersja z walidacja danych, pokazuje get do pobrania


//[HttpPost]
// public async Task<IActionResult> CreateStudent([FromBody] StudentCreateDto body)
// {
//     try
//     {
//         var student = await service.CreateStudentAsync(body);
//         return Created($"students/{student.Id}", student);
//     }
//     catch (ValidationException e)
//     {
//         return BadRequest(e.Message);
//     }
//     catch (NotFoundException e)
//     {
//         return NotFound(e.Message);
//     }
//     catch (Exception e)
//     {
//         return StatusCode(500, "Unexpected server error");
//     }
// }
// 


//walidacja grupy!!
// var groupExists = await _dbContext.Groups.AnyAsync(g => g.Id == dto.GroupId);
// if (!groupExists)
//     throw new NotFoundException($"Group with ID {dto.GroupId} does not exist.");
