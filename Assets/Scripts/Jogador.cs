using UnityEngine;
using UnityEngine.InputSystem;

public class Jogador : MonoBehaviour
{
    [SerializeField] private int velocidade;
    [SerializeField] private Rigidbody2D fisica;
    private Animator animador;
    private Vector2 direcao;
    private Vector2 lastDirecao;
    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
        animador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        fisica.linearVelocity = direcao * velocidade;
        animador.SetFloat("eixoX", direcao.x);
        animador.SetFloat("eixoY", direcao.y);
        animador.SetFloat("lastX", lastDirecao.x);
        animador.SetFloat("lastY", lastDirecao.y);
        animador.SetBool("correndo", direcao != Vector2.zero);

        if(direcao != Vector2.zero) //X = 0 e Y = 0
        {
            lastDirecao = direcao;
        }
    }

    public void Movimentar(InputAction.CallbackContext contexto)
    {
        direcao = contexto.ReadValue<Vector2>();
    }

    void OnTriggerEnter2D(Collider2D objeto)
    {
        if(objeto.gameObject.tag == "Finish")
        {
            GameManager.instancia.TrocarCena();
        }

        if(objeto.gameObject.tag == "orbe")
        {
            Destroy(objeto.gameObject);
        }
    }
}
