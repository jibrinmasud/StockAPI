using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockReository _stockRepo;
        public CommentController(ICommentRepository commentRepo, IStockReository stockRepo)
        {
            _commentRepo = commentRepo;
            _stockRepo = stockRepo;
            
        }
        //Get Endpoint to fetch all Comments 
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Model Validation
            if(!ModelState.IsValid)
            return BadRequest(ModelState);

            var comments = await _commentRepo.GetAllAsync();
            var commentDto = comments.Select(s => s.ToCommentDto());
            return Ok(commentDto);
        }
        //Get Endpoint to fetch Comments ById
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
             //Model Validation
            if(!ModelState.IsValid)
            return BadRequest(ModelState);

            var comments = await _commentRepo.GetByIdAsync(id);
            if(comments == null)
            {
                return NotFound();

            }
            return Ok(comments.ToCommentDto());
        }

        //Post Endpoint to Add Comments to Stocks ById

        [HttpPost("{stockId:int}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, CreateCommentDto commentDto)
        {
             //Model Validation
            if(!ModelState.IsValid)
            return BadRequest(ModelState); 

            if(!await _stockRepo.StockExists(stockId))
            {
                return BadRequest("Stock does not exist");
            }
            var commentModel = commentDto.ToCommentFromCreate(stockId);
            await _commentRepo.CreateAsync(commentModel);
            return CreatedAtAction(nameof(GetById), new {id = commentModel.Id}, commentModel.ToCommentDto());
        }
        
        //Update Endpoint to update each comment without aftering one another
        [HttpPut]
        [Route("{id:int}")]
         public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto updateDto)
        {
             //Model Validation
            if(!ModelState.IsValid)
            return BadRequest(ModelState);

            var comment = await _commentRepo.UpdateAsync(id, updateDto.ToCommentFromUpdate());

            if(comment == null)
            {
                NotFound("Comment Not Found");
            }
            return Ok(comment.ToCommentDto());
        }

        //Delets a particular Comment
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
             //Model Validation
            if(!ModelState.IsValid)
            return BadRequest(ModelState);
            
            var commentModel = await _commentRepo.DeleteAsync(id);
            if(commentModel ==null)
            {
                return NotFound("Comment Does Not Exist");
            }
            return Ok();

        }
    }
}