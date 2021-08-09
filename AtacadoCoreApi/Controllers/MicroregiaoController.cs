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
    [Route("api/[controller]")]
    [ApiController]
    public class MicroregiaoControler : GenericBaseController<MicroregiaoPoco>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public MicroregiaoControler(AtacadoContext contexto) :
            base(contexto)
        {
            this.servico = new MicroregiaoService(this.contexto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public List<MicroregiaoPoco> Get()
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
        public MicroregiaoPoco Get(int id)
        {
            return this.servico.Obter(id);
        }

        /// <summary>
        /// Obter municipios por id da microregiao.
        /// </summary>
        /// <param name="micid">Chave primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{micid:int}/municipios")]
        public List<MunicipioPoco> GetMunicipiosPorID(int micid)
        {
            MunicipioService srv = new MunicipioService(this.contexto);
            List<MunicipioPoco> municipioPoco = srv.ObterTodos()
                .Where(mic => mic.MesoregiaoID == micid).ToList();
            return municipioPoco;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public MicroregiaoPoco Post(MicroregiaoPoco poco)
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
        public MicroregiaoPoco Put(MicroregiaoPoco poco)
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
        public MicroregiaoPoco Delete(int id)
        {
            return this.servico.Excluir(id);
        }

    }
}
