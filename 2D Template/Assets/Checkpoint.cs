using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Checkpoint : MonoBehaviour
{
    GameCrontroller gameCrontroller;


    private void Awake()
    {
        gameCrontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<GameCrontroller>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameCrontroller.UpdateCheckpoint(transform.position);
        }
    }









}
