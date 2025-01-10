using AMS.Core.Constants;
using AMS.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

// ------------ DATABASE ------------
builder.Services.AddDatabaseConfiguration(builder.Configuration);

// ------------ DEPENDENCY INJECTION ------------
builder.Services.AddDependencyInjectionConfiguration(typeof(Program));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//================ AUTO MAPPER ================
builder.Services.AutoMapperDI();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Asser Management System API V1"); });

//Redirect to Swagger by default
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
        context.Response.Redirect("/swagger");
    else
        await next();
});

app.Run();
