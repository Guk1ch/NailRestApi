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
	public partial class NailsController : Controller
    {
        private readonly NailAppContext _context;

        public NailsController(NailAppContext context)
        {
            _context = context;
        }

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Nail>>> GetNails()
		{
			return await _context.Nails.ToListAsync();
		}
		[HttpGet("{id}")]
		public ActionResult<Nail> GetNail(int id)
		{
			var nail = _context.Nails.ToList().FirstOrDefault(x => x.Id == id);
			if (nail == null)
			{
				return NotFound();
			}
			return nail;
		}
		[HttpPost]
		public async Task<ActionResult<Nail>> PostClient( Nail nail)
		{
			//🤠
			_context.Nails.Add(nail);
			await _context.SaveChangesAsync();
			return CreatedAtAction("GetNail", new { id = nail.Id }, nail);
		}
	}
}
