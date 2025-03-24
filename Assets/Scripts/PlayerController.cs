using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 screenBounds;
    private float playerWidth;
    private float playerHeight;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Get the screen bounds in world units
        Vector3 screenBottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 screenTopRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        screenBounds = new Vector2(screenTopRight.x, screenTopRight.y);

        // Get player size (assumes a SpriteRenderer is attached)
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        playerWidth = spriteRenderer.bounds.extents.x;  // Half-width
        playerHeight = spriteRenderer.bounds.extents.y; // Half-height
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * speed;

        // Get the player's current position
        Vector2 newPosition = rb.position;

        // Clamp position within screen bounds, considering player size
        newPosition.x = Mathf.Clamp(newPosition.x, -screenBounds.x + playerWidth, screenBounds.x - playerWidth);
        newPosition.y = Mathf.Clamp(newPosition.y, -screenBounds.y + playerHeight, screenBounds.y - playerHeight);

        // Apply the clamped position
        rb.position = newPosition;
    }
}
