using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Order
{
    [Key]
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public List<Item> Items { get; set; }
    public decimal CheckoutValue { get; set; }
}

public class Item
{
    public int ItemId { get; set; }
    public string CartItemId { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

}
