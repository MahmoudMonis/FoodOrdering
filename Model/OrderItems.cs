namespace FoodOrdering.Model;

public class OrderItems
{

    public int Id { get; set; }

    public int OrderId { get; set; }

    public int FooditemId { get; set; }
    public float Price { get; set; }
    public int Quintitiy { get; set; }

}