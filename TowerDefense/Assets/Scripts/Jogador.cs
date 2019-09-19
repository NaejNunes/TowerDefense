using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{

    [SerializeField] private int vida, bonus;

    // Start is called before the first frame update
    void Start()
    {
        bonus = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (bonus >= 3)
        {
            GanharVida();
            bonus = 0;
        }
    }

    public int GetVida()
    {
        return vida;
    }

    public int GetBonus()
    {
        return bonus;
    }

    public void PerdeVida()
    {
        if (EstaVivo())
        {
            vida--;

        }
    }

    public bool EstaVivo()
    {
        return vida > 0;
    }

    public void GanharVida()
    {
        vida++;
    }

    public void Bonus()
    {
        bonus++;
    }
}
