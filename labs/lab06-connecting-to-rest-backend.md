# Lab 6: connecting frontend to backend

Connect your frontend to your backend by adding a new frontend repository that talks to the backend for retrieving and persisting photos using the REST API.

Add a [Backends for Frontend](https://learn.microsoft.com/en-us/azure/architecture/patterns/backends-for-frontends) that your Blazor frontend will talk to. Use [YARP](https://microsoft.github.io/reverse-proxy/index.html) to proxy all the requests to the correct backend endpoints.

Should you run into CORS errors or something saying `Failed to fetch`, you probably still need to allow requests from other domains by adding the CORS middleware in your backend.
