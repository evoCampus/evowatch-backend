using evoWatch.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEvoWatch();
builder.Services.AddEvoWatchDatabase();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
