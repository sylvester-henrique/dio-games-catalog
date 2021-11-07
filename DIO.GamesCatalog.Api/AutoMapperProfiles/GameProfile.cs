using AutoMapper;
using DIO.GamesCatalog.Api.ApiModels.Game;
using DIO.GamesCatalog.Api.Entities;

namespace DIO.GamesCatalog.Api.AutoMapperProfiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GetGameResponse>();
            CreateMap<PostGameRequest, Game>();
        }
    }
}
