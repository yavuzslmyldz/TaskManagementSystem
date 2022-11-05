using TaskManagementSystem.Application.Interfaces.Repository;
using TaskManagementSystem.Application.Interfaces.Service;
using TaskManagementSystem.Application.Mapper;
using TaskManagementSystem.Infrastructure.Persistence;
using TaskManagementSystem.Infrastructure.Persistence.Repositories;
using TaskManagementSystem.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// DbContext Registration
builder.Services.AddApplicationDbContext(builder.Configuration);

builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentReposityory, CommentRepository>();
builder.Services.AddAutoMapper(typeof(ApplicationMapperProfile));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");


app.MapFallbackToFile("index.html"); ;

// DbContext Running
app.RunDbContextMigrations();

app.Run();
