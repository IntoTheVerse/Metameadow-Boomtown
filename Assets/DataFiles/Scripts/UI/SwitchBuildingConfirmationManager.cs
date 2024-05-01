using System;
using TMPro;
using UnityEngine;

public class SwitchBuildingConfirmationManager : MonoBehaviour
{
    public GameObject holder;
    public TextMeshProUGUI headerText;
    private Action<bool> confirmation;
    public void TakeConfirmation(string buildingName, Action<bool> confirmation)
    {
        this.confirmation = confirmation;
        headerText.text = $"Do you want to go to {buildingName}?";
        holder.SetActive(true);
    }

    public void Yes()
    {
        confirmation?.Invoke(true);
        holder.SetActive(false);
    }

    public void No()
    {
        confirmation?.Invoke(false);
        holder.SetActive(false);
    }
}