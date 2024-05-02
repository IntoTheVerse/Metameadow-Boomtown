using UnityEngine;

public class CloudsManager : MonoBehaviour
{
    public Transform[] cloudsSpawn;
    public GameObject[] clouds;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnCloud), 10, 10);
    }

    private void SpawnCloud()
    {
        Transform cloud = Instantiate(clouds[Random.Range(0, clouds.Length)], cloudsSpawn[Random.Range(0, cloudsSpawn.Length)]).transform;
        cloud.transform.localPosition = Vector3.zero;
        cloud.SetParent(transform);
    }
}