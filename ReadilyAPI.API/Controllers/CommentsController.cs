﻿using Microsoft.AspNetCore.Mvc;
using ReadilyAPI.Application;
using ReadilyAPI.Application.UseCaseHandling.Command;
using ReadilyAPI.Application.UseCaseHandling.Query;
using ReadilyAPI.Application.UseCases.Commands.Comments;
using ReadilyAPI.Application.UseCases.DTO.Comments;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.Application.UseCases.Queries.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadilyAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommandHandler _commandHandler;
        private readonly IQueryHandler _queryHandler;

        public CommentsController(ICommandHandler commandHandler, IQueryHandler queryHandler)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        // GET: api/<CommentsController>
        [HttpGet]
        public IActionResult Get([FromQuery] CommentSearch search, IGetCommentsQuery query)
            => Ok(_queryHandler.HandleQuery(query, search));

        // GET api/<CommentsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, IFindCommentQuery query) => Ok(_queryHandler.HandleQuery(query, id));

        // POST api/<CommentsController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateCommentDto dto, ICreateCommentCommand command)
        {
            _commandHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // PUT api/<CommentsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCommentDto dto, IUpdateCommentCommand command)
        {
            dto.Id = id;

            _commandHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<CommentsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, IDeleteCommentCommand command)
        {
            _commandHandler.HandleCommand(command, id);

            return NoContent();
        }
    }
}
