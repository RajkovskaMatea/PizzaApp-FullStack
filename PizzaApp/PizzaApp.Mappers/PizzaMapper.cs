namespace PizzaApp.Mappers
{
    using PizzaApp.Domain.Entities;
    using PizzaApp.DTOs.PizzaDTOs;

    public static class PizzaMapper
    {
        public static PizzaListDTO ToPizzaListDTO(this Pizza pizza)
        {
            return new PizzaListDTO()
            {
                Id = pizza.Id,
                PizzaName = pizza.Name,
                Ingredients = pizza.Ingredients,
                PizzaPriceSmall = pizza.PriceSmall,
                PizzaPriceLarge = pizza.PriceLarge,
                PizzaPriceMedium = pizza.PriceMedium
            };
        }
    }
}
