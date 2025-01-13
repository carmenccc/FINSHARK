using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Extensions;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly IFMPService _fmpService;
        public CommentController(ICommentRepository commentRepo, IStockRepository stockRepo, UserManager<AppUser> userManager, IFMPService fmpService)
        {
            _commentRepo = commentRepo;
            _stockRepo = stockRepo;
            _userManager = userManager;
            _fmpService = fmpService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var comments = await _commentRepo.GetAllAsync();
            var commentDtos = comments.Select(c => c.ToCommentDto());

            return Ok(commentDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = await _commentRepo.GetByIdAsync(id);
            if(comment == null){
                return NotFound();
            }

            return Ok(comment.ToCommentDto());
        }

        [HttpPost]
        [Route("{symbol:alpha}")]
        public async Task<IActionResult> Create([FromRoute] string symbol, [FromBody] CreateCommentDto commentDto){
           if (!ModelState.IsValid)
                return BadRequest(ModelState);
           
           // Check if stock exists in db, if not fetch from fmp api service and create one
           var stock = await _stockRepo.GetBySymbolAsync(symbol);
           if(stock == null)
           {
            stock = await _fmpService.FindStockBySymbolAsync(symbol);
            if(stock == null)
            {
                return BadRequest("Stock does not exist");
            }
            else
            {
                await _stockRepo.CreateAsync(stock);
            }
           }

           // Find user to assiciate with the comment
           var username = User.GetUserName();
           var appUser = await _userManager.FindByNameAsync(username);

           var newComment = commentDto.ToCommentFromCreate(stock.Id, appUser.Id);
           await _commentRepo.CreateAsync(newComment);

            return CreatedAtAction(nameof(GetById), new {id = newComment.Id}, newComment.ToCommentDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto commentDto){
           if (!ModelState.IsValid)
                return BadRequest(ModelState);
           
           var comment = await _commentRepo.UpdateAsync(id, commentDto.ToCommentFromUpdate());
           
           if(comment == null){
            return BadRequest("Comment does not exist");
           }

            return Ok(comment.ToCommentDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
           var comment = await _commentRepo.DeleteAsync(id);
           
           if(comment == null){
            return NotFound("Comment does not exist");
           }

            return Ok(comment);
        }
    }
}