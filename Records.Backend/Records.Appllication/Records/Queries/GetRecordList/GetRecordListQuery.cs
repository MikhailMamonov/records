using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Records.Appllication.Records.Queries.GetRecordList
{
    public class GetRecordListQuery: IRequest<RecordListVm>
    {
    }
}
