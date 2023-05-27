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
	public partial class NailLenghtsController : Controller
    {
        private readonly NailAppContext _context;

        public NailLenghtsController(NailAppContext context)
        {
            _context = context;
        }

		[HttpGet]
		public async Task<ActionResult<IEnumerable<NailLenght>>> GetNailLenghts()
		{
			return await _context.NailLenghts.Include(x => x.Nails).ToListAsync();
		}
		[HttpGet("{id}")]
		public ActionResult<NailLenght> GetNailLenght(int id)
		{
			var nailLenght = _context.NailLenghts.Include(x => x.Nails).ToList().FirstOrDefault(x => x.Id == id);
			if (nailLenght == null)
			{
				return NotFound();
			}
			return nailLenght;
		}
		[HttpPost]
		public async Task<ActionResult<NailLenght>> PostNailLenght( NailLenght nailLenght)
		{
			//😎
			_context.NailLenghts.Add(nailLenght);
			await _context.SaveChangesAsync();
			return CreatedAtAction("GetNailLenght", new { id = nailLenght.Id }, nailLenght);
		}

	}
}
