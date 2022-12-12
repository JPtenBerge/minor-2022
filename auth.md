# Authenticatie/autorisatie

```sh
Identificatie - ik ben Jan
Authenticatie - bewijs dat je Jan bent
Autorisatie   - Jan mag dit

something you know - passwords
something you have - 2FA - telefoon - securid
something you are  - vingerafdruk faceid dna haar bloed iris biometrische informatie
```

XSS
- localStorage
- sessionStorage
- indexed database

Open Web Application Security Project
- security
- top 10
- tools: WebGoat  ZAP

cookies
- best veilig
- HttpOnly
- XSRF

globale JS variabele

===============================

https://docs.duendesoftware.com/identityserver/v6/quickstarts/7_blazor/


## Server

- NuGet: `Microsoft.AspNetCore.Authentication.JwtBearer`
- `[Authorize]` boven controller

```cs
builder.Services.AddAuthentication("Bearer").AddJwtBearer(options => {

});
```
en verderop:
```cs
app.UseAuthentication();
```


## Client

- NuGet:
  * `Microsoft.AspNetCore.Components.Authorization`
  * `Microsoft.Extensions.Http`

```cs
builder.Services.AddSingleton<AuthenticationStateProvider, 	HostAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();
```

- CUstom auth state provider opnemen
- URL naar BFF instellen
- `<AuthorizeView>` opgenomen in `MainLayout` zoals in https://github.com/DuendeSoftware/Samples/tree/main/IdentityServer/v5/BFF/BlazorWasm/Client

## BFF

- https://docs.duendesoftware.com/identityserver/v6/bff/session/management/ gevolgd
- en https://docs.duendesoftware.com/identityserver/v5/samples/bff/ gevolgd
- zowel cookie als openidconnect overgenomen

```cs
builder.Services.AddBff();

builder.Services.AddReverseProxy()
    .AddTransforms<AccessTokenTransformProvider>()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));;
```

en verderop:

```cs
app.MapBffManagementEndpoints();

app.UseAuthentication(); // leest de auth cookie uit
app.UseBff();
app.UseAuthorization();
```

## IdentityProvider

* Poort 5001
- Template krijgen: `dotnet new --install Duende.IdentityServer.Templates`
- Project genereren met isef-template
- `TestUsers` eventueel aanpassen
- Config scopes aanpassen
- Config client aanpassen
- `dotnet run /seed` - maak database

























