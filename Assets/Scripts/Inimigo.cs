using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField] private int velocidade;
    [SerializeField] private float distanciaMax = 2f;
    [SerializeField] private float tempoEspera = 1f;
    private GameObject jogador;
    private SpriteRenderer render;
    private Vector2 destino;
    private float tempoParado = 0f;
    private bool esperando = false;
    private int modos = 0; //0 -> patrulha | 1 -> Perseguição
    void Start()
    {
        jogador = GameObject.Find("Jogador");
        render = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(modos == 0) Patrulha();
        else Perseguicao();
    }

    void Patrulha()
    {
        if (esperando)
        {
            tempoParado -= Time.deltaTime;

            if(tempoParado <= 0)
            {
                esperando = false;
                NovaPosicao();
            }
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, destino, velocidade*Time.deltaTime);

        float distancia = Vector2.Distance(transform.position, destino);

        render.flipX = transform.position.x > destino.x;

        if(distancia < 0.1f)
        {
            esperando = true;
            tempoParado = tempoEspera;
        }
    }

    void NovaPosicao()
    {
        Vector2 origem = transform.position;

        float x = Random.Range(-distanciaMax, distanciaMax);
        float y = Random.Range(-distanciaMax, distanciaMax);

        destino = origem + new Vector2(x, y);
    }

    void Perseguicao()
    {
        transform.position = Vector2.MoveTowards(transform.position, jogador.transform.position, velocidade * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D objeto)
    {
        if(objeto.gameObject.tag == "Player")
        {
            modos = 1;
        }
    }

    void OnTriggerExit2D(Collider2D objeto)
    {
        if(objeto.gameObject.tag == "Player")
        {
            modos = 0;
        }
    }
}
