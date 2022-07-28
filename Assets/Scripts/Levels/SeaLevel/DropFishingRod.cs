using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFishingRod : MonoBehaviour
{
    [Tooltip("Circle Fishing Rod")] [SerializeField] GameObject sphere;
    [Tooltip("Player GameObject")] [SerializeField] GameObject player;
    [Tooltip("the start position circle fishing rod")] [SerializeField] GameObject startPositionRod;
    [Tooltip("catch object with fishing rod circle material")] [SerializeField] Material catchMaterial;

    private void Start()
    {
        
        sphere.transform.position = startPositionRod.transform.position;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "pickup")
        {
            Debug.Log("TRYCATCH");
            sphere.GetComponent<MeshRenderer>().material = catchMaterial;
        }
    }

    private void Update()
    {
        
            

        if(Input.GetKeyDown(KeyCode.I))
        {
            sphere.transform.position += player.transform.forward;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            sphere.transform.position -= player.transform.forward;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            sphere.transform.position += player.transform.right;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            sphere.transform.position -= player.transform.right;
        }









    }


}
