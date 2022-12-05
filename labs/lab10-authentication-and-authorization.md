# Lab 10: authentication and authorization

Protect the `Create` operations in both your REST backend as well as your gRPC backend by implementing OAuth in your application. This will involve:

* Creating an identity provider using [Duende.IdentityServer](https://docs.duendesoftware.com/).
  * Use the [`isef` template](https://github.com/DuendeSoftware/IdentityServer.Templates) to generate an IdentityServer project
  * Define scopes, API resources and the client configuration
  * Note that the `Config.cs` is used to seed the database. Changing this file means reseeding the database
* Securing the REST backend through IdentityServer. Configure the application to use JWT's ("Bearer") for authentication and define `[Authorize]` on the endpoint
* Securing the gRPC backend in much the same way
* Updating your BFF to pass along tokens
* Configuring the Blazor client by
  * Reference `Microsoft.AspNetCore.Components.WebAssembly.Authentication` and include its JavaScript
    ```html
    <script src="_content/Microsoft.AspNetCore.Components.WebAssembly.Authentication/AuthenticationService.js"></script>
    ```
  * Configure OAuth in `Program`. Define where to find the identity provider and which scopes to access
  * Passing the token with HTTP requests
  * Processing results from the identity provider using an `Authentication` page
  * It may be helpful to create a throwaway Blazor WebAssembly project with authentication enabled and copy the bits you need
