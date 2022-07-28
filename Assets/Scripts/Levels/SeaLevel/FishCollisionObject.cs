using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishCollisionObject : MonoBehaviour
{
    [Tooltip("LoseGame")] [SerializeField] private LoseGame loseGame;
    private void OnCollisionStay(Collision collision)
    {
        if(collision.transform.tag == "pickup")
        {
            //Destroy(collision.gameObject);
            //Destroy(this.gameObject);
            loseGame.loseGame("GameOver","the fish ate garbage in the sea");
        }
    }
}
