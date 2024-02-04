using UnityEngine;

public class AttachObjects : MonoBehaviour
{
    public GameObject prefabToSpawn; // Префаб объекта, который вы хотите создать
    public Transform spawnPoint; // Точка появления
    public void SpawnObject()
    {
        Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
    }
}