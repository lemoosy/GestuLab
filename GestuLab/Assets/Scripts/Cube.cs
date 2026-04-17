using UnityEngine;

public class Cube : MonoBehaviour
{
    public Vector3 positonStart = Vector3.zero;
    public Quaternion rotationStart = Quaternion.identity;

    private void Start()
    {
        positonStart = transform.position;
        rotationStart = transform.rotation;
    }

    public void ResetTransform()
    {
        transform.position = positonStart;
        transform.rotation = rotationStart;
    }
}
