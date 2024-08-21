using Microsoft.SqlServer;
using Microsoft.EntityFrameworkCore;
using ExamenFinalJulioAPI.Models;
using System.Drawing;
using Microsoft.Data.SqlClient;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();


        //agregamos código que permite la inyección de la cadena 
        //de conexión contenida en appsettings.json.

        var CnnStrBuilder = new SqlConnectionStringBuilder(
           builder.Configuration.GetConnectionString("CnnStr"));

        //2. Como en la cadena de conexión eliminamos el password, lo vamos
        //a incluir directamente en este código fuente. 
        CnnStrBuilder.Password = "123Queso";

        //3 creamos un string con la info de la cadena de conexión 
        string cnnStr = CnnStrBuilder.ConnectionString;

        //4. vamos a asignar el valor de esta cadena de conexión al 
        //DB Context que está en Models
        builder.Services.AddDbContext<AnswersDbContext>(options => options.UseSqlServer(cnnStr));


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

        app.UseRouting();
    }
}