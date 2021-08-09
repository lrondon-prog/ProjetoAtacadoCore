using AtacadoCore.DAL.Models;
using AtacadoCore.POCO.Localizacao;
using AtacadoCore.SERV.Localizacao;
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
    public class MunicipioController : GenericBaseController<MunicipioPoco>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public MunicipioController(AtacadoContext contexto) :
            base(contexto)
        {
            this.servico = new MunicipioService(this.contexto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public List<MunicipioPoco> Get()
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
        public MunicipioPoco Get(int id)
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
        public MunicipioPoco Post(MunicipioPoco poco)
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
        public MunicipioPoco Put(MunicipioPoco poco)
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
        public MunicipioPoco Delete(int id)
        {
            return this.servico.Excluir(id);
        }

    }
}
