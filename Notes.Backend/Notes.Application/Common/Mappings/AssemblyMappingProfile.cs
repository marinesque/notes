using System.Reflection;
using AutoMapper;

namespace Notes.Application.Common.Mappings
{
    public class AssemblyMappingProfile : Profile
    {
        //Конструктор использует сборку assembly
        public AssemblyMappingProfile(Assembly assembly) =>
            ApplyMappingsFromAssembly(assembly);
        
        private void ApplyMappingsFromAssembly(Assembly assembly)
        {}
    }
}