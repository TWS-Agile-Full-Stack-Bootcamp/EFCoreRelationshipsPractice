## Practice Requirement
- User the "Task introduce EF Core" repository 
* please add CompanyProfile to Company, after you
```
POST /companies
with
{
  "name": "acompany",
  "profile":{
	"registeredCapital": 5000000,
	"certId": "3xxxxx"
  }
}
```
to add a company with profile.
then, you can
```
GET /companies
```
to get
```
[{
  "name": "acompany",
  "profile":{
	"registeredCapital": 5000000,
	"certId": "3xxxxx"
  }
}]
```

# Practice output
* please input your repo url into field `answer`

# hint

* add `Pomelo.EntityFrameworkCore.MySql` reference
* use model
* MySql Connection string: `server=localhost;user=root;database=db;password=*****;`
* Use below code to method of `Configure` in file `Startup.cs` to create database automaticlly
```

using (var scope = app.ApplicationServices.CreateScope())
{
    using (var context = scope.ServiceProvider.GetService<CompanyDBContext>())
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
}
```
* create database context
* inject database context then call its save & findAll in resource
* 
```
protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<...>()
            .HasOne(...)
            .WithOne(...)
            ...
    }
```
