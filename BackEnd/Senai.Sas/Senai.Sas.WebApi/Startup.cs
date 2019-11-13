using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Senai.Sas.Infra.Core.Persistence.Interfaces;
using Senai.Sas.Infra.Core.Persistence.Repositories;
using Senai.Sas.Infra.Core.Services;
using Senai.Sas.Infra.Core.Services.Interfaces;
using Senai.Sas.Infra.Data.Domains;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace Senai.Sas.WebApi
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<SasContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // mvc
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2)
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            // Configurando o serviço de documentação do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Sistema de Agendamento SENAI",
                        Version = "v1",
                        Description = "API Rest",
                        Contact = new Contact
                        {
                            Name = "Helena Strada",
                            Url = "https://github.com/hstrada"
                        }
                    });

            });

            // repositorios
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IAmbienteRepository, AmbienteRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();

            // servicos
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IAmbienteService, AmbienteService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IAgendamentoService, AgendamentoService>();

            //Adiciona o Cors ao projeto
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            //Implementa autenticação
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }
            ).AddJwtBearer("JwtBearer", options =>
            {
                //Define as opções 
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    //Quem esta solicitando
                    ValidateIssuer = true,
                    //Quem esta validadando
                    ValidateAudience = true,
                    //Definindo o tempo de expiração
                    ValidateLifetime = true,
                    //Forma de criptografia
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("sas-chave-autenticacao")),
                    //Tempo de expiração do Token
                    ClockSkew = TimeSpan.FromDays(365),
                    //Nome da Issuer, de onde esta vindo
                    ValidIssuer = "Sas.WebApi",
                    //Nome da Audience, de onde esta vindo
                    ValidAudience = "Sas.WebApi"
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Habilita a autenticação
            app.UseAuthentication();

            // documentacao
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "SAS App");
            });

            //Habilita o Cors
            app.UseCors("CorsPolicy");

            app.UseMvc();
        }
    }
}
