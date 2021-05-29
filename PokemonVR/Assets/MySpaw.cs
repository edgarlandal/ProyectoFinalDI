using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySpaw : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject game;
    void Start()
    {
        Slot slot = game.GetComponent<Slot>();
        Instantiate(slot.item.pokemon,transform.position,transform.rotation);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
