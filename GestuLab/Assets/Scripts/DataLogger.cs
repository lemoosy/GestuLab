using System.Collections;
using UnityEngine;

public class DataLogger : MonoBehaviour
{
    [SerializeField] private string logFileName = "data_log.txt";

    [SerializeField] private float logInterval = 0.5f;

    [SerializeField] private GameObject redCube = null;

    [SerializeField] private GameObject blueCube = null;

    public bool selectRedCube = false;

    public bool selectBlueCube = false;

    private void Start()
    {
        logFileName = "Assets/Logs/" + logFileName;
    }

    public void ExportData(int idGIF, string butonName, bool press)
    {
        string logEntry = $"" +
            $"{Time.time:F2}," +
            $"{idGIF}," +
            $"{butonName}," +
            $"{press}," +
            $"{redCube.transform.position}," +
            $"{redCube.transform.rotation}," +
            $"{blueCube.transform.position}," +
            $"{blueCube.transform.rotation}\n";

        System.IO.File.AppendAllText(logFileName, logEntry);
    }
}