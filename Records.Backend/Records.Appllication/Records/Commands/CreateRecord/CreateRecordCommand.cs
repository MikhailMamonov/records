using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Records.Appllication.Records.Commands.CreateRecord
{
    public class CreateRecordCommand : IRequest<Guid>
    {
        public int CategoryId { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; } = 0;
        public string Description { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
