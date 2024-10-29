var builder = WebApplication.CreateBuilder(args);

// 1.
// New in dotnet 9, instead of swashbuckle, we can use Microsoft.AspNetCore.OpenApi
builder.Services.AddOpenApi(); //We could use here schema transformers, if necessary.

var app = builder.Build();

// New in dotnet 9 - Lets see the location of the doc
app.MapOpenApi();

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

// 2.
// Typed Results is a helper class to return strongly types http status code based responses
// The new Internal Server Error has been added
app.MapGet("/error", () => TypedResults.InternalServerError("Something went wrong!"));

// 3.
// We can now add custom extensions to the problem response, which is a key/value properties added
app.MapGet("/error2", () =>
{
    var extensions = new List<KeyValuePair<string, object?>> { new("test", "value") };
    return TypedResults.Problem("This is an error with extensions",extensions: extensions);
});

// 4.
// You can now mark a group of endpoints to produce a problem response by default
var todos = app.MapGroup("/todos")
    .ProducesProblem(500);

todos.MapGet("/", () => new Todo(1, "Create sample app", false));
todos.MapPost("/", (Todo todo) => Results.Ok(todo));

// 5.
// New unhandled exception page
app.MapGet("/weatherforecastwitherror", () =>
{
    throw new InvalidOperationException("This exception wont be handled on purpose.");
})
.WithName("GetWeatherForecastWithError");

app.Run();
record Todo(int Id, string Title, bool IsCompleted);

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

// -- Other enhancements --

// MapStaticAssets: this would replace UseStaticFiles.
// Optimization of static assets delivery to include gzip + brotli out of the box, use eTags for cached hits from the client
// It is also simpler than performing dynamic compression on the server, assets are compressed at build time, which incurs
// no performance penalty at runtime. 

// Improved Kestrel metrics:
// Kestrel now includes metadata about why a connection failed with errors like:
// tsl_handshake_failed
// connection_reset
// request_headers_timeout
// max_request_body_size_exceeded

// Opt-out of metrics on certain endpoints:
// app.MapHealthChecks("/health").DisableHttpMetrics();

// Trust aspnetcore https development certificates on linux (Ubuntu/Fedora)