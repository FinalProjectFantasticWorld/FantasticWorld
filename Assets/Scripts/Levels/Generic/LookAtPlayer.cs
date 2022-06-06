using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform player;
    private void LateUpdate()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player").transform;
            transform.LookAt(transform.position + player.forward);
        }
      
    }
}
