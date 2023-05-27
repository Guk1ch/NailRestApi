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
	public partial class NailFormsController : Controller
    {
        private readonly NailAppContext _context;

        public NailFormsController(NailAppContext context)
        {
            _context = context;
        }
		[HttpGet]
		public async Task<ActionResult<IEnumerable<NailForm>>> GetNailForms()
		{
			return await _context.NailForms.Include(x => x.Nails).ToListAsync();
		}
		[HttpGet("{id}")]
		public ActionResult<NailForm> GetNailForm(int id)
		{
			var nailForm = _context.NailForms.Include(x => x.Nails).ToList().FirstOrDefault(x => x.Id == id);
			if (nailForm == null)
			{
				return NotFound();
			}
			return nailForm;
		}
		[HttpPost]
		public async Task<ActionResult<NailForm>> PostClient( NailForm nailForm)
		{
			//👉👈
			_context.NailForms.Add(nailForm);
			await _context.SaveChangesAsync();
			return CreatedAtAction("GetNailForm", new { id = nailForm.Id }, nailForm);
		}

	}
}
