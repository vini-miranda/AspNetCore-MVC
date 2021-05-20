using Alura.ListaLeitura.App.Lógica;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection service)
        {
            service.AddRouting();

        }
        public void Configure(IApplicationBuilder app)
        {
            var routeBuilder = new RouteBuilder(app);
            routeBuilder.MapRoute("Livros/Paraler", LivrosLogica.LivrosParaLer);
            routeBuilder.MapRoute("Livros/Lendo", LivrosLogica.LivrosLendo);
            routeBuilder.MapRoute("Livros/Lidos", LivrosLogica.LivrosLidos);
            routeBuilder.MapRoute("cadastro/novolivro/{nome}/{autor}", CadastroLogica.CadastroNovoLivro);
            routeBuilder.MapRoute("Livros/Detalhes/{id:int}", LivrosLogica.ExibirDetalhes);
            routeBuilder.MapRoute("Cadastro/NovoLivro", CadastroLogica.ExibeFormulario);
            routeBuilder.MapRoute("Cadastro/Incluir", CadastroLogica.ProcessaFormulario);
            var rotas = routeBuilder.Build();

            app.UseRouter(rotas);
        }
        
    }
}