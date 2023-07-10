using PracticeAzure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
 builder.Services.AddScoped<IAzureTableService, AzureService>();
builder.Services.AddScoped<IBlobService,BlobService >();
builder.Services.AddScoped<IQueueService, AzureQueueService>();
builder.Services.AddScoped<IAzureFunctions,AzureFunctions >();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
