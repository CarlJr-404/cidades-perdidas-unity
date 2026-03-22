using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform alvo;
    public Vector3 offset = new Vector3(0, 4, -6);

    void LateUpdate()
    {
        if (alvo != null)
        {
            transform.position = alvo.position + offset;
            transform.LookAt(alvo.position + Vector3.up);
        }
    }
}