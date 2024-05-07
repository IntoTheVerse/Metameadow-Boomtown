using Photon.Pun;
using UnityEngine;

public class PvPConnectToServer : MonoBehaviourPunCallbacks
{
    public GameObject _lobbyManager;

    private void Start()
    {
        PhotonNetwork.Disconnect();
    }

    public void Connect()
    {
        PhotonNetwork.NickName = WalletManager.Instance.Username;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        _lobbyManager.SetActive(true);
    }
}
