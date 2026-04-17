using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    private int GIFIndex = 0;

    [SerializeField] private List<VideoClip> videoListGIF = new List<VideoClip>();

    [SerializeField] private List<string> descriptionListGIF = new List<string>();

    [SerializeField] private List<AudioClip> audioListGIF = new List<AudioClip>();

    [SerializeField] private AudioSource audioSource = null;

    [SerializeField] private GameObject redCube = null;

    [SerializeField] private GameObject blueCube = null;
    
    [SerializeField] private VideoPlayer videoGIF = null;

    [SerializeField] private TextMeshProUGUI descriptionGIF = null;

    [SerializeField] private TextMeshProUGUI GIFCounter = null;

    [SerializeField] private DataLogger dataLogger = null;

    private void Start()
    {
        Debug.Assert(videoListGIF.Count > 0, "videoListGIF is empty. Please add video clips to the GIF Video List in the inspector.");
        Debug.Assert(descriptionListGIF.Count > 0, "descriptionListGIF is empty. Please add descriptions to the GIF Description List in the inspector.");
        Debug.Assert(audioListGIF.Count > 0, "audioListGIF is empty. Please add audio clips to the GIF Audio List in the inspector.");
        Debug.Assert(videoListGIF.Count == descriptionListGIF.Count, "videoListGIF and descriptionListGIF must have the same number of elements. Please ensure both lists are synchronized in the inspector.");
        Debug.Assert(videoListGIF.Count == audioListGIF.Count, "videoListGIF and audioListGIF must have the same number of elements. Please ensure both lists are synchronized in the inspector.");
        Debug.Assert(audioSource != null, "audioSource is not assigned. Please assign an AudioSource component in the inspector.");
        Debug.Assert(redCube != null, "redCube is not assigned. Please assign the Red Cube GameObject in the inspector.");
        Debug.Assert(blueCube != null, "blueCube Cube is not assigned. Please assign the Blue Cube GameObject in the inspector.");
        Debug.Assert(videoGIF != null, "videoGIF is not assigned. Please assign the VideoClip for the GIF in the inspector.");
        Debug.Assert(descriptionGIF != null, "descriptionGIF is not assigned. Please assign the TextMeshProUGUI component in the inspector.");
        Debug.Assert(dataLogger != null, "dataLogger is not assigned. Please assign the DataLogger component in the inspector.");
        ResetGIF();
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

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ResetGIF();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            redCube.GetComponent<Cube>().ResetTransform();
            blueCube.GetComponent<Cube>().ResetTransform();
        }

        foreach (var device in InputSystem.devices)
        {
            foreach (var control in device.allControls)
            {
                if (control is ButtonControl button)
                {
                    if (button.wasPressedThisFrame)
                    {
                        dataLogger.GetComponent<DataLogger>().ExportData(
                            GIFIndex,
                            button.name,
                            true
                        );
                    }

                    if (button.wasReleasedThisFrame)
                    {
                        dataLogger.GetComponent<DataLogger>().ExportData(
                            GIFIndex,
                            button.name,
                            false
                        );
                    }
                }
            }
        }
    }

    private void PreviousGIF()
    {
        if (GIFIndex == 0) return;
        GIFIndex--;
        descriptionGIF.text = descriptionListGIF[GIFIndex];
        videoGIF.clip = videoListGIF[GIFIndex];
        audioSource.clip = audioListGIF[GIFIndex];
        audioSource.Play();
        GIFCounter.text = $"{GIFIndex + 1} / 15";
    }

    private void NextGIF()
    {
        if (GIFIndex == descriptionListGIF.Count - 1) return;
        GIFIndex++;
        descriptionGIF.text = descriptionListGIF[GIFIndex];
        videoGIF.clip = videoListGIF[GIFIndex];
        audioSource.clip = audioListGIF[GIFIndex];
        audioSource.Play();
        GIFCounter.text = $"{GIFIndex + 1} / 15";
    }

    public void ResetGIF()
    {
        videoGIF.clip = videoListGIF[GIFIndex];
        videoGIF.Play();
        audioSource.clip = audioListGIF[GIFIndex];
        audioSource.Play();
        descriptionGIF.text = descriptionListGIF[GIFIndex];
        GIFCounter.text = $"{GIFIndex + 1} / 15";
    }

    public void SelectRedCube()
    {
        dataLogger.selectRedCube = true;
    }

    public void SelectBlueCube()
    {
        dataLogger.selectBlueCube = true;
    }
}