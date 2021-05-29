using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//añadir objeto al inventario
public class PickUpObject : Interactable
{
    public Pokemon item;
    public GameObject objeto1;
    public GameObject other1;
    public GameObject other2;
    public override void Interact()
    {
        // base.Interact();
        // refer al invetario, llamar metodo de insert
        Destroy(objeto1);
        Inventory.InventoryInstance.Add(item);
        // Destroy(this.gameObject);
        gameObject.SetActive(false);
        Destroy(other1);
        Destroy(other2);
    }
}
