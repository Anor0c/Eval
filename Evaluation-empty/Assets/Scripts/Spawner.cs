using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Collider2D playZone;
    public GameObject fruit;

    Vector2 minSpawnPos, maxSpawnPos;
    private void Start()
    {
        minSpawnPos = new Vector2(-17, -9);
        maxSpawnPos = new Vector2(17, 9);
        SpawnFruit();
    }
    public void SpawnFruit()
    {
        Instantiate(fruit);
        fruit.transform.position = new Vector3(Random.Range(minSpawnPos.x, maxSpawnPos.x), Random.Range(minSpawnPos.y, maxSpawnPos.y), 0);

    }
}
