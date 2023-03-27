using MediatR;
using AutoMapper;
using Records.Appllication.Interfaces;
using System.Reflection.Metadata;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Records.Appllication.Records.Queries.GetRecordList
{
    public class GetRecordListQueryHandler : IRequestHandler<GetRecordListQuery, RecordListVm>
    {
        private readonly IMapper _mapper;
        private readonly IRecordsDbContext _dbContext;
        public GetRecordListQueryHandler(IRecordsDbContext dbContext,IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<RecordListVm> Handle(GetRecordListQuery request,CancellationToken cancellationToken)
        {
            var recordsQuery = await _dbContext.Records
                .ProjectTo<RecordLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new RecordListVm { Records = recordsQuery }; 
        }
    }
}
