using AutoMapper;

using Records.Appllication.Common.Mappings;
using Records.Domain;


namespace Records.Appllication.Categories.Queries.GetCategoryList
{
    public class CategoryLookupDto : IMapWith<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category,CategoryLookupDto>()
                .ForMember(categoryDto => categoryDto.Name,
                opt => opt.MapFrom(category => category.Name))
                  .ForMember(categoryDto => categoryDto.Id,
                opt => opt.MapFrom(category => category.Id));
        }
    }
}
