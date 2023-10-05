using BookStore.Api.Extensions;
using BookStore.Api.Extensions.EmployeeContextExtensions;
using BookStore.Api.Extensions.ProductContextExtensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();
builder.AddDatabase();
builder.AddJwtAuthentication();

builder.AddEmployeeContext();
builder.AddRoleContext();
builder.AddAuthorContext();
builder.AddGenreContext();
builder.AddPublisherContext();
builder.AddBookContext();

builder.AddMediatr();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapEmployeeEndpoints();
app.MapRoleEndpoints();
app.MapAuthorEndpoints();
app.MapGenreEndpoints();
app.MapPublisherEndpoints();
app.MapBookEndpoints();

app.Run();
