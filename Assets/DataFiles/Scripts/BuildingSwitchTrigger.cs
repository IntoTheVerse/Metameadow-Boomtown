using UnityEngine;

public class BuildingSwitchTrigger : MonoBehaviour
{
    public BuildingSwitch buildingToSwitch;
    public GameObject map;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            buildingToSwitch.SpawnPlayer(other.gameObject);
            map.SetActive(false);
        }
    }
}