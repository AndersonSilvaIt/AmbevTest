using DeveloperStore.IoC.AppDependencies;
using DeveloperStore.Users.WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ValidationErrorHandlerMiddleware>();

app.MapControllers();

app.Run();
