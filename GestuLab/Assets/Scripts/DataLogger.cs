using System.Collections;
using UnityEngine;

public class DataLogger : MonoBehaviour
{
    [SerializeField] private string logFileName = "data_log.txt";

    [SerializeField] private float logInterval = 1f;

    [SerializeField] private GameObject redCube = null;

    [SerializeField] private GameObject blueCube = null;

    public bool pressLeftArrow = false;

    public bool pressRightArrow = false;

    private void Start()
    {
        logFileName = "Assets/Logs/" + logFileName;
        StartCoroutine(ExportData());
    }

    private IEnumerator ExportData()
    {
        while (true)
        {
            string logEntry = $"{Time.time:F2}, {redCube.transform.position}, {blueCube.transform.position}, {pressLeftArrow}, {pressRightArrow}\n";
            System.IO.File.AppendAllText(logFileName, logEntry);
            yield return new WaitForSeconds(logInterval);
        }
    }
}