using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PokemonData : MonoBehaviour
{
    [SerializeField] private string name = "Pikachu";
    private int lifeNow = 35;
    [SerializeField] private int lifeBase = 70;
    [SerializeField] private int atq = 35;
    [SerializeField] private int defense = 20;
    private int stats = 125;
    [SerializeField] private float weight = 5.7f;
    private enum Types
    {
        Normal,
        Fighting,
        Flying,
        Poison,
        Ground,
        Rock,
        Bug,
        Ghost,
        Steel,
        Fire,
        Water,
        Grass,
        Electric,
        Psychic,
        Ice,
        Dragon,
        Dark,
        Fairy
    }
    [SerializeField] private Types typeOurPokemon = Types.Electric;
    [SerializeField] private Types[] weakness = { Types.Ground, Types.Rock };
    [SerializeField] private Types[] resistances = { Types.Flying, Types.Water };
    private void InitCurrentLife()
    {
        lifeNow = lifeBase;
    }
    private void InitStatsPoint()
    {
        stats = defense + atq + lifeNow;
    }
    private int GetAttackDamage()
    {
        return 35;
    }
    private void TakeDamage(int damage, Types ennemiType)
    {
        if(isInArray(weakness,ennemiType))
        {
            lifeNow -= damage * 2;
            Debug.Log("Il vous reste " + lifeNow + " HP");
            CheckifPokemonAlive();
        }
        else if(isInArray(resistances, ennemiType))
        {
            lifeNow -= damage / 2;
            Debug.Log("Il vous reste "+lifeNow+" HP");
            CheckifPokemonAlive();
        }
        else
        {
            lifeNow -= damage;
            Debug.Log("Il vous reste "+lifeNow+" HP");
            CheckifPokemonAlive();
        }
        
    }
    private bool isInArray(Types[] array, Types element)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == element)
            {
                return true;
            }
            
        }
        return false;
    }
    private void CheckifPokemonAlive()
    {
        if (lifeNow <= 0)
        {
            Debug.Log("Votre Pokemon est KO");
        }
        else if (lifeNow >= 1)
        {
            Debug.Log("Votre Pokemon n'est pas encore KO");
        }
}

    private void Awake()
    {
        InitCurrentLife();
        InitStatsPoint();
    }
    //Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Votre Pokemon a "+lifeBase+" HP max");
        Debug.Log("Votre Pokemon se nomme "+name);
        Debug.Log("Votre Pokemon a "+defense+" de defense");
        Debug.Log("Votre Pokemon fait "+weight+" kg");
        Debug.Log("Votre Pokemon est du type "+typeOurPokemon);
        Debug.Log("Votre Pokemon a des faiblesses contre les types "+weakness[0]+ " et " + weakness[1]);
        Debug.Log("Votre Pokemon a des avantages contre les types "+resistances[0]+" et " + resistances[1]);
        Debug.Log("Votre Pokemon a " + atq + " d'attaque");
        Debug.Log("Votre Pokemon a " + stats + " en stats");
        TakeDamage(70, Types.Bug);
    }

    // Update is called once per frame
    private void update()
    {
        CheckifPokemonAlive();
    }
}