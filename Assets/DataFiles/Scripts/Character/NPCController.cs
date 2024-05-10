using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    string _aldenCeloNarrationOne = "I am Alden, a name that speaks of companionship and longevity, traits I hold dear despite my rugged appearance. I am more than just a collection of discarded materials - earth, rubble, nuts, bolts, and moss, held together by unseen forces ; I am a guardian of this desolate realm, a sentinel watching over the remnants of a forgotten era.\r\n\r\nMy presence here is a testament to the resilience of life, even in the wake of destruction. As you stand before me, know that I am not just a relic of the past, but a steadfast ally in this harsh new world.";
    string _aldenCeloNarrationTwo = "Welcome to Celo Headquarters, adventurer. Here's a glimpse inside:\r\n\r\nEntrance Hall: It's like a town hall, buzzing with updates and project displays about Celo.\r\nMission Room: Real-time leaderboard sparks discussions on missions and feats.\r\nAmphitheater: Ascending seats hold Mechaguardians, with Alden at the center. Choose missions from revolving pathways, color-coded by difficulty.\r\nCommunication Chamber: A broken device hints at your journey's end. Gather parts, fix it, and find your way home.\r\nExplore these halls, where each corner hides a tale and every choice shapes your destiny.";
    string _aldenCeloNarrationThree = "You can choose your quests from the quest hall or receive latest updates from the Celo ecosystem in the governance room ";
    public List<string> _aldenCeloNarrations = new List<string>();
    public Stack<string> _aldenCeloNarrationsStack = new Stack<string>();
    public List<string> _flintNarrations = new List<string>();
    public List<string> _clarityNarrations = new List<string>();
    
    public Animator animator;
    public NavMeshAgent agent;
    public GameObject _canvas;
    public GameObject _navbar;
    public GameObject _celloGovernancePanel;
    public GameObject _celloQuestPanel;
    public GameObject _refiPanel;
    public GameObject _bankPanel;
    public GameObject _marketPanel;
    public GameObject _profilePanel;
    public Button _next;
    public Button _questRoom;
    public Button _governanceRoom;
    public Button _exit;
    public TMP_Text _narrationText;

    public bool _exited = false;

    private static readonly int IdleHash = Animator.StringToHash("Idle");
    private static readonly int RunHash = Animator.StringToHash("Run");
    private static readonly int Walk = Animator.StringToHash("Walk");
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator.SetBool(IdleHash, true);
        _aldenCeloNarrations.Add(_aldenCeloNarrationThree);
        _aldenCeloNarrations.Add(_aldenCeloNarrationTwo);
        _aldenCeloNarrations.Add(_aldenCeloNarrationOne);
        foreach (var message in _aldenCeloNarrations)
        {
            _aldenCeloNarrationsStack.Push(message);
        }
        
        //Assign the first message in the beganning
        var tempMessage = _aldenCeloNarrationsStack.Pop();
        _narrationText.text = tempMessage;


        if (npcType == NPCType.Alden)
        {
            if(building == Building.Celo)
            {
                _next.onClick.RemoveAllListeners();
                _next.onClick.AddListener(() => 
                {
                        var message = _aldenCeloNarrationsStack.Pop();
                        _narrationText.text = message;
                        if(_aldenCeloNarrationsStack.Count == 0)
                        {
                            _next.gameObject.SetActive(false);
                            _exit.gameObject.SetActive(true);
                            _governanceRoom.gameObject.SetActive(true);
                            _questRoom.gameObject.SetActive(true);
                            _exit.onClick.AddListener(() =>
                            {
                                _canvas.SetActive(false);
                                _exited = true;
                            });
                            _governanceRoom.onClick.AddListener(() =>
                            {
                                _canvas.SetActive(false);
                                _celloGovernancePanel.SetActive(true);
                            });
                            _questRoom.onClick.AddListener(() =>
                            {
                                _canvas.SetActive(false);
                                _celloQuestPanel.SetActive(true);
                            });
                            //_celloPanel.SetActive(true);
                            //_profilePanel.SetActive(false);
                        }
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
            _navbar.SetActive(false);
            _exited = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !_canvas.activeSelf && !_exited)
        {
            _canvas.SetActive(true);
            _navbar.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canvas.SetActive(false);
            _navbar.SetActive(true);
            _exited = false;
        }
    }
}
