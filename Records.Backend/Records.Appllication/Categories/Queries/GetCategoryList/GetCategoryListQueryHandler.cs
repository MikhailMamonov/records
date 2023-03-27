using AutoMapper;
using AutoMapper.QueryableExtensions;

using MediatR;

using Microsoft.EntityFrameworkCore;

using Records.Appllication.Interfaces;
using Records.Appllication.Records.Queries.GetRecordList;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Records.Appllication.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQueryHandler: IRequestHandler<GetCategoryListQuery, CategoryListVm>
    {
        private readonly IMapper _mapper;
        private readonly IRecordsDbContext _dbContext;
        public GetCategoryListQueryHandler(IRecordsDbContext dbContext,IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<CategoryListVm> Handle(GetCategoryListQuery request,CancellationToken cancellationToken)
        {
            var categoriesQuery = await _dbContext.Categories
                .ProjectTo<CategoryLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new CategoryListVm { Categories = categoriesQuery };
        }
    }
}
