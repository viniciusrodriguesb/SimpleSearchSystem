using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Configuração do logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

//Add Services
builder.Services.AddServices(builder.Configuration);

//Add Controllers
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

//Add Autenticação
builder.Services.AddServiceAuthentication(builder.Configuration);

//Add Swagger
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();