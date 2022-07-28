using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeObject : MonoBehaviour
{

    [Tooltip("the type of garbage (like: Plastic, Glass, Paper, Organic")] [SerializeField] string type;
    [Tooltip("the image of the garbage")] [SerializeField] Sprite imageObject;

    public string getType()
    {
        return type;
    }

    public Sprite getSprite()
    {
        return imageObject;
    }
}
