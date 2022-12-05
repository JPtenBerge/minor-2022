# Lab 12: optimization

Apply some optimization techniques to improve the (perceived) performance of your web application.

* Load photos from a URL. Currently, the backend sends a byte array for every photo in the list of photos. As a consequence, the rendering of the photos will start when all the bytes of all the photos have been transferred.

  If we were to serve every photo from a separate URL, we could already render parts of the UI that shows the general structure of things to come. Photos will also be shown when the bytes have individually been transferred.

  Plus, a browser can cache photos loaded from a URL.
* [Use the `Virtualize` component](https://docs.microsoft.com/en-us/aspnet/core/blazor/components/virtualization?view=aspnetcore-5.0) to only render the photos that actually fit on the screen.
* Think of other techniques you might want to apply
