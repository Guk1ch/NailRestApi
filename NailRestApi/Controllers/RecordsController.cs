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
	public partial class RecordsController : Controller
    {
        private readonly NailAppContext _context;

        public RecordsController(NailAppContext context)
        {
            _context = context;
        }
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Record>>> GetRecords()
		{
			return await _context.Records.ToListAsync();
		}
		[HttpGet("{id}")]
		public ActionResult<Record> GetRecord(int id)
		{
			var record = _context.Records.ToList().FirstOrDefault(x => x.Id == id);
			if (record == null)
			{
				return NotFound();
			}
			return record;
		}
		[HttpPost]
		public async Task<ActionResult<Record>> PostRecord( Record record)
		{
			//👉👈
			_context.Records.Add(record);
			await _context.SaveChangesAsync();
			return CreatedAtAction("GetRecord", new { id = record.Id }, record);
		}
		[HttpDelete]
		public async Task<ActionResult<IEnumerable<Record>>> DeleteRecords(Record record)
		{
			
			_context.Records.Remove(record);
			await _context.SaveChangesAsync();
			return null;
		}




	}
}
