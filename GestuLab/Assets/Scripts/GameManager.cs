using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    private int GIFIndex = 0;

    [SerializeField] private List<VideoClip> VideoListGIF = new List<VideoClip>();

    [SerializeField] private List<string> DescriptionListGIF = new List<string>();

    [SerializeField] private GameObject redCube = null;

    [SerializeField] private GameObject blueCube = null;
    
    [SerializeField] private VideoPlayer videoGIF = null;

    [SerializeField] private TextMeshProUGUI descriptionGIF = null;

    [SerializeField] private float durationPerGIF = 15f;

    private void Start()
    {
        Debug.Assert(VideoListGIF.Count > 0, "VideoListGIF is empty. Please add video clips to the GIF Video List in the inspector.");
        Debug.Assert(DescriptionListGIF.Count > 0, "DescriptionListGIF is empty. Please add descriptions to the GIF Description List in the inspector.");
        Debug.Assert(VideoListGIF.Count == DescriptionListGIF.Count, "VideoListGIF and DescriptionListGIF must have the same number of elements. Please ensure both lists are synchronized in the inspector.");
        Debug.Assert(redCube != null, "redCube is not assigned. Please assign the Red Cube GameObject in the inspector.");
        Debug.Assert(blueCube != null, "blueCube Cube is not assigned. Please assign the Blue Cube GameObject in the inspector.");
        Debug.Assert(videoGIF != null, "videoGIF is not assigned. Please assign the VideoClip for the GIF in the inspector.");
        Debug.Assert(descriptionGIF != null, "descriptionGIF is not assigned. Please assign the TextMeshProUGUI component in the inspector.");
        StartCoroutine(DisplayGIF());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PreviousGIF();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextGIF();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            redCube.GetComponent<Cube>().ResetTransform();
            blueCube.GetComponent<Cube>().ResetTransform();
        }
    }

    private void PreviousGIF()
    {
        if (GIFIndex == 0) return;
        StopCoroutine(DisplayGIF());
        GIFIndex--;
        StartCoroutine(DisplayGIF());
    }

    private void NextGIF()
    {
        if (GIFIndex == VideoListGIF.Count - 1) return;
        StopCoroutine(DisplayGIF());
        GIFIndex++;
        StartCoroutine(DisplayGIF());
    }

    private IEnumerator DisplayGIF()
    {
        while (true)
        {
            descriptionGIF.text = DescriptionListGIF[GIFIndex];
            videoGIF.clip = VideoListGIF[GIFIndex];
            yield return new WaitForSeconds(durationPerGIF);
            NextGIF();
        }
    }
}