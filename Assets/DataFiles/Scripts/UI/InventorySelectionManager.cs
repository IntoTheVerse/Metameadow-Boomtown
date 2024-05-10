using UnityEngine;
using UnityEngine.UI;

public class InventorySelectionManager : MonoBehaviour
{
    public Button item;
    public GameObject selected;

    private void Start() 
    {
        item.onClick.AddListener(() => { selected.SetActive(!selected.activeSelf); });
    }
}