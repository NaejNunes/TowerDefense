using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InimigoController : MonoBehaviour
{

    [SerializeField] private int vida;

    [SerializeField] private Jogador jogador2;
    // Start is called before the first frame update
    void Start()
    {
        jogador2 = GameObject.FindObjectOfType(typeof(Jogador)) as Jogador;

        NavMeshAgent agente = GetComponent<NavMeshAgent>();
        GameObject fimDoCaminho = GameObject.Find("FimDoCaminho");
        Vector3 posicaoFimDoCaminho = fimDoCaminho.transform.position;
        agente.SetDestination(posicaoFimDoCaminho);
    }

    public void RecebeDano(int pontosDeDano)
    {
        vida -= pontosDeDano;

        if (vida <= 0)
        {
            Destroy(this.gameObject);
            jogador2.Bonus();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
