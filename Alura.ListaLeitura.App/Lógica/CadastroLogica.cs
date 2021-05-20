using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Lógica
{
    public static class CadastroLogica
    {
        public static Task ProcessaFormulario(HttpContext context)
        {
            var livro = new Livro
            {
                Titulo = context.Request.Form["titulo"].First(),
                Autor = context.Request.Form["autor"].First(),
            };

            var _repo = new LivroRepositorioCSV();
            _repo.Incluir(livro);
            return context.Response.WriteAsync("Livro Adicionado com Sucesso!!");
        }

        public static Task ExibeFormulario(HttpContext context)
        {
            var html = HtmlUtil.CarregaArquivoHTML("formulario");
            return context.Response.WriteAsync(html);
        }


        public static Task CadastroNovoLivro(HttpContext context)
        {
            var livro = new Livro
            {

                Titulo = context.GetRouteValue("nome").ToString(),
                Autor = context.GetRouteValue("autor").ToString()
            };

            var _repo = new LivroRepositorioCSV();
            _repo.Incluir(livro);
            return context.Response.WriteAsync("Livro Adicionado com Sucesso!!");
        }
    }
}
