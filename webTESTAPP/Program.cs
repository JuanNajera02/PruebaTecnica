using System.Text.Json.Serialization;

using webTESTAPP;

var builder = WebApplication.CreateBuilder(args);

ServiceConfigurator.ConfigureDBOptions(builder);
ServiceConfigurator.ConfigureRepositories(builder);
ServiceConfigurator.ConfigureBusiness(builder);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthChecks();
builder.Services.AddResponseCompression(ServiceConfigurator.ConfigureCompression);
builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader())
);

// Agrega los servicios de Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors();

app.UseResponseCompression();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    c.RoutePrefix = string.Empty; // Esto har� que Swagger UI est� en la ra�z de tu aplicaci�n
});



app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
