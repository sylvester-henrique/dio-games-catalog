using AutoMapper;
using DIO.GamesCatalog.Api.ApiModels.Game;
using DIO.GamesCatalog.Api.Entities;
using DIO.GamesCatalog.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.GamesCatalog.Api.Services
{
    public class GameService : IGameService
    {
        private readonly IRepository<Game> _gameRepository;
        private readonly IMapper _mapper;

        public GameService(IRepository<Game> gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(PostGameRequest postGameRequest)
        {
            var game = _mapper.Map<Game>(postGameRequest);
            var id = await _gameRepository.InsertAsync(game);
            return id;
        }

        public async Task<IEnumerable<GetGameResponse>> ListAsync(int? id = null)
        {
            var games =  await _gameRepository.ListAsync(id);
            var getGameResponses = _mapper.Map<IEnumerable<GetGameResponse>>(games);
            return getGameResponses;
        }

        public async Task UpdateInventoryAsync(int id, int inventory)
        {
            var game = (await _gameRepository.ListAsync(id))
                .SingleOrDefault();

            game.Inventory = inventory;
            await _gameRepository.UpdateAsync(game);
        }

        public async Task UpdatePriceAsync(int id, double price)
        {
            var game = (await _gameRepository.ListAsync(id))
                .SingleOrDefault();

            game.Price = price;
            await _gameRepository.UpdateAsync(game);
        }

        public async Task DeleteAsync(int id)
        {
            await _gameRepository.DeleteAsync(id);
        }
    }
}
