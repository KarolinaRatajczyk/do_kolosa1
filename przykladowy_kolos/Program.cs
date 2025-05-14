using przykladowy_kolos.Services;

namespace przykladowy_kolos;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();
        builder.Services.AddControllers();

        builder.Services.AddTransient<IDbService, DbService>();
        
        // // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        // builder.Services.AddEndpointsApiExplorer();
        // builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // // Configure the HTTP request pipeline.
        // if (app.Environment.IsDevelopment())
        // {
        //     app.MapOpenApi();
        // }
        

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}




//TEMPLATE
// using APBD_Test1_Example.Services;
//
// var builder = WebApplication.CreateBuilder(args);
//
// // Add services to the container.
//
// builder.Services.AddControllers();
// // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();
//
// builder.Services.AddTransient<IDbService, DbService>();
//
// var app = builder.Build();
//
// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }
//
// app.UseAuthorization();
//
// app.MapControllers();
//
// app.Run();


//TRESC
// Posługując się załączonymi plikami, utwórz aplikację typu WebApi, która obsłuży bazę
// danych, ukazaną na poniższym diagramie. Wykonaj poniższe polecenia.
// Zad. 1
// Przygotuj końcówkę, odpowiadającą na zapytania typu GET, której zadaniem będzie
// zwrócenie informacji o wszystkich studentach oraz ich przypisach do poszczególnych
// grup. Końcówka powinna dodatkowo umożliwić opcjonalne przefiltrowanie listy
// studentów, używając do tego ich imienia.
// Przykładowe ciało odpowiedzi:
// [
// {
// "id": 1,
// "firstName": "Jan",
// "lastName": "Kowalski",
// "age": 20,
// "groups": [
// {
// "id": 1,
// "name": "16c"
// },
// {
// "id": 2,
// "name": "15c_apbd"
// }
// ]
// },
// {
// "id": 2,
// "firstName": "Monika",
// "lastName": "Wozniak",
// "age": 21,
// "groups": []
// }
// ]
// Zad2.
// Przygotuj końcówkę, odpowiadającą na zapytania typu POST. Końcówka powinna
// umożliwić dodanie studentów do bazy danych. Opcjonalnie razem z utworzeniem nowego
// studenta, chcemy mieć możliwość przypisania go do istniejących już w bazie danych grup.
// Przykładowe ciało zapytania (utworzenie studenta):
// {
// "firstName": "Test2",
// "lastName": "Test2",
// "age": 20
// }}
// Przykładowe ciało zapytania (utworzenie studenta z przypisaniem do grup o id 1 oraz 2):
// {
// "firstName": "Test2",
// "lastName": "Test2",
// "age": 20,
// "groupAssignments" : [1, 2]
// }
// Przykładowe ciało odpowiedzi na zapytanie:
// {
// "id": 1002,
// "firstName": "Test2",
// "lastName": "Test2",
// "age": 20,
// "groups": [
// {
// "id": 1,
// "name": "16c"
// },
// {
// "id": 2,
// "name": "15c_apbd"
// }
// ]
// }
// Pamiętaj o:
// - Poprawnych kodach http;
// - Konwencji nazewnictwa;
// - Wydzieleniu logiki biznesowej oraz dostępu do danych do oddzielnej warstwy
// (serwisu);
// - Korzystaniu z systemu wstrzykiwania zależności;
// - Korzystaniu z systemu parametryzacji przy zapytaniach do bazy danych, gdzie jest
// to wymagane;
// - Stosowaniu DTO do obsługi zapytań;
// - Stosowaniu walidacji danych tam, gdzie jest to wymagane;
// - Umieszczeniu rozwiązania na platformie github, zgodnie z poleceniami
// prowadzącego;
// Przed oddaniem pracy upewnij się, że Twoja praca się kompiluje. Przekazanie
// niedziałajacego programu skutkuje niezaliczeniem kolokwium.