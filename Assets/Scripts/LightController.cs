using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour
{
    public float speed = 3f;
    public Vector2 minBounds;
    public Vector2 maxBounds;
    public float startDelay = 5f; 
    public GameManager gameManager;
    
    private Vector2 targetPosition;
    private SpriteRenderer spriteRenderer;
    private Collider2D lightCollider;
    private bool canMove = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        lightCollider = GetComponent<Collider2D>();

        
        spriteRenderer.enabled = false;
        lightCollider.enabled = false;

        StartCoroutine(ActivateAfterDelay());
    }

    private IEnumerator ActivateAfterDelay()
    {
        yield return new WaitForSeconds(startDelay);

        
        spriteRenderer.enabled = true;
        lightCollider.enabled = true;
        canMove = true;

        SetNewTargetPosition();
    }

    private void Update()
    {
        if (!canMove) return;

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPosition) < 0.5f)
        {
            SetNewTargetPosition();
        }
    }

    private void SetNewTargetPosition()
    {

        Camera cam = Camera.main;
        if (cam == null)
        {
            Debug.LogError("Main Camera not found!");
            return;
        }

        
        Vector2 bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector2 topRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        
        float randomX = Random.Range(bottomLeft.x, topRight.x);
        float randomY = Random.Range(bottomLeft.y, topRight.y);

        targetPosition = new Vector2(randomX, randomY);

        Debug.Log("New Target Position: " + targetPosition);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameManager != null){
                gameManager.GameOver();
            }
            else   {
                Debug.Log("it is not working");
            }
        }
    }
}

