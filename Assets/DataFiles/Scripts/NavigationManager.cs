using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NavigationManager : MonoBehaviour
{
    public Button _navButton;
    public GameObject _navPanel;
    public Transform _player;
    public NavManager nav;
    public Transform navSpawn;

    public Transform[] _spawns;

    private void Start()
    {
        _navButton.onClick.AddListener(() => { _navPanel.SetActive(!_navPanel.activeSelf); });
        for (int i = 0; i < _spawns.Length; i++)
        {
            NavManager go = Instantiate(nav, navSpawn);
            int index = i;
            go.navName.text = $"{_spawns[index].name}";
            go.navCoords.text = $"{(int)_spawns[index].position.x}, {(int)_spawns[index].position.y}, {(int)_spawns[index].position.z}";
            go.go.onClick.AddListener(() => StartCoroutine(TP(_spawns[index])));
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
