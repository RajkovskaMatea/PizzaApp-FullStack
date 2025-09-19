namespace PizzaApp.DTOs.OrderDTOs
{
    using PizzaApp.DTOs.PizzaDTOs;

    public class OrderListDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public List<PizzaDTO> PizzasInOrder { get; set; } = new List<PizzaDTO>();
    }
}
