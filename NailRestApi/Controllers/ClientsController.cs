using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NailRestApi.Models;
using static System.Net.Mime.MediaTypeNames;

namespace NailRestApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public partial class ClientsController : ControllerBase
	{
		private readonly NailAppContext _context;

		public ClientsController(NailAppContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Client>>> GetClients()
		{
			return await _context.Clients.Include(x => x.Records).ToListAsync();
		}
		[HttpGet("{id}")]
		public ActionResult<Client> GetClient(int id)
		{
			var client = _context.Clients.Include(x => x.Records).ToList().FirstOrDefault(x => x.Id == id);
			if (client == null)
			{
				return NotFound();
			}
			return client;
		}
		[HttpPost]
		public async Task<ActionResult<Client>> PostClient(Client client)
		{
			//👉👈😎🤠
			_context.Clients.Add(client);
			await _context.SaveChangesAsync();
			return CreatedAtAction("GetClient", new { id = client.Id }, client);
		}


	}
}
