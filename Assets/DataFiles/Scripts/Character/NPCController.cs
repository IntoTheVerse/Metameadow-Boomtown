using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public enum NPCType
{
    Alden,
    Flint,
    Clarity
}


public enum Building
{
    Refi,
    Bank,
    Market,
    Celo
}

public class NPCController : MonoBehaviour
{
    public NPCType npcType;
    public Building building;
    public Animator animator;
    public NavMeshAgent agent;
    public GameObject _canvas;
    public GameObject _celloPanel;
    public GameObject _refiPanel;
    public GameObject _bankPanel;
    public GameObject _marketPanel;
    public GameObject _profilePanel;
    public Button _next;

    private static readonly int IdleHash = Animator.StringToHash("Idle");
    private static readonly int RunHash = Animator.StringToHash("Run");
    private static readonly int Walk = Animator.StringToHash("Walk");
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator.SetBool(IdleHash, true);

        if(npcType == NPCType.Alden)
        {
            if(building == Building.Celo)
            {
                _next.onClick.RemoveAllListeners();
                _next.onClick.AddListener(() => 
                {
                    _celloPanel.SetActive(true);
                    _profilePanel.SetActive(false);
                });
            }
            else if(building == Building.Market) 
            {
                _next.onClick.RemoveAllListeners();
                _next.onClick.AddListener(() =>
                {
                    _marketPanel.SetActive(true);
                    _profilePanel.SetActive(false);
                });
            }
        }
        else if (npcType == NPCType.Flint)
        {
            _next.onClick.RemoveAllListeners();
            _next.onClick.AddListener(() =>
            {
                _bankPanel.SetActive(true);
                _profilePanel.SetActive(false);
            });
        }
        else if (npcType == NPCType.Clarity)
        {
            _next.onClick.RemoveAllListeners();
            _next.onClick.AddListener(() =>
            {
                _refiPanel.SetActive(true);
                _profilePanel.SetActive(false);
            });
        }
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canvas.SetActive(false);
        }
    }
}
