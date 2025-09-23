using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.InputSystem;
public class movementscript : MonoBehaviour
{

    public float jumpHeight;
    public float moveSpeed;

    private Rigidbody2D rb2d;

    private float _movement;

    //this is to prevent double jumps
    public bool isGrounded;
    private SpriteRenderer Sprite;
    private GameObject boxRef;

    RaycastHit2D hitInfo;

   // the code that prevents the double jump
    public Vector2 boxSize = new Vector2(0.25f, 0.01f);
    public Vector3 boxoffset;

    // the code from the mario video that explains how box casting works.
    void FixedUpdate()
    {
        hitInfo = Physics2D.BoxCast(transform.position - new Vector3(0, Sprite.bounds.extents.y + boxSize.y + 0.01f, 0) + boxoffset, boxSize, 0, Vector2.down, boxSize.y);
        boxRef.transform.position = transform.position - new Vector3(0, Sprite.bounds.extents.y + boxSize.y + 0.01f, 0) + boxoffset;
        boxRef.transform.localScale = boxSize;

        if (hitInfo)
        {
            Debug.Log("touching the ground!=" + hitInfo.transform.gameObject.name);
            isGrounded = true;

        }

        else
        {
            Debug.Log("in the air >:(");
            isGrounded = false;
        }
    }
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Sprite = GetComponent<SpriteRenderer>();
        isGrounded = true;
        boxRef = GameObject.Find("BoxReference");
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.linearVelocityX = _movement;

    }

    public void Move(InputAction.CallbackContext ctx)
    {
        _movement = ctx.ReadValue<Vector2>().x * moveSpeed;
    }


    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 1 && isGrounded)
        {
            rb2d.linearVelocityY = jumpHeight;
        }


    }



}