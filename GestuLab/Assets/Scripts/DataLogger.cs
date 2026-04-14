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
        StartCoroutine(ExportData());
    }

    private IEnumerator ExportData()
    {
        while (true)
        {
            string logEntry = $"{Time.time:F2}, {redCube.transform.position}, {blueCube.transform.position}, {selectRedCube}, {selectBlueCube}\n";
            System.IO.File.AppendAllText(logFileName, logEntry);
            if (selectRedCube) selectRedCube = false;
            if (selectBlueCube) selectBlueCube = false;
            yield return new WaitForSeconds(logInterval);
        }
    }
}