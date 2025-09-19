namespace PizzaApp.Services.Implementations
{
    using PizzaApp.DataAccess.Interfaces;
    using PizzaApp.DTOs.PizzaDTOs;
    using PizzaApp.Services.Interfaces;
    using PizzaApp.Mappers;

    public class PizzaService : IPizzaService
    {
        private IPizzaRepository _pizzaRepository;

        public PizzaService(IPizzaRepository repository)
        {
            _pizzaRepository = repository;
        }
        
        public async Task<List<PizzaListDTO>> GetAllPizzas()
        {
            var result = await _pizzaRepository.GetAll();

            var resultConverted = result.Select(x => x.ToPizzaListDTO()).ToList();

            return resultConverted;
        }
    }
}
