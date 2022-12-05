# Lab 1: the all photos page

## Intro

We will be creating a photo sharing application where a user can view, upload, edit and delete photos. In this application, we will:

* use a [Clean-ish Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
* use authentication/authorization for updating/removing photos
* use a Material Design component library

Let's get started

## The lab: an all photos page

Create a Blazor WebAssembly application and add a page that displays all photos. Nothing special yet, we're just getting familiar with Blazor at this point.

A photo has the following properties:

```cs
public class Photo
{
	public int Id { get; set; }
	public string Title { get; set; }
	public byte[] PhotoFile { get; set; }
	public string ImageMimeType { get; set; }
	public string Description { get; set; }
	public DateTime CreatedDate { get; set; }
	public string UserName { get; set; }
}
```
