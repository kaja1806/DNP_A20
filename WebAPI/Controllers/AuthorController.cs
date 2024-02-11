using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers;

    [ApiController]
    [Route("api/[action]")]
    public class AuthorController : ControllerBase
    {
        private readonly IDataAccess _dataAccess;

        public AuthorController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        // 1) Create author
        [HttpPost]
        public async Task<ActionResult<Author>> CreateAuthor(Author author)
        {
            var result = await _dataAccess.CreateAuthor(author);
            return Ok(result);
        }
}