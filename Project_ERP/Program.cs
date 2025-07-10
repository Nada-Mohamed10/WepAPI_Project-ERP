using Microsoft.EntityFrameworkCore;
using Project_ERP.Filters;
using Project_ERP.Mapper;
using Project_ERP.Models;
using Project_ERP.Repostiry;
using Project_ERP.Services.AccountServices;
using Project_ERP.Services.BranchServices;
using Project_ERP.Services.CityServices;
using Project_ERP.Services.JVDetails;
using Project_ERP.Services.JVDetailsServices;
using Project_ERP.Services.JVs;
using Project_ERP.Services.JVTypeServices;
using Project_ERP.Services.SubAccountClientServices;
using Project_ERP.Services.SubAccountDetailsServices;
using Project_ERP.Services.SubAccountLevelServices;
using Project_ERP.Services.SubAccountServices;
using Project_ERP.Services.SubAccountTypeServices;
using Project_ERP.UnitOfWorks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiResponseWrapperFilter>(); 
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<TaskContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddScoped(typeof(GenericRepositry<>));
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddScoped<IAccountService , AccountService>();
builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<ICityService , CityService>();
builder.Services.AddScoped<IJVService, JVService>();
builder.Services.AddScoped<IJVTypeService, JVTypeService>();
builder.Services.AddScoped<ISubAccountTypeService, SubAccountTypeService>();
builder.Services.AddScoped<ISubAccountService, SubAccountService>();
builder.Services.AddScoped<IJVDetailsService, JVDetailsService>();
builder.Services.AddScoped<ISubAccountLevelService, SubAccountLevelService>();
builder.Services.AddScoped<ISubAccountDetailsService, SubAccountDetailsService>();
builder.Services.AddScoped<ISubAccountClientService, SubAccountClientService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
      
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
