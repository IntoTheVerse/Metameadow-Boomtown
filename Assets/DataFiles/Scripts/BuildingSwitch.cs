using UnityEngine;

public class BuildingSwitch : MonoBehaviour
{
    public Transform playerSpawn;

    public void SpawnPlayer(GameObject player)
    {
        Debug.Log(playerSpawn.position);
        Debug.Log(player.transform.position);
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.transform.position = playerSpawn.position;
        player.GetComponent<Rigidbody>().isKinematic = false;
        Debug.Log(player.transform.position);
    }
}