using Catalog_Web_API.Repositories;
using Catalog_Web_API.Settings;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System.Security.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options => 
{
    options.SuppressAsyncSuffixInActionNames = false;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

builder.Services.AddSingleton<IMongoClient>(serviceProvider => 
{
    var mongoDbSettings = builder.Configuration.GetSection(nameof(MongoDBSettings)).Get<MongoDBSettings>();
    return new MongoClient(mongoDbSettings.ConnectionString);
});

builder.Services.AddSingleton<IInMemItemsRepository, MongoDBItemsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
