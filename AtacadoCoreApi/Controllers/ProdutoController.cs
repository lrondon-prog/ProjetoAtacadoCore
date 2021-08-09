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
    public class ProdutoController : GenericBaseController<ProdutoPoco>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public ProdutoController(AtacadoContext contexto) :
            base(contexto)
        {
            this.servico = new ProdutoService(this.contexto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public ProdutoPoco Get(int id)
        {
            return this.servico.Obter(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public ProdutoPoco Post(ProdutoPoco poco)
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
        public ProdutoPoco Put(ProdutoPoco poco)
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
        public ProdutoPoco Delete(int id)
        {
            return this.servico.Excluir(id);
        }

    }
}

