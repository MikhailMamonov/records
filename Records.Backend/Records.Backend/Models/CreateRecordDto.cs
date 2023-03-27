using AutoMapper;

using Records.Appllication.Common.Mappings;
using Records.Appllication.Records.Commands.CreateRecord;

namespace Records.WebApi.Models
{
    public class CreateRecordDto : IMapWith<CreateRecordCommand>
    {
        public int CategoryId { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; } = 0;
        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateRecordDto,CreateRecordCommand>()
                .ForMember(recordCommand => recordCommand.Type,
                opt => opt.MapFrom(recordDto => recordDto.Type))
                .ForMember(recordCommand => recordCommand.Amount,
                opt => opt.MapFrom(recordDto => recordDto.Amount))
                .ForMember(recordCommand => recordCommand.Description,
                opt => opt.MapFrom(recordDto => recordDto.Description))
                .ForMember(recordCommand => recordCommand.CreationDate,
                opt => opt.MapFrom(recordDto => recordDto.CreationDate));

        }
    }
}
