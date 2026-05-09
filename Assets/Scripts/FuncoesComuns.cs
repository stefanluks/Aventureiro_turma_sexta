using UnityEngine;

public class FuncoesComuns : MonoBehaviour
{
    public void TrocarDuranteAnimacao()
    {
        InterfaceControll.instancia.Trocar();
    }

    public void Desativar()
    {
        gameObject.SetActive(false);
    }
}
