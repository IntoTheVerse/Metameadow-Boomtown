using System.Collections;
using UnityEngine;

public class BuildingSwitch : MonoBehaviour
{
    public Transform playerSpawn;

    public IEnumerator SpawnPlayer(GameObject player)
    {
        Debug.LogError("Teleporting");
        player.GetComponent<Rigidbody>().isKinematic = true;
        yield return new WaitForSecondsRealtime(0.1f);
        player.transform.position = playerSpawn.position;
        player.GetComponent<Rigidbody>().isKinematic = false;
    }
}