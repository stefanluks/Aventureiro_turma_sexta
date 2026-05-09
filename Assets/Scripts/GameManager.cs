using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
   public static GameManager instancia {get; private set;}
   [SerializeField] private List<string> fases;
   private int cenaAtual = 0;
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
    public void TrocarCena()
    {
        cenaAtual++;
        SceneManager.LoadScene(fases[cenaAtual]);
    }
}
