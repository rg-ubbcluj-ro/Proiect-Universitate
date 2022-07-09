using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
 using System.Text;

using University.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//database
builder.Services.AddDbContext<UniversityContext>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>

{

    options.RequireHttpsMetadata = false;
    
    options.SaveToken = true;
    
    options.TokenValidationParameters = new TokenValidationParameters()
    
    {
    
        ValidateIssuer = true,
    
        ValidateAudience = true,
    
        ValidateLifetime = true,
    
        ValidAudience = builder.Configuration["Jwt:Audience"],
    
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
    
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
    
        ClockSkew = TimeSpan.Zero

    };

});


//builder.Services.AddDbContext<UniversityContext>(opt =>
  //  opt.UseInMemoryDatabase("UniversityList"));
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "TodoApi", Version = "v1" });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseSwagger();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi v1"));
}
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();