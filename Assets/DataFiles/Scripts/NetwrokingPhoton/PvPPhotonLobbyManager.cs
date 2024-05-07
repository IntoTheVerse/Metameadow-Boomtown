using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PvPPhotonLobbyManager : MonoBehaviourPunCallbacks
{
   public PlayerRoomProfile _profile;
   public List<PlayerRoomProfile> _profileList = new List<PlayerRoomProfile>();

   public RoomItem roomItemPrefab;
   private List<RoomItem> roomItemList = new List<RoomItem>();

   public float timeBetweenUpdates = 1.5f;
   private float nextUpdateTime;

   public GameObject playerProfile;
   public GameObject loadingScene;
   public TextMeshProUGUI loadingText;
   public Image loadingBar;

   private void Start()
    {
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
        // Add a callback for when the client is connected to the Master Server
    }

    public override void OnConnectedToMaster()
    {
        // This callback is triggered when the client is connected to the Master Server
        // Now, you can attempt to join a random room
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    private void PlayGame()
   {
      /*
      SceneManager.instance.LoadScene("PvP");
      */
      PhotonNetwork.JoinRandomOrCreateRoom();
   }

   public override void OnJoinedRoom()
   {
      PhotonNetwork.LoadLevel("World");
      FindObjectOfType<MenuCharacterManager>().ShowSelectedCharacter(WalletManager.Instance.Character);
      loadingScene.SetActive(true);
      StartCoroutine(LoadingEnum());
      //UpdatePlayerRoomList();
   }

   private IEnumerator LoadingEnum()
   {
      while (PhotonNetwork.LevelLoadingProgress < 1)
      {
         loadingBar.fillAmount = PhotonNetwork.LevelLoadingProgress;
         loadingText.text = $"{(int)(PhotonNetwork.LevelLoadingProgress * 100)}%";
         yield return new WaitForEndOfFrame();
      }
   }

   public override void OnPlayerEnteredRoom(Player newPlayer)
   {
      //UpdatePlayerRoomList();
   }

   public override void OnPlayerLeftRoom(Player otherPlayer)
   {
      //UpdatePlayerRoomList();
   }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);
        PlayGame();
    }

    public void JoinRoom(string roomNameText)
   {
      PhotonNetwork.JoinRoom(roomNameText);
   }

   public void LeaveRoom()
   {
      PhotonNetwork.LeaveRoom();
   }

   public override void OnLeftRoom()
   {
   }
}
