using Duende.Bff.Yarp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddBff();

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

builder.Services.AddReverseProxy()
    .AddTransforms<AccessTokenTransformProvider>()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));;

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = "cookie";
        options.DefaultChallengeScheme = "oidc";
        options.DefaultSignOutScheme = "oidc";
    }).AddCookie("cookie", options =>
    {
        // set session lifetime
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
    
        // sliding or absolute
        options.SlidingExpiration = false;

        // host prefixed cookie name
        options.Cookie.Name = "__Host-spa";
    
        // strict SameSite handling
        options.Cookie.SameSite = SameSiteMode.Strict;
    })
    .AddOpenIdConnect("oidc", options =>
    {
        options.Authority = "https://localhost:5001";
    
        // confidential client using code flow + PKCE
        options.ClientId = "blazorbff";
        options.ClientSecret = "49C1A7E1-0C79-4A89-A3D6-A37998FB86B0";
        options.ResponseType = "code";

        // query response type is compatible with strict SameSite mode
        options.ResponseMode = "query";

        // get claims without mappings
        options.MapInboundClaims = false;
        options.GetClaimsFromUserInfoEndpoint = true;
        
        // save tokens into authentication session
        // to enable automatic token management
        options.SaveTokens = true;

        // request scopes
        options.Scope.Clear();
        options.Scope.Add("openid");
        options.Scope.Add("profile");
        options.Scope.Add("lieveapi");

        // and refresh token
        options.Scope.Add("offline_access");
    });



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();

app.UseStaticFiles();

app.UseCors("blazorfrontend");

app.UseRouting();

app.UseAuthentication(); // leest de auth cookie uit
app.UseBff();
app.UseAuthorization();

app.MapBffManagementEndpoints();

app.MapBffReverseProxy();

app.MapFallbackToFile("index.html");

app.Run();
