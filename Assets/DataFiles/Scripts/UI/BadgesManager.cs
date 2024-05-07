using UnityEngine;
using UnityEngine.UI;

public class BadgesManager : MonoBehaviour
{
    public Sprite[] greyed;
    public Sprite[] original;
    public Image badge;
    public Transform spawner;

    private void Start() 
    {
        for (int i = 0; i < greyed.Length; i++)
        {
            Instantiate(badge, spawner).sprite = greyed[i];
        }    
    }
}