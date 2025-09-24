using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticleController : MonoBehaviour
{

    [SerializeField] ParticleSystem momevementParticle;

    [Range(0, 10)]
    [SerializeField] int occurAfterVelocity;
    [Range(0,0.2f)]
   [SerializeField] float dustFormationPeriod;

    [SerializeField] Rigidbody2D playerRb;

    float counter;

 
    private void Update()
    {
        counter += Time.deltaTime;

        if (MathF.Abs(playerRb.linearVelocity.x) > occurAfterVelocity)
        {
            if (counter > dustFormationPeriod)
                {
                    momevementParticle.Play();
                counter = 0;

            }
        }
    }



}
