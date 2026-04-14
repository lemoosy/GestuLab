using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int GIFIndex = 0;

    [SerializeField] private List<Sprite> GIFSpriteList = new List<Sprite>();

    [SerializeField] private List<string> GIFDescriptionList = new List<string>();

    [SerializeField] private GameObject redCube = null;

    [SerializeField] private GameObject blueCube = null;

    void Start()
    {
        Debug.Assert(GIFSpriteList.Count > 0, "GIFSpriteList is empty. Please add sprites to the GIF Sprite List in the inspector.");
        Debug.Assert(GIFDescriptionList.Count > 0, "GIFDescriptionList is empty. Please add descriptions to the GIF Description List in the inspector.");
        Debug.Assert(GIFSpriteList.Count == GIFDescriptionList.Count, "GIFSpriteList and GIFDescriptionList must have the same number of elements. Please ensure both lists are synchronized in the inspector.");
        Debug.Assert(redCube != null, "redCube is not assigned. Please assign the Red Cube GameObject in the inspector.");
        Debug.Assert(blueCube != null, "blueCube Cube is not assigned. Please assign the Blue Cube GameObject in the inspector.");
    }

    void Update()
    {
        // Commandes

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            redCube.GetComponent<Cube>().ResetTransform();
            blueCube.GetComponent<Cube>().ResetTransform();
        }
    }

    public void PreviousGIF()
    {
        GIFIndex--;
    }

    public void NextGIF()
    {
        GIFIndex++;
    }
}