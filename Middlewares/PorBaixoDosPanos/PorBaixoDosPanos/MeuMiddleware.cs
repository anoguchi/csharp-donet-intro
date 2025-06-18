using System.Diagnostics;
using Serilog;

namespace PorBaixoDosPanos
{
    public class TemplateMiddleware
    {
        private readonly RequestDelegate _next;
        public TemplateMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }
        public async Task InvokeAsync(HttpContext context)
        {
            // Logica do middleware aqui
            var sw = Stopwatch.StartNew();

            // Chama o próximo middleware na cadeia
            await _next(context);

            sw.Stop();

            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
            Log.Information($"A execução demorou {sw.Elapsed.TotalMicroseconds}ms ({sw.Elapsed.TotalMicroseconds} segundos)");
        }
    }
}
