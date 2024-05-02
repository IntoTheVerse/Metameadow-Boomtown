using System.Collections;
using UnityEngine;

public class BuildingSwitch : MonoBehaviour
{
    public Transform playerSpawn;

    public IEnumerator SpawnPlayer(GameObject player)
    {
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.transform.position = playerSpawn.position;
        yield return new WaitForSecondsRealtime(0.1f);
        player.GetComponent<Rigidbody>().isKinematic = false;
    }
}