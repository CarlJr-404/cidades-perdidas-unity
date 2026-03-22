using UnityEngine;
using UnityEngine.UI;

public class ColetaArtefato : MonoBehaviour
{
    public GameObject artefato;
    public GameObject portaSecreta;
    public Text textoObjetivo;
    public Transform jogador;
    public float distanciaColeta = 2f;

    private bool coletado = false;
    private bool abrindo = false;
    private Vector3 posicaoAberta;

    void Start()
    {
        if (portaSecreta != null)
            posicaoAberta = portaSecreta.transform.position + new Vector3(4f, 0, 0);
    }

    void Update()
    {
        if (!coletado)
        {
            float distancia = Vector3.Distance(
                jogador.position, artefato.transform.position);

            if (distancia < distanciaColeta && Input.GetKeyDown(KeyCode.E))
            {
                artefato.SetActive(false);
                coletado = true;
                abrindo = true;
                textoObjetivo.text = "Cristal coletado! Encontre a saida!";
            }
        }

        if (abrindo && portaSecreta != null)
        {
            portaSecreta.transform.position = Vector3.MoveTowards(
                portaSecreta.transform.position,
                posicaoAberta,
                3f * Time.deltaTime);

            if (Vector3.Distance(portaSecreta.transform.position, posicaoAberta) < 0.1f)
                abrindo = false;
        }
    }
}
