using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // Start is called before the first frame update    
    private Inventory _inventory;
    public GameObject panel;
    void Start()
    {
        _inventory = Inventory.InventoryInstance;
        _inventory.onChange += UpdateUI;
    }

    void Update()
    {
        if(panel.activeSelf)
        {
            UpdateUI();
        } 

        if (Input.GetKeyDown(KeyCode.P))
        {
            panel.SetActive(!panel.activeSelf);
        }
    }

    void UpdateUI()
    {
        Slot[] slots = GetComponentsInChildren<Slot>();
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < _inventory.items.Count)
            {
                slots[i].SetItem(_inventory.items[i]);
            }
            else
            {
                slots[i].Clear();
            }
        }
    }

    public void setPanel(bool active){
        panel.SetActive(active);
    }
}