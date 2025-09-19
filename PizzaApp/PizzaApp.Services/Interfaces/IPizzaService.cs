namespace PizzaApp.Services.Interfaces
{
    using PizzaApp.DTOs.PizzaDTOs;

    public interface IPizzaService
    {
        Task<List<PizzaListDTO>> GetAllPizzas();

    }
}
