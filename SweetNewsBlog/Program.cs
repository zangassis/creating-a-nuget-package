using Dango.BlogUtils;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/slug", (SlugRequest request) =>
{
    var slug = SlugGen.GenerateSlug(request.Text);
    return Results.Ok(new { slug });
});

app.Run();

public record SlugRequest(string Text);
