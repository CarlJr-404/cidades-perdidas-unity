using UnityEngine;

public class MovimentoPersonagem : MonoBehaviour
{
    public float velocidade = 5f;
    public float gravidade = -9.81f;
    private CharacterController controller;
    private Vector3 velocidadeVertical;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movimento = transform.right * h + transform.forward * v;
        controller.Move(movimento * velocidade * Time.deltaTime);

        if (controller.isGrounded)
            velocidadeVertical.y = -2f;

        velocidadeVertical.y += gravidade * Time.deltaTime;
        controller.Move(velocidadeVertical * Time.deltaTime);
    }
}