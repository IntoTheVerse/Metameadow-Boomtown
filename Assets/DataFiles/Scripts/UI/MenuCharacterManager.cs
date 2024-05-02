using UnityEngine;
using UnityEngine.UI;

public class MenuCharacterManager : MonoBehaviour
{
    public GameObject[] characters;
    public Button[] characterButtons;
    private GameObject lastSelectedCharacter = null;

    private void Start()
    {
        for (int i = 0; i < characterButtons.Length; i++)
        {
            int val = 3 - i;
            characterButtons[i].onClick.AddListener(() => OnCharacterSelect(val));
        }
        OnCharacterSelect(3);
    }

    private void OnCharacterSelect(int val)
    {
        if (lastSelectedCharacter != null)
        {
            LeanTween.scale(lastSelectedCharacter, new(80, 80, 80), 0.2f);
        }

        for (int i = 0; i < characters.Length; i++)
        {
            SkinnedMeshRenderer[] renderers = characters[i].GetComponentsInChildren<SkinnedMeshRenderer>();
            for (int j = 0; j < renderers.Length; j++)
            {
                renderers[j].sharedMaterial.color = i == val ? Color.white : new Color(0.1f, 0.1f, 0.1f);
            }
            if (i == val)
            {
                lastSelectedCharacter = characters[i];
                characters[i].GetComponent<Animator>().enabled = true;
                LeanTween.scale(characters[i], new(120, 120, 120), 0.2f);
            }
            else
                characters[i].GetComponent<Animator>().enabled = false;
        }
    }
}