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
    Clarity,
    Veda
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

    string _vedaNarrationOne = "Greetings adventurer, have you come by for some shopping? Let me help you out. \r\n\r\nMy name is Veda, which in sanskrit translates to knowledge\r\n\r\nMy body is a marvel of the creator, comprised of nuts, bolts, and pipes intricately assembled to resemble the gracefulness of a fox, with steampunk goggles, a testament to my keen perception and unwavering focus, enhance my speed as I navigate you through our bustling marketplace in Metameadow Boomtown";
    string _vedaNarrationTwo = "Here amidst the marketplace, I serve two purposes. Not only do I assist in the sale of nuts, bolts, and pipes found scattered across the island, but I also aid you, the player, in acquiring the essentials needed to establish Boomtown. \r\n\r\nFrom agricultural bolts to cogs and pipes, my assistance would pave the way for your progress in this small yet wide world.";
    string _vedaNarrationThree = "Approach me with your needs, adventurer, and together, we shall forge a path towards prosperity and innovation in this wondrous land. Shall I assist you with some shopping?";

    string _flintNarrationOne = "Hello traveler, I'm Flint, the Rabbit - nice to meet you! I welcome to the world of bling bling - the mechaswap bank\r\n\r\nCrafted from bolts, nuts, cogs, and pipes seamlessly clicking together like a meticulous puzzle, my form mirrors the strength and ruggedness of my namesake, and a steampunk headdress, perched upon my head, I'm the unseen vigilante monitoring the ever-changing whims of the weather in the world of metameadow boomtown.";
    string _flintNarrationTwo = "The mechaswap bank has piles of bolt money and Celo in the shelves surrounding it, and I'm here right at your service. As you know Celo is the legal tender in this part of the world, so we offer you coins and currencies across the network, in a flash of a second as you order.";
    string _flintNarrationThree = "Would you like to receive some cUSD in exchange for Celo?";

    string _clarityNarrationOne = "Hello traveler I'm Clarity - here to serve you and provide tips and expert advice to help your plants grow. My form, fashioned in the likeness of a deer, embodies grace and serenity, a reflection of the tranquil haven we inhabit.";
    string _clarityNarrationTwo = "Welcome to the Refi House Orangery - made up of large glass windows and ceilings to optimize growing conditions.  Within these verdant confines, we offer more than just aesthetic beauty. As your humble steward, I stand ready to impart wisdom and expert advice to nurture your plants and cultivate abundance. Each week, the responsibility falls upon you to tend to the Tree of Life, a task that requires careful consideration of sunlight, soil consistency, and watering frequency.";
    string _clarityNarrationThree = "Here, amidst this lush sanctuary, thousands of travelers like yourself gather to water, tend to, and prune the plants, fostering a symbiotic relationship of mutual benefit. In return for your diligent care, ReFi scores and healthy morale abound, enriching not only your journey but the collective spirit of our community. So come, embrace the tranquility of this sanctuary, and let us together cultivate a legacy of abundance and growth.\r\n\r\nWould you like to proceed? ";

    public List<string> _aldenCeloNarrations = new List<string>();
    public Stack<string> _aldenCeloNarrationsStack = new Stack<string>();
    public List<string> _vedaNarrations = new List<string>();
    public Stack<string> _vedaNarrationsStack = new Stack<string>();
    public List<string> _flintNarrations = new List<string>();
    public Stack<string> _flintNarrationsStack = new Stack<string>();
    public List<string> _clarityNarrations = new List<string>();
    public Stack<string> _clarityNarrationsStack = new Stack<string>();
    
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
    public Button _yesBtn;
    public TMP_Text _narrationText;

    public bool _exited = false;

    private static readonly int IdleHash = Animator.StringToHash("Idle");
    private static readonly int RunHash = Animator.StringToHash("Run");
    private static readonly int Walk = Animator.StringToHash("Walk");
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator.SetBool(IdleHash, true);
        
        #region Alden
        if (npcType == NPCType.Alden)
        {
            
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
           
        }
        #endregion

        #region Veda
        else if (npcType == NPCType.Veda)
        {
           
            _vedaNarrations.Add(_vedaNarrationThree);
            _vedaNarrations.Add(_vedaNarrationTwo);
            _vedaNarrations.Add(_vedaNarrationOne);

            foreach (var message in _vedaNarrations)
            {
                _vedaNarrationsStack.Push(message);
            }


            //Assign the first message in the beganning
            var tempMessage = _vedaNarrationsStack.Pop();
            _narrationText.text = tempMessage;
        }
        #endregion

        #region Flint
        else if (npcType == NPCType.Flint)
        {

            _flintNarrations.Add(_flintNarrationThree);
            _flintNarrations.Add(_flintNarrationTwo);
            _flintNarrations.Add(_flintNarrationOne);

            foreach (var message in _flintNarrations)
            {
                _flintNarrationsStack.Push(message);
            }


            //Assign the first message in the beganning
            var tempMessage = _flintNarrationsStack.Pop();
            _narrationText.text = tempMessage;
        }
        #endregion

        #region Clarity
        else if (npcType == NPCType.Clarity)
        {

            _clarityNarrations.Add(_clarityNarrationThree);
            _clarityNarrations.Add(_clarityNarrationTwo);
            _clarityNarrations.Add(_clarityNarrationOne);

            foreach (var message in _clarityNarrations)
            {
                _clarityNarrationsStack.Push(message);
            }


            //Assign the first message in the beganning
            var tempMessage = _clarityNarrationsStack.Pop();
            _narrationText.text = tempMessage;
        }
        #endregion

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
        }
        else if (npcType == NPCType.Flint)
        {
            _next.onClick.RemoveAllListeners();
            _next.onClick.AddListener(() =>
            {
                var message = _flintNarrationsStack.Pop();
                _narrationText.text = message;
                if (_flintNarrationsStack.Count == 0)
                {
                    _next.gameObject.SetActive(false);
                    _exit.gameObject.SetActive(true);
                    _yesBtn.gameObject.SetActive(true);
                    _exit.onClick.AddListener(() =>
                    {
                        _canvas.SetActive(false);
                        _exited = true;
                    });
                    _yesBtn.onClick.AddListener(() =>
                    {
                        _bankPanel.SetActive(true);
                        _profilePanel.SetActive(false);
                        _canvas.SetActive(false);
                    });
                }
            });
        }
        else if (npcType == NPCType.Clarity)
        {
            _next.onClick.RemoveAllListeners();
            _next.onClick.AddListener(() =>
            {
                var message = _clarityNarrationsStack.Pop();
                _narrationText.text = message;
                if (_clarityNarrationsStack.Count == 0)
                {
                    _next.gameObject.SetActive(false);
                    _exit.gameObject.SetActive(true);
                    _yesBtn.gameObject.SetActive(true);
                    _exit.onClick.AddListener(() =>
                    {
                        _canvas.SetActive(false);
                        _exited = true;
                    });
                    _yesBtn.onClick.AddListener(() =>
                    {
                        _refiPanel.SetActive(true);
                        _profilePanel.SetActive(false);
                        _canvas.SetActive(false);
                    });
                }
            });
        }
        else if (npcType == NPCType.Veda)
        {
            _next.onClick.RemoveAllListeners();
            _next.onClick.AddListener(() =>
            {
                var message = _vedaNarrationsStack.Pop();
                _narrationText.text = message;
                if (_vedaNarrationsStack.Count == 0)
                {
                    _next.gameObject.SetActive(false);
                    _exit.gameObject.SetActive(true);
                    _yesBtn.gameObject.SetActive(true);
                    _exit.onClick.AddListener(() =>
                    {
                        _canvas.SetActive(false);
                        _exited = true;
                    });
                    _yesBtn.onClick.AddListener(() =>
                    {
                        _marketPanel.SetActive(true);
                        _profilePanel.SetActive(false);
                        _canvas.SetActive(false);
                    });
                }
                
            });
        }
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
