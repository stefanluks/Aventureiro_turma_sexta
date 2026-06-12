using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterfaceControll : MonoBehaviour
{
    public static InterfaceControll instancia {get; private set;}
    [SerializeField] private GameObject menuPrincipal;
    [SerializeField] private GameObject menuOpcoes;
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject menuPause;
    [SerializeField] private GameObject transicao;
    private int id_tela_atual = 0; // 0 -> Menu Principal | 1 -> Menu Opções | 2 -> Carregar Cena
    [Header("Audios & Configurações")]
    [SerializeField] private AudioSource btnClick;
    [SerializeField] private AudioSource somTransicao;

    void Awake()
    {
        if(instancia != null && instancia != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        transicao.SetActive(false);
        menuPause.SetActive(false);
    }

    public void Trocar()
    {
        if(id_tela_atual == 0)
        {
            menuPrincipal.SetActive(true);
            menuOpcoes.SetActive(false);
            HUD.SetActive(false);
        }
        else if(id_tela_atual == 1)
        {
            menuOpcoes.SetActive(true);
            menuPrincipal.SetActive(false);
            HUD.SetActive(false);
        }
        else if(id_tela_atual == 2)
        {
            menuOpcoes.SetActive(false);
            menuPrincipal.SetActive(false);
            HUD.SetActive(true);
            SceneManager.LoadScene("Principal");
        }
    }

    public void Pausar()
    {
        menuPause.SetActive(!menuPause.activeSelf);
    }

    public void Jogar()
    {
        transicao.SetActive(true);
        somTransicao.Play();
        id_tela_atual = 2;
    }
    public void PararAudio()
    {
        somTransicao.Stop();
    }

    public void Opcoes()
    {
        transicao.SetActive(true);
        somTransicao.Play();
        if(id_tela_atual == 0) id_tela_atual = 1;
        else id_tela_atual = 0;
    }

    public void Sair()
    {
        Debug.Log("Jogo Encerrado!");
    }

    public void CliqueNoBotao(){
        btnClick.Play();
    }
}
