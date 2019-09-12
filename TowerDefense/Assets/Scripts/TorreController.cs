using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreController : MonoBehaviour
{
    public GameObject projetilPrefab;

    public float tempoDeRecarga = 1f;

    private float momentoDoUltimoDisparo;

    // Start is called before the first frame update
    void Start()
    {
        Atira();
    }

    // Update is called once per frame
    void Update()
    {
        Atira();
    }

    private void Atira()
    {
        float TempoAtual = Time.time;

        if (TempoAtual > momentoDoUltimoDisparo + tempoDeRecarga)
        {
            momentoDoUltimoDisparo = TempoAtual;

            GameObject pontoDeDisparo = this.transform.Find("CanhaoDaTorre/PontoDeDisparo").gameObject;
            Vector3 posicaoDoPontoDeDisparo = pontoDeDisparo.transform.position;
            Instantiate(projetilPrefab, posicaoDoPontoDeDisparo, Quaternion.identity);
        }
        
    }
}
