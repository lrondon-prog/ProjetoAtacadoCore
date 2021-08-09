using AtacadoCore.DAL.Models;
using AtacadoCore.POCO.Estoque;
using AtacadoCore.SERV.Estoque;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtacadoCoreApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriaController : GenericBaseController<SubcategoriaPoco>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public SubcategoriaController(AtacadoContext contexto) :
            base(contexto)
        {
            this.servico = new SubcategoriaService(this.contexto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public List<SubcategoriaPoco> Get()
        {
            return this.servico.ObterTodos().ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public SubcategoriaPoco Get(int id)
        {
            return this.servico.Obter(id);
        }

        /// <summary>
        /// Obter produtos por id da subcategoria.
        /// </summary>
        /// <param name="subcatid">Chave primaria da subcategoria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{subcatid:int}/produtos")]
        public List<ProdutoPoco> GetProdutosPorID(int subcatid)
        {
            ProdutoService srv = new ProdutoService(this.contexto);
            List<ProdutoPoco> produtoPoco = srv.ObterTodos()
                .Where(prod => prod.SubcategoriaID == subcatid).ToList();
            return produtoPoco;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public SubcategoriaPoco Post(SubcategoriaPoco poco)
        {
            return this.servico.Incluir(poco);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public SubcategoriaPoco Put(SubcategoriaPoco poco)
        {
            return this.servico.Atualizar(poco);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public SubcategoriaPoco Delete(int id)
        {
            return this.servico.Excluir(id);
        }

    }
}

