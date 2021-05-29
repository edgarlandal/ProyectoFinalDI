using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory : MonoBehaviour
{
    static protected Inventory s_InventoryInstance;
    static public Inventory InventoryInstance { get { return s_InventoryInstance; } }

    public delegate void OnChange();
    public OnChange onChange;

    public int space = 10;
    public List<Pokemon> items = new List<Pokemon>();
    void Awake()
    {
        s_InventoryInstance = this;
    }
    // Start is called before the first frame update
     public Pokemon[] GetAllItemsByType(ItemType type)
    {
        return items.Where(i => i.itemType == type).ToArray();
    }

    public void Add(Pokemon newItem)
    {
        if (items.Count < space)
        {
            // if (newItem.GetType() == typeof(Pelota))
            // {

            // }
            items.Add(newItem);
            if (onChange != null)
            {
                onChange.Invoke();
            }
        }
        else
        {
            Debug.Log("No hay espacio disponible");
        }
    }

    public void Remove(Pokemon itemToRemove)
    {
        if (items.Contains(itemToRemove))
        {
            items.Remove(itemToRemove);
            if (onChange != null)
            {
                onChange.Invoke();
            }
        }
        else
        {
            Debug.Log("No esta el item");
        }
    }
}
