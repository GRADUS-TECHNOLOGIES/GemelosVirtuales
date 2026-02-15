using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public int maxObjects = 3;

    private List<GameObject> spawnedObjects = new List<GameObject>();

    public void SpawnObject(string type)
    {
        if (spawnedObjects.Count >= maxObjects)
        {
            Debug.Log("⚠️ Máximo 3 objetos permitidos.");
            return;
        }

        GameObject obj = null;

        switch (type)
        {
            case "cube":
                obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                break;

            case "sphere":
                obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                break;

            case "capsule":
                obj = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                break;

            default:
                Debug.Log("❌ Tipo inválido.");
                return;
        }

        obj.transform.position = spawnPoint.position;

        Rigidbody rb = obj.AddComponent<Rigidbody>();
        rb.mass = 1;

        spawnedObjects.Add(obj);

        Debug.Log($"Objeto creado: {type}");
    }

    public void ClearObjects()
    {
        foreach (GameObject obj in spawnedObjects)
        {
            Destroy(obj);
        }

        spawnedObjects.Clear();
        Debug.Log("Objetos eliminados.");
    }
}
