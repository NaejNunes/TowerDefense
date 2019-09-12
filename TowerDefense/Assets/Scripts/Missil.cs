using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missil : MonoBehaviour
{
    private float velocidade = 5f;

    private GameObject alvo;

    [SerializeField] private int pontosDeDano;

    // Start is called before the first frame update
    void Start()
    {
        alvo = GameObject.Find("Inimigo");

        AutoDestroiDepoisDeSegundos(4);
    }

    // Update is called once per frame
    void Update()
    {
        Anda();

        AlteraDirecao();
    }

    private void Anda()
    {
        Vector3 posicaoAtual = transform.position;
        Vector3 deslocamento = transform.forward * Time.deltaTime * velocidade;
        transform.position = posicaoAtual + deslocamento;
    }
    private void AlteraDirecao()
    {
        Vector3 posicaoAtual = transform.position;
        Vector3 posicaoDoAlvo = alvo.transform.position;
        Vector3 direcaoDoAlvo = posicaoDoAlvo - posicaoAtual;
        transform.rotation = Quaternion.LookRotation(direcaoDoAlvo);
    }

    private void OnTriggerEnter(Collider elementoColidido)
    {
        if (elementoColidido.CompareTag("Inimigo"))
        {
            Destroy(this.gameObject);
            // Destroy(elementoColidido.gameObject);
            InimigoController inimigo = elementoColidido.GetComponent<InimigoController>();
            inimigo.RecebeDano(pontosDeDano);
        }
    }

    private void AutoDestroiDepoisDeSegundos(float segundos)
    {
        Destroy(this.gameObject, segundos);
    }
}
