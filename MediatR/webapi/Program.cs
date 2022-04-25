using MediatR;
using services.Business.Cars.Queries;
using webapi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped(typeof(IPipelineBehavior<,>),typeof(UserIdPipe<,>));
builder.Services.AddMediatR(typeof(GetAllCarQuery).Assembly);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseSwagger();
app.UseSwaggerUI(x=>{
    //Default page is swagger now
    x.SwaggerEndpoint("/swagger/v1/swagger.json","webapi");
    x.RoutePrefix=string.Empty;
}
);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
