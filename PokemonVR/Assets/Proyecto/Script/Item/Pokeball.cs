using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "Pokeball", menuName="Inventory/Pokeball")]

public class Pokeball : Item
{
    public Pokemon pokemon;

    public override void Use()
    {
        base.Use();
        // subirme la 
        GameObject pokemonObject = Instantiate(pokemon.pokemon);
        Debug.Log($"Lanzarda");
    }
}
