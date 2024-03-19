using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(Options=> 
Options.ReturnHttpNotAcceptable=true
).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();// if ACCEPT header is application/Xml and our api restuen json and client specified 
//it will accept only xml, to throw 406 Not acceptable we need to add option returnhttpnotacceptable=true and if we want to send in xml we need to add 
// the addxmlcontractserializerformaters
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
