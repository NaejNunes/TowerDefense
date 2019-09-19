using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogo : MonoBehaviour
{
    [SerializeField] private GameObject torrePrefab;

    [SerializeField] private GameObject gameOver;

    [SerializeField] private Jogador jogador;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (JogoAcabou())
        {
            gameOver.SetActive(true);
        }
        else
        {
            if (ClicouComBotaoPrimario())
            {
                ConstruirTorre();
            }
        }      
    }

    private bool JogoAcabou()
    {
        return !jogador.EstaVivo();
    }

    private bool ClicouComBotaoPrimario()
    {
        return Input.GetMouseButtonDown(0);
    }

    private void ConstruirTorre()
    {
        Vector3 posicaoDoClique = Input.mousePosition;
        RaycastHit elementoAtingidoPeloRaio = DisparaRaioDaCameraAteUmPonto(posicaoDoClique);

        if (elementoAtingidoPeloRaio.collider != null)
        {
            Vector3 posicaoDoElemento = elementoAtingidoPeloRaio.point;

            Instantiate(torrePrefab, posicaoDoElemento, Quaternion.identity);
        }
    }

    private RaycastHit DisparaRaioDaCameraAteUmPonto(Vector3 ponto)
    {
        Ray raio = Camera.main.ScreenPointToRay(ponto);
        RaycastHit elementoAtingidoPeloRaio;
        float comprimentoMaximoDoRaio = 100f;
        Physics.Raycast(raio, out elementoAtingidoPeloRaio, comprimentoMaximoDoRaio);

        return elementoAtingidoPeloRaio;
    }

    public void RecomecaJogo()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
