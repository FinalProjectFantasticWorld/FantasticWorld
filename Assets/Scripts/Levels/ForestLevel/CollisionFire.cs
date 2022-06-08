using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFire : MonoBehaviour
{
    [SerializeField] private LoseGame loseGame;
    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Fire")
        {
            loseGame.loseGame("GameOver","you touched the fire!");
        }
    }
}
