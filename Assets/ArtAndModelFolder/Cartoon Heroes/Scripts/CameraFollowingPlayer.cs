using Cinemachine;
using UnityEngine;

public class CameraFollowingPlayer  : MonoBehaviour
{
    public static CameraFollowingPlayer Instance;
    public GameObject Player;
    public CinemachineVirtualCamera VirtualCamera;

    [Header("Mouse zoom")]
    public bool enableMouseMovement = false;
    public bool notAssigned = false;

    private void Awake()
    {
        Instance = this;

    }

    private void Update()
    {
        if(Player != null && VirtualCamera != null && !notAssigned)
        {
            notAssigned = true;
            VirtualCamera.Follow = Player.transform;
            VirtualCamera.LookAt = Player.transform;
        }
    }
}
