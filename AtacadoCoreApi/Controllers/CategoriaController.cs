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
    public class CategoriaController : GenericBaseController<CategoriaPoco>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public CategoriaController(AtacadoContext contexto) :
            base(contexto)
        {
            this.servico = new CategoriaService(this.contexto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public List<CategoriaPoco> Get()
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
        public CategoriaPoco Get(int id)
        {
            return this.servico.Obter(id);
        }

        /// <summary>
        /// Obter subcategorias por id da categoria.
        /// </summary>
        /// <param name="catid">Chave primaria da categoria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{catid:int}/subcategorias")]
        public List<SubcategoriaPoco> GetSubcategoriaPorID(int catid)
        {
            SubcategoriaService srv = new SubcategoriaService(this.contexto);
            List<SubcategoriaPoco> subcategoriaPoco = srv.ObterTodos()
                .Where(sub => sub.CategoriaID == catid).ToList();
            return subcategoriaPoco;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public CategoriaPoco Post(CategoriaPoco poco)
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
        public CategoriaPoco Put(CategoriaPoco poco)
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
        public CategoriaPoco Delete(int id)
        {
            return this.servico.Excluir(id);
        }

    }
}
