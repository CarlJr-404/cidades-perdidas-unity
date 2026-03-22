using UnityEngine;

public class PatrulhaInimigo : MonoBehaviour
{
    public Transform pontoA;
    public Transform pontoB;
    public float velocidade = 3f;
    public float distanciaDeteccao = 4f;
    public Transform jogador;

    private Transform alvo;

    void Start()
    {
        alvo = pontoB;
    }

    void Update()
    {
        float distancia = Vector3.Distance(transform.position, jogador.position);

        if (distancia < distanciaDeteccao)
            MoverPara(jogador.position);
        else
        {
            MoverPara(alvo.position);
            if (Vector3.Distance(transform.position, alvo.position) < 0.2f)
                alvo = (alvo == pontoA) ? pontoB : pontoA;
        }

        Vector3 direcao = (alvo.position - transform.position).normalized;
        if (direcao != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(direcao);
    }

    void MoverPara(Vector3 destino)
    {
        transform.position = Vector3.MoveTowards(
            transform.position, destino, velocidade * Time.deltaTime);
    }
}