using UnityEngine;

/// <summary>
/// Spawns a number of objects using a selected collider type
/// Options: Box, Sphere, Capsule, and Mesh prefabs
/// </summary>
public class Spawner : MonoBehaviour
{
    public enum ColliderType
    {
        Box,
        Sphere,
        Capsule,
        Mesh
    }

    [Header("Spawner Settings")]
    [SerializeField] private ColliderType colliderType = ColliderType.Box;
    [SerializeField] private int objectCount = 100;
    [SerializeField] private Vector3 spawnAreaSize = new Vector3(10f, 0f, 10f);
    [SerializeField] private float minHeight = 5f;
    [SerializeField] private float maxHeight = 15f;

    [Header("Prefabs")]
    [SerializeField] private GameObject boxPrefab;
    [SerializeField] private GameObject spherePrefab;
    [SerializeField] private GameObject capsulePrefab;
    [SerializeField] private GameObject meshPrefab;

    private GameObject objectParent;

    void Start()
    {
        objectParent = new GameObject("SpawnedObjects");

        GameObject selectedPrefab = GetPrefabForCollider();

        for (int i = 0; i < objectCount; i++)
        {
            Vector3 pos = new Vector3(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                Random.Range(minHeight, maxHeight),
                Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
            );

            GameObject instance = Instantiate(selectedPrefab, pos, Quaternion.identity, objectParent.transform);
        }
    }

    /// <summary>
    /// Returns the prefab based on selected collider type.
    /// </summary>
    private GameObject GetPrefabForCollider()
    {
        return colliderType switch
        {
            ColliderType.Box => boxPrefab,
            ColliderType.Sphere => spherePrefab,
            ColliderType.Capsule => capsulePrefab,
            ColliderType.Mesh => meshPrefab,
            _ => boxPrefab
        };
    }
}
