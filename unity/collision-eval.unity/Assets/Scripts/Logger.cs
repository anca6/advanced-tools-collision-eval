using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.IO;

/// <summary>
/// Logs average FPS over a defined duration and saves results to a CSV under Assets/Data.
/// </summary>
public class Logger : MonoBehaviour
{
    [Header("Test Info")]
    [SerializeField] private string shape = "Box";      // Set manually per test (Box, Sphere, etc.)
    [SerializeField] private int objectCount = 100;     // Match Spawner count
    [SerializeField] private float logDuration = 30f;   // Time to collect FPS samples

    private List<float> frameTimes = new List<float>();
    private float startTime;
    private bool hasLogged = false;

    private string filePath;

    void Start()
    {
        startTime = Time.time;

        string folderPath = Path.Combine(Application.dataPath, "Data");
        Directory.CreateDirectory(folderPath); // Create folder if it doesn't exist

        filePath = Path.Combine(folderPath, $"{shape}_results.csv");

        // Add headers if the file is new
        if (!File.Exists(filePath))
        {
            File.AppendAllText(filePath, "Shape,ObjectCount,Duration,AverageFPS\n");
        }
    }

    void Update()
    {
        frameTimes.Add(Time.deltaTime);

        if (!hasLogged && Time.time - startTime >= logDuration)
        {
            float avgDelta = frameTimes.Average();
            float avgFPS = 1f / avgDelta;

            string line = $"{shape},{objectCount},{logDuration},{avgFPS:F2}\n";
            File.AppendAllText(filePath, line);

            Debug.Log($"[Logger] Saved: {line.Trim()}");
            hasLogged = true;
        }
    }
}
