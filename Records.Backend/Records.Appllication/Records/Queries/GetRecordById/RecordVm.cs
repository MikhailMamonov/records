using AutoMapper;

using Records.Appllication.Common.Mappings;
using Records.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Records.Appllication.Records.Queries.GetRecords
{
    public class RecordVm : IMapWith<Record>
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; } = 0;
        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Record,RecordVm>()
                .ForMember(recordVm => recordVm.Type,
                opt => opt.MapFrom(record => record.Type))
                 .ForMember(recordVm => recordVm.Amount,
                opt => opt.MapFrom(record => record.Amount))
                 .ForMember(recordVm => recordVm.Description,
                opt => opt.MapFrom(record => record.Description))
                  .ForMember(recordVm => recordVm.Id,
                opt => opt.MapFrom(record => record.Id))
                  .ForMember(recordVm => recordVm.CreationDate,
                opt => opt.MapFrom(record => record.CreationDate))
                  .ForMember(recordVm => recordVm.EditDate,
                opt => opt.MapFrom(record => record.EditDate));
        }
    }
}
