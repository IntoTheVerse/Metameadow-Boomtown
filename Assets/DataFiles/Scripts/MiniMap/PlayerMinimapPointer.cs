using Photon.Pun;
using UnityEngine;

public class PlayerMinimapPointer : MonoBehaviourPunCallbacks
{
    public Transform target;
    public float height = 25.0f;
    public float wantedHeight;
    public float smoothness = 5.0f;
    public float rotationSpeed = 5.0f;
    public int markerSize = 25;
    public bool targetFound = false;
    public bool playersPointer = false;

    public MeshRenderer _mesh;
    public Material localPlayerMat;
    public Material otherPlayerMat;

    private void Awake()
    {
        transform.localScale = new Vector3(markerSize, 0.1f, markerSize);
    }
    void Start()
    {
        if (target != null)
        {
            wantedHeight = target.position.y + height;
        }
        if (photonView.IsMine)
        {
            _mesh.material = localPlayerMat;
        }else if(!photonView.IsMine)
        {
            _mesh.material = otherPlayerMat;
        }
    }

    void Update()
    {
        if (target != null)
        {
            // Smoothly move towards the target position
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, wantedHeight, target.position.z), Time.deltaTime * smoothness);

            // Smoothly rotate towards the target rotation
            if (playersPointer)
            {
                //Debug.LogError("Pointer Moving");
                Quaternion targetRotation = Quaternion.LookRotation(target.forward, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }
            else
            {

            }
        }
        else if (!target)
        {
            if (!targetFound)
            {
                return;
            }
            else if (targetFound)
            {
                Destroy(gameObject);
            }
        }
    }
}
