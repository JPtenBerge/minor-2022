# Lab 9: connecting frontend to backend

Connect your frontend to your backend by adding a new frontend repository that talks to the backend for retrieving and persisting comments using the gRPC endpoints.

NuGet packages you'll need:
* `Grpc.Tools`
* `Google.Protobuf`
* `Grpc.Net.Client`
* `Grpc.Net.Client.Web`

Should you run into CORS errors or something saying `Failed to fetch`, you probably still need to allow requests from other domains by adding the CORS middleware in your backend. Also, remember that IIS Express doesn't support gRPC (yet?).
