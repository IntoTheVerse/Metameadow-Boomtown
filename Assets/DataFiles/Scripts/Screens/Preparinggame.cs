using TMPro;
using UnityEngine;

public class Preparinggame : MonoBehaviour
{
    public GameObject[] selectedCharacters;
    public TextMeshProUGUI username;
    public TextMeshProUGUI walletAddress;
    public TextMeshProUGUI profileWalletAddress;
    public TextMeshProUGUI currency;

    public void Start()
    {
        ShowSelectedCharacter(WalletManager.Instance.Character);
        username.text = WalletManager.Instance.Username;
        walletAddress.text = WalletManager.Instance.WalletAddress;
        profileWalletAddress.text = WalletManager.Instance.WalletAddress;
        currency.text = WalletManager.Instance.Currency;
    }

    public void ShowSelectedCharacter(int val)
    {
        SkinnedMeshRenderer[] renderers = selectedCharacters[val].GetComponentsInChildren<SkinnedMeshRenderer>();
        for (int j = 0; j < renderers.Length; j++)
        {
            renderers[j].sharedMaterial.color = Color.white;
        }
        selectedCharacters[val].SetActive(true);
    }
}
