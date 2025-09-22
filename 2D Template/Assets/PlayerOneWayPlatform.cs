using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneWayPlatform : MonoBehaviour
{

    public GameObject currentOneWayPlatform;


    [SerializeField] private BoxCollider2D playerCollider2D;
    [SerializeField] private BoxCollider2D playerCollider2D1;
    [SerializeField] private BoxCollider2D playerCollider2D2;
    [SerializeField] private BoxCollider2D playerCollider2D3;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentOneWayPlatform != null)
            {
                StartCoroutine(DisableCollision());
            }
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(platformCollider, playerCollider2D);
        Physics2D.IgnoreCollision(platformCollider, playerCollider2D1);
        Physics2D.IgnoreCollision(platformCollider, playerCollider2D2);
        Physics2D.IgnoreCollision(platformCollider, playerCollider2D3);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(platformCollider, playerCollider2D, false);
        Physics2D.IgnoreCollision(platformCollider, playerCollider2D1, false);
        Physics2D.IgnoreCollision(platformCollider, playerCollider2D2, false); 
        Physics2D.IgnoreCollision(platformCollider, playerCollider2D3, false);
    }

}
