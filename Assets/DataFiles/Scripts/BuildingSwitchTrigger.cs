using UnityEngine;

public class BuildingSwitchTrigger : MonoBehaviour
{
    public GameObject minimap;
    public bool turnOffMinimap = false;
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
            switchConfirmManager.TakeConfirmation(gameObject.name, confirmation => 
            {
                if (confirmation) 
                {
                    StartCoroutine(buildingToSwitch.SpawnPlayer(other.gameObject));
                    minimap.SetActive(!turnOffMinimap);
                }
            });
        }
    }
}