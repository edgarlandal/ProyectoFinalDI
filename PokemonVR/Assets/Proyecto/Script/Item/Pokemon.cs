using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName= "Pokemon", menuName="Inventory/Pokemon")]

public class Pokemon : Item
{
    public string name;
    public string type;
    public int hpA;
    public int hp;
    public int attack;
    public int defense;
    public int special;
    public int special_attack;
    public int special_defense;
    public int speed;
    public int level;
    public int xp;
    public GameObject pokemon;
    public Ataques[] ataques;

    public override void Use()
    {
        base.Use();
    }  
}
