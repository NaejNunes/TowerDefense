using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostradorDeBonus : MonoBehaviour
{
    private Text  bonus;

    public Jogador jogador;

    // Start is called before the first frame update
    void Start()
    {
        bonus = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        bonus.text = "Bonus: " + jogador.GetBonus();
    }
}
