using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFire : MonoBehaviour
{
    [Tooltip("what happens when you lose/win game.")] [SerializeField] private LoseGame loseGame;
    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Fire")
        {
            loseGame.loseGame("GameOver","you touched the fire!");
        }
    }
}
