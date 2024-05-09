using TMPro;
using UnityEngine;

public class CopyText : MonoBehaviour
{
    public void Copy(TextMeshProUGUI text)
    {
        GUIUtility.systemCopyBuffer = text.text;
    }
}