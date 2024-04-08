using AutoMapper;
using WordMaster.Server.Models;
using WordMaster.ServerDatabase.Entities;

namespace WordMaster.Server
{
    public class FlashCardMappingProfile : Profile
    {
        public FlashCardMappingProfile()
        {
            CreateMap<FlashCard, FlashCardDto>();
            CreateMap<FlashCardDto, FlashCard>();
        }
    }
}
