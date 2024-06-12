using Godot;
using System; 

public partial class Item 
{

    private String name;
    private String description;
    private Tuple<int, String> effect;
    private int price;

    public String getName() 
    {
        return this.name;
    }

    public void setName(String name)
    {
        this.name = name;
    }

    public String getDescription()
    {
        return this.description;
    }

    public void setDescription(String descr)
    {
        this.description = descr;
    }

    public Tuple<int, String> getEffect()
    {
        return this.effect;
    }

    public void setEffect(Tuple<int, String> effect)
    {
        this.effect = effect;
    }

    public int getPrice()
    {
        return this.price;
    }

    public void setPrice(int price) 
    {
        this.price = price;
    }
}