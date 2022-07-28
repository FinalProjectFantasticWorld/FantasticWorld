using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayFunctionChat : MonoBehaviour
{

    public virtual void playFunction()
    {
        Debug.Log("you didn't override playFunction");
    }

    public virtual bool getIsPlayFunction()
    {
        Debug.Log("you didn't override playFunction");
        return false;
    }

}
