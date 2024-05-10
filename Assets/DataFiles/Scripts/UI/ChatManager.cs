using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    public Button chatButton;
    public GameObject chatPanel;

    private void Start()
    {
        chatButton.onClick.AddListener(() => { chatPanel.SetActive(!chatPanel.activeSelf); });
    }
}