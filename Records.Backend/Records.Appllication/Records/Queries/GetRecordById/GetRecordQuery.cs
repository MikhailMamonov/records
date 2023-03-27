
using MediatR;

namespace Records.Appllication.Records.Queries.GetRecords
{
    public class GetRecordQuery: IRequest<RecordVm>
    {
        public Guid CategoryId { get; set; }
        public  Guid Id { get; set; }
    }
}
