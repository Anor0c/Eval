using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SnakeController : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject tail;
    public GameObject tailPart, gameOverCanvas;
   

    Vector2 currentInput;

    bool isAlive = true, fruitEaten = false;
    float lastMove;
    [SerializeField] float timeBeforeMove;
    [SerializeField] int eatenFruits;

    private void Start()
    {
        tail = new GameObject("Tail", typeof(BoxCollider2D));
        //Instantiate(tailPart, tail.transform);
        //tailPart.transform.position = new Vector3(1, 0, 0);
        rb = GetComponent<Rigidbody2D>();        
        StartCoroutine(Move());  
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        currentInput = context.ReadValue<Vector2>();
        currentInput = Vector2Int.CeilToInt(currentInput);
        Debug.Log(currentInput);
    }

    IEnumerator Move()
    {
        while (isAlive)
        {
            var emptySpace = rb.position;
            rb.MovePosition(currentInput + emptySpace);
            yield return null;
            foreach (Transform child in tail.transform)
            {
                var lastPosition = child.position;
                child.position = emptySpace;
                lastPosition = emptySpace;
            }
            yield return null;
            AddTailPart(emptySpace);
            yield return new WaitForSeconds(timeBeforeMove);
        }
        
    }
    void AddTailPart(Vector2 newPartPosition)
    {
        if (!fruitEaten)
            return;
        Instantiate(tailPart, tail.transform);
        tailPart.transform.position = newPartPosition;
        fruitEaten = false;
    }
    public void EatFruit()
    {
        eatenFruits++;
        fruitEaten = true;
    }
    void Die()
    {
        if (!isAlive)
            return;
        isAlive = false;
        Instantiate(gameOverCanvas);
        var gover = gameOverCanvas.GetComponent<ScoreDisplayer>();
        gover.SetScore(eatenFruits);
        Destroy(tail);
        Destroy(gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("PlayerZone"))
            return;
        Die();
    }
    private void OnTriggerEnter2D(Collider2D cld)
    {
        if (cld.gameObject.transform.parent != tail.transform)
            return;
        Die();
    }
}
