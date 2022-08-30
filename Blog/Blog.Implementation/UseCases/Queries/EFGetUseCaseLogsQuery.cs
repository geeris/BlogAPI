using Blog.Application.UseCases.DTO;
using Blog.Application.UseCases.Queries;
using Blog.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Implementation.UseCases.Queries
{
    public class EFGetUseCaseLogsQuery : EFUseCase, IGetUseCaseLogsQuery
    {
        public EFGetUseCaseLogsQuery(BlogContext context) : base(context)
        {
        }

        public int Id => 26;

        public string Name => "Get all UseCaseLogs using EF";

        public IEnumerable<UseCaseLogDto> Execute(UseCaseLogSearchDto search)
        {
            var query = _context.UseCaseLogs.AsQueryable();

            if (!string.IsNullOrEmpty(search.Actor))
                query = query.Where(x => x.Actor.ToLower().Contains(search.Actor.ToLower()));
            if (!string.IsNullOrEmpty(search.UseCaseName))
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName.ToLower()));
            if (search.ToDate != null && search.FromDate != null)
                query = query.Where(x => x.Date > search.FromDate && x.Date < search.ToDate);

            return query.Select(x => new UseCaseLogDto { 
                 Actor = x.Actor,
                  Data = x.Data,
                   Date = x.Date,
                    UseCaseName = x.UseCaseName
            });
        }
    }
}
