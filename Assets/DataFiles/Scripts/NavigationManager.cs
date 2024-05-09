using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class NavigationManager : MonoBehaviour
{
    public TMP_Dropdown _navDropdown;
    public Transform _player;

    public Transform _celoSpts;
    public Transform _refiSpts;
    public Transform _marketSpts;
    public Transform _bankSpts;

    private void Start()
    {
        for (int i = 1; i < _navDropdown.options.Count; i++)
        {
            var option = _navDropdown.options[i];

            if (option != null)
            {
                // Assign a name to the option
                if(i == 1)
                {
                    option.text = "Celo " + _celoSpts.position.ToString();

                    Debug.Log("Option " + (i + 1).ToString() + " is at index " + i.ToString());
                }else if (i == 2)
                {
                    option.text = "Market " + _marketSpts.position.ToString();

                    Debug.Log("Option " + (i + 1).ToString() + " is at index " + i.ToString());
                }
                else if (i == 3)
                {
                    option.text = "Refi " + _refiSpts.position.ToString();

                    Debug.Log("Option " + (i + 1).ToString() + " is at index " + i.ToString());
                }
                else if (i == 4)
                {
                    option.text = "Bank " + _bankSpts.position.ToString();

                    Debug.Log("Option " + (i + 1).ToString() + " is at index " + i.ToString());
                }
            }
        }
    }

    public void Teleport()
    {
        if (_navDropdown.value == 1)
        {
            StartCoroutine(TP(_player, _celoSpts));
        }else if(_navDropdown.value == 2)
        {
            StartCoroutine(TP(_player, _marketSpts));
        }
        else if (_navDropdown.value == 3)
        {
            StartCoroutine(TP(_player, _refiSpts));
        }
        else if (_navDropdown.value == 4)
        {
            StartCoroutine(TP(_player, _bankSpts));
        }
    }
    public IEnumerator TP(Transform player, Transform to)
    {
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.position = to.position;
        player.rotation = to.rotation;
        yield return new WaitForSecondsRealtime(0.1f);
        player.GetComponent<Rigidbody>().isKinematic = false;
    }
}
