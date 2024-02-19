using System;
using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    //Класс, который описывает то, что будет возвращено пользователю, когда он будет запрашивать детали заметок
    //Вью деталей класса заметки маппится с классом заметки
    public class NoteDetailsVm : IMapWith<Note>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteDetailsVm>()
                .ForMember(noteVm => noteVm.Title,
                    option => option.MapFrom(note => note.Title))
                .ForMember(noteVm => noteVm.Details,
                    option => option.MapFrom(note => note.Details))
                .ForMember(noteVm => noteVm.Id,
                    option => option.MapFrom(note => note.Id))
                .ForMember(noteVm => noteVm.CreationDate,
                    option => option.MapFrom(note => note.CreationDate))
                .ForMember(noteVm => noteVm.EditDate,
                    option => option.MapFrom(note => note.EditDate));
        }
    }
}