using AutoMapper;

using Records.Appllication.Common.Mappings;
using Records.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Records.Appllication.Records.Queries.GetRecordList
{
    public class RecordLookupDto : IMapWith<Record>
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public int CategoryId { get; set; }
        public double Amount { get; set; } = 0;
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Record,RecordLookupDto>()
                .ForMember(recordDto => recordDto.Type,
                opt => opt.MapFrom(record => record.Type))
                 .ForMember(recordDto => recordDto.Amount,
                opt => opt.MapFrom(record => record.Amount))
                 .ForMember(recordDto=> recordDto.CategoryId,
                 opt => opt.MapFrom(record => record.CategoryId))
                 .ForMember(recordDto => recordDto.Description,
                opt => opt.MapFrom(record => record.Description))
                  .ForMember(recordDto => recordDto.CreationDate,
                opt => opt.MapFrom(record => record.CreationDate))
                  .ForMember(recordDto => recordDto.Id,
                opt => opt.MapFrom(record => record.Id));
        }
    }
}