using FluentValidation.AspNetCore;
using OnionProject.Application.Validators.Products;
using OnionProject.Infrastructure;
using OnionProject.Infrastructure.Filters;
using OnionProject.Infrastructure.Storage.Local;
using OnionProject.Persistence;

var builder = WebApplication.CreateBuilder(args);


//o=>o.Filters.Add<ValidationFilter>()
builder.Services.AddControllers(o=>o.Filters.Add<ValidationFilter>()).AddFluentValidation(c=>c.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
   .ConfigureApiBehaviorOptions(o=>o.SuppressModelStateInvalidFilter=true);
//builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddStorage<LocalStorage>();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices();
builder.Services.AddCors(options=>options.AddDefaultPolicy(policy=>policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseStaticFiles();
app.UseCors();
app.UseRouting();
 
app.UseAuthentication();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
