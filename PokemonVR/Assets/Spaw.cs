using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaw : MonoBehaviour
{    
    public int randNum;
    public GameObject[] arrays;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(arrays[Random.Range(0,arrays.Length-1)],transform.position,transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
