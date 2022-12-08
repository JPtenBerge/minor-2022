# Lab 4: more CRUD pages and Razor class libraries

Before you dive into exercise 1 and 2, feel free to mix these two exercises up by applying a test-driven approach.

## Exercise 1: adding CRUD pages

In this exercise, we'll be adding more CRUD pages:

* Showing the details of a photo
* Editing a photo's properties (including the image itself)
* Deleting a photo, after giving confirmation. Display the photo that's about to be deleted with its properties.

The Delete page and the Details page share UI logic. Create a `PhotoDetailsComponent` and reuse as much as possible.

* Place this component in a new Razor Class Library project, `Frontend.Components`
* The buttons for details/edit/delete should be inside this component, on the `Card`'s `Action` "bar" at the bottom
* Define properties on `PhotoDetailsComponent` that determine which buttons get shown
* Define a custom event that fires when the delete button has been clicked. The parent component (the page) should have the logic to handle the actual deletion

Also, there's a bit of HTML we're repeating for displaying the photo, both on the Edit page and in `PhotoDetailsComponent`. Create a `PhotoPictureComponent` that encapsulates this.

```html
<PhotoPictureComponent Photo="Photo"></PhotoPictureComponent>
```

## Exercise 2: testing components

* Create a new test project, `Frontend.Components.Tests`
* Feel free to use whichever test framework you'd like: MSTest/xUnit/NUnit
* Add [bUnit](https://bunit.dev/docs/getting-started/) to the test project

Then, use bUnit to create and render your component.

```cs
using var ctx = new TestContext();
var cut = ctx.RenderComponent<MyComponent>(parameters => {
	parameters
		.Add(p => p.Numbers, 42)
		.Add(p => p.Lines, lines);
});
```

There a already a few interesting bits of code that make good candidates for testing:

* When adding/editing photos, processing the uploaded file
* Whether the form validation messages are shown
* Deleting a photo should remove it from the list. Perhaps your want to test whether your `PhotoDeleteConfirmComponent` throws some sort of custom event?
