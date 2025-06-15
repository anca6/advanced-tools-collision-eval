using UnityEngine;

/// <summary>
/// Spawns a configurable number of objects at random positions within a defined area
/// Objects are instantiated at random heights and parented under a game object
/// </summary>
public class Spawner : MonoBehaviour
{
    //defining the collider shapes for spawning
    private enum ColliderShape { BOX, SPHERE }

    [SerializeField] private ColliderShape shape = ColliderShape.BOX;
    [Space]
    [SerializeField] private GameObject boxPrefab;
    [SerializeField] private GameObject spherePrefab;
    [Space]
    [SerializeField] private int objectCount;
    [SerializeField] private Vector3 spawnArea = new Vector3(10f, 0f, 10f);
    [SerializeField] private float minHeight = 5f;
    [SerializeField] private float maxHeight = 15f;

    private GameObject parentObj; //parent object to organize all spawned objects

    /// <summary>
    /// Initializes and spawns objects when the scene starts
    /// </summary>
    private void Start()
    {
        parentObj = new GameObject("SpawnedObjects");

        GameObject selectedPrefab = GetSelectedPrefab();

        for (int i = 0; i < objectCount; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(-spawnArea.x / 2f, spawnArea.x / 2f),
                Random.Range(minHeight, maxHeight),
                Random.Range(-spawnArea.z / 2f, spawnArea.z / 2f)
            );

            GameObject instance = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity, parentObj.transform);
        }
    }

    /// <summary>
    /// Returns the prefab to spawn based on the selected collider shape
    /// </summary>
    private GameObject GetSelectedPrefab()
    {
        switch (shape)
        {
            case ColliderShape.BOX:
                return boxPrefab;
            case ColliderShape.SPHERE:
                return spherePrefab;
            default:
                Debug.LogWarning("No collider shape selected. Switch to default: box.");
                return boxPrefab;
        }
    }
}
