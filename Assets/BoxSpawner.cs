using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject boxPrefab;
    public float spawnInterval = 1.5f;
    public Vector2 spawnPosition;  // Adicione esta variável para armazenar a posição de spawn

    void Start()
    {
        InvokeRepeating("SpawnBox", 0f, spawnInterval);
    }

    void SpawnBox()
    {
        GameObject newBox = Instantiate(boxPrefab, spawnPosition, Quaternion.identity);
        newBox.GetComponent<Rigidbody2D>().gravityScale = 5f;  // Ajuste conforme necessário
    }
}
