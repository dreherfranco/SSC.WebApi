using Microsoft.Extensions.DependencyInjection;
using SSC.Modelos;
using SSC.Repositorio;
using SSC.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSC.WebApi.MetodosExtension
{
    public static class IoC
    {
        public static IServiceCollection AddDependenciasRepositorios(this IServiceCollection services)
        {
            services.AddTransient<Repositorio<Capitulo>>();
            services.AddTransient<Repositorio<EvaluacionPractica>>();
            services.AddTransient<Repositorio<EvaluacionTeorica>>();
            services.AddTransient<Repositorio<Curso>>();
            return services;
        }

        public static IServiceCollection AddDependenciasServicios(this IServiceCollection services)
        {
            services.AddTransient<ServicioCapitulo>();
            services.AddTransient<ServicioEvaluacionPractica>();
            services.AddTransient<ServicioEvaluacionTeorica>();
            services.AddTransient<ServicioCurso>();

            return services;
        }

    }
}
