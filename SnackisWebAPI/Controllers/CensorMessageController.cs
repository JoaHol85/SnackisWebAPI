using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SnackisWebAPI.Data;
using SnackisWebAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace SnackisWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CensorMessageController : ControllerBase
    {
        private readonly SnackisWebApiContext _context;

        public CensorMessageController(SnackisWebApiContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<string>> RemoveBadWordsInText([FromHeader]string text)
        {
            List<BadWord> listOfBadWords = await _context.BadWords.ToListAsync();
            text = HttpUtility.UrlDecode(text);

            foreach (var word in listOfBadWords)
            {
                var regex = new Regex($@"\b{word.CensoredWord.ToLower()}\b");

                text = regex.Replace(text.ToLower(), "***");
            }

            return text;
        }
    }
}
