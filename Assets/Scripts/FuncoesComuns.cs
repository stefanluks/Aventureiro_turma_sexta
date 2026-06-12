using UnityEngine;

public class FuncoesComuns : MonoBehaviour
{
    public void TrocarDuranteAnimacao()
    {
        InterfaceControll.instancia.Trocar();
    }

    public void Desativar()
    {
        InterfaceControll.instancia.PararAudio();
        gameObject.SetActive(false);
    }
}
