using AtacadoCore.DAL.Models;
using AtacadoCore.Repo.Ancestral;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtacadoCore.REPO.Estoque
{
    public class RegiaoRepository : GenericRepository<DbContext, Regiao>
    {
        public RegiaoRepository(DbContext contexto) : base(contexto)
        { }
    }
}
