namespace Shop1.Data.Models;

public class Car
{
    public int id { set; get; }
    public string name { set; get; }
    public string shortDesc { set; get; }
    public string longDesc { set; get; }
    public string img { set; get; }
    public uint price { set; get; }
    public bool isFavourite { get; set; }
    public bool available { set; get; }
    public int categoryId { set; get; }
    public virtual Category Category { set; get; }
}