using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NailRestApi.Models;

namespace NailRestApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public partial class MasterWorksController : Controller
    {
        private readonly NailAppContext _context;

        public MasterWorksController(NailAppContext context)
        {
            _context = context;
        }
		[HttpGet]
		public async Task<ActionResult<IEnumerable<MasterWork>>> GetMasterWorks()
		{
			return await _context.MasterWorks.ToListAsync();
		}
		[HttpGet("{id}")]
		public ActionResult<MasterWork> GetMasterWork(int id)
		{
			var masterWork = _context.MasterWorks.FirstOrDefault(x => x.Id == id);
			if (masterWork == null)
			{
				return NotFound();
			}
			return masterWork;
		}
		[HttpPost]
		public async Task<ActionResult<MasterWork>> PostMasterWork( MasterWork masterWork)
		{
			//😎
			_context.MasterWorks.Add(masterWork);
			await _context.SaveChangesAsync();
			return CreatedAtAction("GetMasterWork", new { id = masterWork.Id }, masterWork);
		}

	}
}
