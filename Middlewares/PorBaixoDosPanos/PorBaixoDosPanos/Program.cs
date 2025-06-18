using PorBaixoDosPanos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<TemplateMiddleware>();

app.MapGet("/", () => "Hello World!");

app.MapGet("/teste", () =>
{
    Thread.Sleep(1500);
    return "Teste 2"; // Simula uma operação demorada
});

app.Run();
