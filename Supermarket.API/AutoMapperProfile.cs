using AutoMapper;

namespace Supermarket.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            Mapper.Initialize(cfg => {

            });
        }
    }
}
