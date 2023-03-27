using MediatR;

using Records.Appllication.Interfaces;
using Records.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Records.Appllication.Records.Commands.CreateRecord
{
    public class CreateRecordCommandHandler : IRequestHandler<CreateRecordCommand, Guid>
    {
        private readonly IRecordsDbContext _dbContext;
        public CreateRecordCommandHandler(IRecordsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Handle(CreateRecordCommand request, CancellationToken cancellationToken)
        {
            var record = new Record
            {
                CategoryId = request.CategoryId,
                Type = request.Type,
                Amount = request.Amount,
                Description = request.Description,
                CreationDate = DateTime.Now,
                Id = Guid.NewGuid()
            };

            await _dbContext.Records.AddAsync(record, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return record.Id;
        }
    }
}
