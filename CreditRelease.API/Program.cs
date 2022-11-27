var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

builder.BuilderAddDbContext();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddFluentValidationRulesToSwagger();

services.AddDependencyInjection();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapEndpoints();
app.Run();