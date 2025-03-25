using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 screenBounds;
    private float playerWidth;
    private float playerHeight;

     void Awake()
    {
        
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
        Vector3 screenBottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 screenTopRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        screenBounds = new Vector2(screenTopRight.x, screenTopRight.y);

        
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        playerWidth = spriteRenderer.bounds.extents.x;  
        playerHeight = spriteRenderer.bounds.extents.y; 
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement != Vector2.zero)
        {
        Debug.Log("Moving: " + movement);
        }
    }
    

    private void FixedUpdate()
    {
        rb.velocity = movement * speed;

       
        Vector2 newPosition = rb.position;

        
        newPosition.x = Mathf.Clamp(newPosition.x, -screenBounds.x + playerWidth, screenBounds.x - playerWidth);
        newPosition.y = Mathf.Clamp(newPosition.y, -screenBounds.y + playerHeight, screenBounds.y - playerHeight);

        
        rb.position = newPosition;
    }
}
