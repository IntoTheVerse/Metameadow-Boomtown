using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class SwitchBuildingConfirmationManager : MonoBehaviour
{
    public GameObject holder;
    public GameObject innerHolder;
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
        StartCoroutine(YesCoroutine());
    }

    private IEnumerator YesCoroutine()
    {
        innerHolder.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        innerHolder.SetActive(true);
        holder.SetActive(false);
    }

    public void No()
    {
        confirmation?.Invoke(false);
        holder.SetActive(false);
    }
}