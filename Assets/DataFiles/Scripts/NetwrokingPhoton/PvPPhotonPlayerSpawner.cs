using Invector.vCharacterController;
using Photon.Pun;
using UnityEngine;

public class PvPPhotonPlayerSpawner : MonoBehaviourPunCallbacks
{
    public GameObject []_playerPrefab;
    public GameObject _playerPointerPrefab;
    public NavigationManager _navigationManager;
    public GameObject[] _spawnPoints;

    public GameObject _spawnEffect;

    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        // Check if the local player is the master client
        if (PhotonNetwork.IsMasterClient && PhotonNetwork.LocalPlayer.IsLocal)
        {
            Debug.LogError("Spawning Player");
            photonView.RPC("SpawnPlayer", RpcTarget.AllBuffered);
        }
        else
        {
            // For non-master clients or non-local players, set the spawn point index received from the master client.
            int spawnPointIndex = UnityEngine.Random.Range(0, _spawnPoints.Length);
            photonView.RPC("SetSpawnPointIndex", RpcTarget.AllBuffered, spawnPointIndex);
        }
    }

    [PunRPC]
    private void SetSpawnPointIndex(int index)
    {
        // Set the spawn point index received from the master client.
        if (!PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            Debug.LogError("Setting Spawn Point Index");
            int spawnPointIndex = Mathf.Clamp(index, 0, _spawnPoints.Length - 1);
            photonView.Owner.CustomProperties["SpawnPointIndex"] = spawnPointIndex;
        }
    }

    [PunRPC]
    private void SpawnPlayer()
    {
        int spawnPointIndex = 0;

        Debug.LogError("Spawning Player");
        // Retrieve the spawn point index from room properties.
        if (PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue("SpawnPointIndex", out object spawnPointObj))
        {
            spawnPointIndex = (int)spawnPointObj;
        }

        Vector3 spawnPosition = new Vector3(_spawnPoints[spawnPointIndex].transform.position.x + UnityEngine.Random.Range(-2,2), _spawnPoints[spawnPointIndex].transform.position.y, _spawnPoints[spawnPointIndex].transform.position.z + UnityEngine.Random.Range(-2, 2));

        // Spawn the player across the network.
        var player = PhotonNetwork.Instantiate(_playerPrefab[WalletManager.Instance.Character].name, spawnPosition, Quaternion.identity);
        var playerPointer = PhotonNetwork.Instantiate(_playerPointerPrefab.name, Vector3.zero, Quaternion.identity);
        playerPointer.GetComponent<PlayerMinimapPointer>().target = player.transform;
        player.GetComponent<vThirdPersonController>()._playerPointer = playerPointer;
        player.GetComponent<vThirdPersonController>().SetPlayerPointer();
        if (player.GetComponent<vThirdPersonController>().photonView.IsMine)
        {
            _navigationManager._player = player.transform;
        }
    }
}
