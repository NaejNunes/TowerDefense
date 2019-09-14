using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreController : MonoBehaviour
{
    public GameObject projetilPrefab;

    public float tempoDeRecarga = 1f;

    private float momentoDoUltimoDisparo;

    [SerializeField] private float raioDeAlcance;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        InimigoController alvo = EscolheAlvo();

        if (alvo != null)
        {
            Atira(alvo);
        }
    }

    private void Atira(InimigoController inimigo)
    {
        float TempoAtual = Time.time;

        if (TempoAtual > momentoDoUltimoDisparo + tempoDeRecarga)
        {
            momentoDoUltimoDisparo = TempoAtual;

            GameObject pontoDeDisparo = this.transform.Find("CanhaoDaTorre/PontoDeDisparo").gameObject;
            Vector3 posicaoDoPontoDeDisparo = pontoDeDisparo.transform.position;
            //Instantiate(projetilPrefab, posicaoDoPontoDeDisparo, Quaternion.identity);
            GameObject projetilObject = (GameObject)Instantiate(projetilPrefab, posicaoDoPontoDeDisparo, Quaternion.identity);

            Missil missil = projetilObject.GetComponent<Missil>();
            missil.DefineAlvo(inimigo);
        }       
    }

    private InimigoController EscolheAlvo()
    {
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Inimigo");

        foreach (GameObject inimigo in inimigos)
        {
            if (EstaNoRaioDeAlcance(inimigo))
            {
                return inimigo.GetComponent<InimigoController>();
            }
        }
        return null;
    }

    private bool EstaNoRaioDeAlcance(GameObject inimigo)
    {
        Vector3 posicaoDoInimigoNoPlano = Vector3.ProjectOnPlane(inimigo.transform.position, Vector3.up);
        Vector3 posicaoDaTorreNoPlano = Vector3.ProjectOnPlane(this.transform.position, Vector3.up);
        float distanciaParaInimigo = Vector3.Distance(posicaoDaTorreNoPlano, posicaoDoInimigoNoPlano);
        return distanciaParaInimigo <= raioDeAlcance;

    }
}
