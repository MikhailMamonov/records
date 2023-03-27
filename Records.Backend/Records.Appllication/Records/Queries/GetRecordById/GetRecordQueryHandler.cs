using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

using Records.Appllication.Common.Exceptions;
using Records.Appllication.Interfaces;
using Records.Domain;


namespace Records.Appllication.Records.Queries.GetRecords
{
    public class GetRecordQueryHandler : IRequestHandler<GetRecordQuery,RecordVm>
    {
        private readonly IRecordsDbContext _context;
        private readonly IMapper _mapper;

        public GetRecordQueryHandler(IRecordsDbContext dbContext, IMapper mapper) {
            _context = dbContext;
            _mapper = mapper;
        }
        public async Task<RecordVm> Handle(GetRecordQuery request,CancellationToken cancellationToken)
        {
            var entity = await _context.Records
                .FirstOrDefaultAsync(Records =>  Records.Id == request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Record), request.Id);
            }

            return _mapper.Map<RecordVm>(entity);
        }
    }
}
