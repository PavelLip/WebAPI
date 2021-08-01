using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using MetricsAgent.DAL;



namespace MetricsAgent
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            ConfigureSqlLiteConnection(services);
            services.AddScoped<ICpuMetricsRepository, CpuMetricsRepository>();
            //services.AddSingleton<ICpuMetricsRepository, CpuMetricsRepository>(); // ��� 5�� ����� ������!!!
            services.AddSwaggerGen(c =>
                    {
                        c.SwaggerDoc("v1", new OpenApiInfo { Title = "MetricsAgent", Version = "v1" });
                    });
        }



        private void ConfigureSqlLiteConnection(IServiceCollection services)
        {
            const string connectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            PrepareSchema(connection);
        }

        private void PrepareSchema(SQLiteConnection connection)
        {
            using (var command = new SQLiteCommand(connection))
            {
                // ������ ����� ����� ������� ��� ����������
                // ������� ������� � ��������� ���� ��� ���������� � ���� ������
                command.CommandText = "DROP TABLE IF EXISTS cpumetrics";
                // ���������� ������ � ���� ������
                command.ExecuteNonQuery();
                command.CommandText = "DROP TABLE IF EXISTS dotnetmetrics";
                command.ExecuteNonQuery();
                command.CommandText = "DROP TABLE IF EXISTS hddmetrics";
                command.ExecuteNonQuery();
                command.CommandText = "DROP TABLE IF EXISTS networkmetrics";
                command.ExecuteNonQuery();
                command.CommandText = "DROP TABLE IF EXISTS rammetrics";
                command.ExecuteNonQuery();


                command.CommandText = @"CREATE TABLE cpumetrics(id INTEGER PRIMARY KEY, value INT, time INT)";
                command.ExecuteNonQuery();
                command.CommandText = @"CREATE TABLE dotnetmetrics(id INTEGER PRIMARY KEY, value INT, time INT)";
                command.ExecuteNonQuery();
                command.CommandText = @"CREATE TABLE hddmetrics(id INTEGER PRIMARY KEY, value INT, time INT)";
                command.ExecuteNonQuery();
                command.CommandText = @"CREATE TABLE networkmetrics(id INTEGER PRIMARY KEY, value INT, time INT)";
                command.ExecuteNonQuery();
                command.CommandText = @"CREATE TABLE rammetrics(id INTEGER PRIMARY KEY, value INT, time INT)";
                command.ExecuteNonQuery();

                AddMetricsFromDB(connection);
            }
        }

        void AddMetricsFromDB(SQLiteConnection connection)
        {
            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = @"INSERT INTO cpumetrics (value, time) VALUES (100,0)";
                command.ExecuteNonQuery();
                command.CommandText = @"INSERT INTO cpumetrics (value, time) VALUES (32,1)";
                command.ExecuteNonQuery();
                command.CommandText = @"INSERT INTO cpumetrics (value, time) VALUES (12,2)";
                command.ExecuteNonQuery();

                command.CommandText = @"INSERT INTO dotnetmetrics (value, time) VALUES (100,0)";
                command.ExecuteNonQuery();
                command.CommandText = @"INSERT INTO dotnetmetrics (value, time) VALUES (87,1)";
                command.ExecuteNonQuery();
                command.CommandText = @"INSERT INTO dotnetmetrics (value, time) VALUES (17,2)";
                command.ExecuteNonQuery();

                command.CommandText = @"INSERT INTO hddmetrics (value, time) VALUES (51,0)";
                command.ExecuteNonQuery();
                command.CommandText = @"INSERT INTO hddmetrics (value, time) VALUES (89,1)";
                command.ExecuteNonQuery();
                command.CommandText = @"INSERT INTO hddmetrics (value, time) VALUES (6,2)";
                command.ExecuteNonQuery();

                command.CommandText = @"INSERT INTO networkmetrics (value, time) VALUES (34,0)";
                command.ExecuteNonQuery();
                command.CommandText = @"INSERT INTO networkmetrics (value, time) VALUES (32,1)";
                command.ExecuteNonQuery();
                command.CommandText = @"INSERT INTO networkmetrics (value, time) VALUES (14,2)";
                command.ExecuteNonQuery();

                command.CommandText = @"INSERT INTO rammetrics (value, time) VALUES (23,0)";
                command.ExecuteNonQuery();
                command.CommandText = @"INSERT INTO rammetrics (value, time) VALUES (4,1)";
                command.ExecuteNonQuery();
                command.CommandText = @"INSERT INTO rammetrics (value, time) VALUES (5,2)";
                command.ExecuteNonQuery();
            }

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); 
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MetricsAgent v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}