using System;
using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNoteList
{
    public class NoteLookupDto : IMapWith<Note>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteLookupDto>()
                .ForMember(noteVm => noteVm.Title,
                    option => option.MapFrom(note => note.Title))
                .ForMember(noteVm => noteVm.Id,
                    option => option.MapFrom(note => note.Id));
        }
    }
}