using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucesControl : Interactable
{
    public GameObject luz1;
    public GameObject luz2;
    // Start is called before the first frame update
    void Start()
    {
        luz2.SetActive(false);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }
}
