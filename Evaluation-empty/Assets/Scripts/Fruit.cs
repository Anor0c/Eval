using UnityEngine;

public class Fruit : MonoBehaviour
{
    Spawner spawner;
    public GameObject fruitSpawner;

    private void Start()
    {
        spawner = fruitSpawner.GetComponent<Spawner>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var snake =collision.GetComponent<SnakeController>();
        if (collision.GetComponent<SnakeController>() == null)
            return;
        snake.EatFruit();
        if (!spawner)
            return;
        spawner.SpawnFruit();
    }
}
