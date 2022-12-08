using BackendDemo.GrpcServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddGrpcReflection();

builder.Services.AddGrpc();

// Cross-origin Resource Sharing

builder.Services.AddCors(options =>
{
    options.AddPolicy("blazorfrontend", policy =>
    {
        policy.WithOrigins("https://localhost:7085")
            .AllowCredentials()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


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

app.UseCors("blazorfrontend");

app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.MapGrpcReflectionService();
}

app.MapGrpcService<KaasGrpcService>();

app.MapControllers();

app.Run();