using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
public class GameCrontroller : MonoBehaviour
{
    Vector2 checkpointPos;
    Rigidbody2D playerRB;
   
    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

        checkpointPos = transform.position;



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die();
        }


    }




    public void UpdateCheckpoint(Vector2 pos)
    {
        checkpointPos = pos;
    }

    void Die()
    {
        StartCoroutine(Respawn(0.5f));
    }


    IEnumerator Respawn(float duration)
    {
       
        playerRB.simulated = false;
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = checkpointPos;
        transform.localScale = new Vector3(1, 1, 1);
        playerRB.simulated = true;
    }
}

