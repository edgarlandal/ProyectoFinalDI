using UnityEngine;

public enum ItemType
{
    Pokemon,Item, Pokeball
}

[CreateAssetMenu(fileName= "New Item", menuName="Inventory/Generic")]
public class Item : ScriptableObject
{
    public ItemType itemType = ItemType.Pokemon;
    public Sprite icon = null;
    public virtual void Use()
    {
        Debug.Log($"Usando item {name}");
    }
}
