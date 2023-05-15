var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

var app = builder.Build();
app.MapGrpcReflectionService();
app.MapGrpcService<GrpcWebApi.GreeterService>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();