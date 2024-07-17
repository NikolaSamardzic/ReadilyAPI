﻿using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.Application.UseCases.DTO.Messages;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.Application.UseCases.Queries.Searches;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Queries
{
    public class EfGetMessagesQuery : EfUseCase, IGetMessagesQuery
    {
        public EfGetMessagesQuery(ReadilyContext context) : base(context)
        {
        }

        public int Id => 60;

        public string Name => "Get Messages";

        public PagedResponse<MessageDto> Execute(MessageSearch search)
        {
            var query = Context
                .Messages
                .Include(x => x.User)
                .Where(x => x.IsActive)
                .AsQueryable();

            if (search.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }

            if (search.StartDate.HasValue)
            {
                query = query.Where(x => x.CreatedAt > search.StartDate);
            }

            if (search.EndDate.HasValue)
            {
                query = query.Where(x => x.CreatedAt < search.EndDate);
            }

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Subject.Contains(search.Keyword));
            }

            var totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<MessageDto>
            {
                CurrentPage = page,
                ItemsPerPage = perPage,
                TotalCount = totalCount,
                Items = query.Select(x => new MessageDto
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    Username = x.User.Username,
                    Subject = x.Subject,
                    Message = x.Text,
                    CreatedAt = x.CreatedAt.ToLongDateString(),
                }).ToList(),
            };
        }
    }
}