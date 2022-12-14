using BackendDemo.GrpcServices;
using IdentityModel;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
{
    options.Authority = "https://localhost:5001";
    options.Audience = "kaasapi.read";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        NameClaimType = JwtClaimTypes.Name
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("alleenbob", policy =>
    {
        policy.RequireAuthenticatedUser()
            .RequireClaim(JwtClaimTypes.Name, "Bob Smith");
    });
});

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

app.UseAuthentication();

app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.MapGrpcReflectionService();
}

app.MapGrpcService<KaasGrpcService>();

app.MapControllers();

app.Run();