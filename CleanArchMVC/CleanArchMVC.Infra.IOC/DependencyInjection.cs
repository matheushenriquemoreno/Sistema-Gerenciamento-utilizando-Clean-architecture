using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Application.Mapeamento;
using CleanArchMVC.Application.Services;
using CleanArchMVC.Domain.Interfaces;
using CleanArchMVC.Infra.Data.Context;
using CleanArchMVC.Infra.Data.Repositorios;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CleanArchMVC.Infra.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {

            service.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            service.AddAutoMapper(typeof(ConfigurandoMapeamentosProfile));

            AdiconarDependenciaBibliotecaMidiaTr(service);

            service.AddScoped<IRepositorioCategoria, RepositorioCategoria>();
            service.AddScoped<IRepositorioProduto, RepositorioProduto>();
            service.AddScoped<ICategoriaService, CategoriaService>();
            service.AddScoped<IProdutoService, ProdutoService>();

            return service;
        }

        public static void AdiconarDependenciaBibliotecaMidiaTr(IServiceCollection service)
        {
            var handdlers = AppDomain.CurrentDomain.Load("CleanArchMVC.Application");

            service.AddMediatR(handdlers);
        }
    }
}
