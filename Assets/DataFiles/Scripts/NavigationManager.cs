using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NavigationManager : MonoBehaviour
{
    public Button _navButton;
    public GameObject _navPanel;
    public Transform _player;
    public GameObject nav;
    public Transform navSpawn;

    public Transform[] _spawns;

    private void Start()
    {
        _navButton.onClick.AddListener(() => { _navPanel.SetActive(!_navPanel.activeSelf); });
        for (int i = 0; i < _spawns.Length; i++)
        {
            GameObject go = Instantiate(nav, navSpawn);
            int index = i;
            go.GetComponentInChildren<TextMeshProUGUI>().text = $"{_spawns[index].name} [{_spawns[index].position}]";
            go.GetComponentInChildren<Button>().onClick.AddListener(() => StartCoroutine(TP(_spawns[index])));
        }
    }

    public IEnumerator TP(Transform to)
    {
        _player.GetComponent<Rigidbody>().isKinematic = true;
        _player.SetPositionAndRotation(to.position, to.rotation);
        yield return new WaitForSecondsRealtime(0.1f);
        _player.GetComponent<Rigidbody>().isKinematic = false;
    }
}
