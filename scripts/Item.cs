using Godot;
using System; 

public partial class Item 
{

    public Item(String name, String descr, (int, String) effect,int price)
    {
        this.name = name;
        this.effect = effect;
        this.description = descr;
        this.price = price;
    }

    private String icon;
    private String name;
    private String description;
    private (int, String) effect;
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

    public (int, String) getEffect()
    {
        return this.effect;
    }

    public void setEffect((int, String) effect)
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