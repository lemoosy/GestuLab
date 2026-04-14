using UnityEngine;

public class Cube : MonoBehaviour
{
    private Transform transformBase = null;

    private void Start()
    {
        transformBase = transform;
    }

    public void ResetTransform()
    {
        transform.position = transformBase.position;
        transform.rotation = transformBase.rotation;
    }
}
