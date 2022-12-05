# Lab 11: authorization

Protect the `Update` and `Delete` operations so that users will only be allowed to update and delete their own photos and comments. This authorization check is most important to have server-side, but for user-friendliness you will also implement it client-side.

To accomplish this, you will:

* Store the username when creating a photo/comment
* Implement the authorization checks in a new class library project, `Shared.Authorization`, so this logic can be used by both backend and frontend
* Call the authorization checks from both the frontend services as the backend services
