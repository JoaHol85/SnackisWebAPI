using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SnackisWebAPI.Data;
using SnackisWebAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackisWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BadWordController : ControllerBase
    {
        private readonly SnackisWebApiContext _context;

        public BadWordController(SnackisWebApiContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task PostBadWordAsync(BadWord badWord)
        {
            _context.Add(badWord);
            await _context.SaveChangesAsync();
        }

        [HttpGet]
        public async Task<List<BadWord>> GetAllBadWordsAsync()
        {
            return await _context.BadWords.ToListAsync();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BadWord>> RemoveBadWordAsync(int id)
        {
            var item = await _context.BadWords.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Remove(item);
            await _context.SaveChangesAsync();
            return null;
        }


    }
}
