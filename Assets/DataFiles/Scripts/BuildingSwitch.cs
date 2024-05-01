using UnityEngine;

public class BuildingSwitch : MonoBehaviour
{
    public Transform playerSpawn;

    public void SpawnPlayer(GameObject player)
    {
        player.transform.position = playerSpawn.position;
    }
}