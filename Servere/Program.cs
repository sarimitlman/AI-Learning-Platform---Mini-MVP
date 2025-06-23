using BL.Api;
using BL.Services;
using BL.Services.BL.Services;
using Dal.Api;
using Dal.Models;
using Dal.Repository;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// מוסיפים את השירות של המונגו
builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient("mongodb://localhost:27017"));

// מוסיפים את שאר השירותים
builder.Services.AddScoped<IUsers, UserRepository>();
builder.Services.AddScoped<IBLUser, BLUserService>();
builder.Services.AddScoped<ICategory, CategoryRepository>();
builder.Services.AddScoped<IBLCategory, BLCategoryService>();
builder.Services.AddScoped<ISubCategory, SubCategoryRepository>();
builder.Services.AddScoped<IBLSubCategory, SubCategoryService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// ...

var app = builder.Build();
app.MapControllers();
app.Run();
