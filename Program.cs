using ecommerce.Services;
using eCommerce.External;
using eCommerce.External.Fake;
using eCommerce.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<CompraService>();
builder.Services.AddScoped<CarrinhoDeComprasService>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<IEstoqueExternal, EstoqueSimulado>(); // Registro da implementação simulado
builder.Services.AddScoped<IPagamentoExternal, PagamentoSimulado>(); // Registro da implementação simulado


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
