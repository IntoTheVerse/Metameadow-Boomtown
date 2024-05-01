using UnityEngine;

public class BuildingSwitchTrigger : MonoBehaviour
{
    public BuildingSwitch buildingToSwitch;
    private SwitchBuildingConfirmationManager switchConfirmManager;

    void Start()
    {
        switchConfirmManager = FindAnyObjectByType<SwitchBuildingConfirmationManager>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(buildingToSwitch.SpawnPlayer(other.gameObject));
            //gameObject.SetActive(false);
            /*switchConfirmManager.TakeConfirmation(gameObject.name, confirmation => 
            { 
                if(confirmation) StartCoroutine(buildingToSwitch.SpawnPlayer(other.gameObject));
                gameObject.SetActive(true);
            });*/
        }
    }
}