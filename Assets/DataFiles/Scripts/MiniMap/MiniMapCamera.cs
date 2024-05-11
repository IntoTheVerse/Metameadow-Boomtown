using Invector.vCharacterController;
using System;
using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{
    public Transform target;
           public float height = 100;
           public bool followPosition; //should the camera rotate with the target
           public bool followRotation; //should the camera rotate with the target

    void Update()
    {
        try
        {
            if (!target )
            {
                var players = FindObjectsOfType<vThirdPersonController>();
                foreach ( vThirdPersonController p in players)
                {
                    if (p.photonView.IsMine)
                    {
                        target = FindObjectOfType<vThirdPersonController>().transform;
                    }
                }
            }
        }
        catch (Exception e)
        {
        }
    }

    void LateUpdate()
           {
               if (!target) return;
   
               if (followRotation)
                   transform.eulerAngles = new Vector3(transform.eulerAngles.x, target.eulerAngles.y, transform.eulerAngles.z);
   
               if (followPosition)
                   transform.position = new Vector3(target.position.x, height, target.position.z);
           }
}
