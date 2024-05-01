using UnityEngine;

public class BuildingSwitchTrigger : MonoBehaviour
{
    public BuildingSwitch buildingToSwitch;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            buildingToSwitch.SpawnPlayer(other.gameObject);
        }
    }
}