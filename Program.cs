using ResiliencyHttpCallsPolly.Configuration;
using ResiliencyHttpCallsPolly.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IAddressService, AddressService>(client =>
{
    client.BaseAddress = new Uri("https://viacep.com.br/ws/");
})
.AddPolicyHandler(HttpPolicies.GetRetryPolicy())
.AddPolicyHandler(HttpPolicies.GetCircuitBreakerPolicy());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/address/{cep}", async (string cep, IAddressService addressService) =>
{
    var serviceResult = await addressService.GetAddressByCepAsync(cep);
    
    return  serviceResult.Sucess ? Results.Ok(serviceResult) : Results.BadRequest(serviceResult);
    
})
.WithName("GetAddressByCep");

app.Run();