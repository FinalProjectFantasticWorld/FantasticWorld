using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimWaterGun : MonoBehaviour
{
    [SerializeField] private Canvas aimGunWaterCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            aimGunWaterCanvas.gameObject.SetActive(true);
        }
    }
}
