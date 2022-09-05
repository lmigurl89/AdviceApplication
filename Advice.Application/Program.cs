using Advice.Data.DbContext;
using Advice.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigurationManager configuration = builder.Configuration;
builder.Services.AddRegistration(configuration);

var app = builder.Build();

IoCRegister.AddRegistration(app, app.Environment);




