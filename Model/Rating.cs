namespace FoodOrdering.Model;

public class Rating
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int FoodItemId { get; set; }
    public int Rate { get; set; }

}