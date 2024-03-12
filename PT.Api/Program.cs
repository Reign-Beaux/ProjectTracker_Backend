using PT.Application.DependencyInjection;
using PT.Infraestructure.DependencyInjection;

var cors = "Cors";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCustomServices(builder.Configuration);
builder.Services.AddUnitsOfWorkServices();
builder.Services.AddExternalServices(builder.Configuration);
builder.Services.AddFeaturesServices(builder.Configuration);
builder.Services.AddValidatorsServices();
builder.Services.AddBehaviorsServices();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
      name: cors,
      builder =>
      {
          builder.AllowAnyOrigin();
          builder.AllowAnyMethod();
          builder.AllowAnyHeader();
      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(cors);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
