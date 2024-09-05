using ETicaretAPI.Persistence;
var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddPersistenceServices();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(); // Ensure this is before UseAuthorization and UseEndpoints
app.UseAuthorization();
app.MapControllers();

app.Run();
