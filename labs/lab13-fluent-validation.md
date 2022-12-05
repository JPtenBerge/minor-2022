# Lab 13: Fluent Validation

Remove the data annotations on your entities and use Fluent Validation to define your validations. Update your form to use the `FluentValidationValidator`.

Note that with this change, your database constraints will be gone as well. Use Entity Framework Core's Fluent API to redefine those constraints.

```cs
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
	modelBuilder.Entity<Photo>()
			.Property(s => s.Description)
			.IsRequired()
			.HasMaxLength(255);
}
```