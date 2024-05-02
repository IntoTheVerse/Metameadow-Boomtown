using UnityEngine;

public class Cloud : MonoBehaviour
{
    void Update()
    {
        transform.position -= new Vector3(Time.deltaTime * 30, 0, 0);
        if (transform.localPosition.x < -2800) Destroy(gameObject);
    }
}
