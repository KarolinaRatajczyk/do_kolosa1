namespace przykladowy_kolos.DTOs;

public class StudentDetailsGetDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public List<StudentGroupGetDto> Groups { get; set; }
}


//DTo do zwracania w GET, czyli to co w poleceniu ma byc zwrocone w get, jest tu