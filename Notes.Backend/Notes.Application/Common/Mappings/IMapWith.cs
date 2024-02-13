using AutoMapper;

namespace Notes.Application.Common.Mappings
{
    //generic
    public class IMapWith<T>
    {
        void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType());
    }
}