using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApi.DTOs;
using BookApi.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class ManageController : ControllerBase
    {
        private readonly ILogger<ManageController> _logger;
        private readonly IManageService _manageService;

        public ManageController(
            ILogger<ManageController> logger,
            IManageService manageService)
        {
            _logger = logger;
            _manageService = manageService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _manageService.GetAll();
            return result is not null ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id:required}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _manageService.GetByIdAsync(id);
            return result is not null ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookDto bookDto)
        {
            if (string.IsNullOrEmpty(bookDto.Title)
                || string.IsNullOrEmpty(bookDto.Author)
                || string.IsNullOrEmpty(bookDto.Description))
            {
                return BadRequest();
            }

            var result = await _manageService.CreateAsync(bookDto.Title, bookDto.Author, bookDto.Description);
            return result is not null ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] BookDto bookDto)
        {
            if (string.IsNullOrEmpty(bookDto.Id))
            {
                return BadRequest();
            }

            var result = await _manageService.UpdateAsync(bookDto.Id, bookDto.Title, bookDto.Author, bookDto.Description);
            return result ? Ok() : BadRequest();
        }

        [HttpDelete("{id:required}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            var result = await _manageService.DeleteAsync(id);
            return result ? NoContent() : BadRequest();
        }
    }
}