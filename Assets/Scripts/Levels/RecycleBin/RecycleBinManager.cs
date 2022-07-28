using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleBinManager
{
    // Start is called before the first frame update
    private static Vector3 openRecycleBinPosition; // position the open recyclebin
    private static Transform recycleBinOpenObject; // transform the open recyclebin
    public void setOpenRecyclebinPosition(Vector3 openRecycleBinPosition1)
    {
        openRecycleBinPosition = openRecycleBinPosition1;
    }

    public Vector3 getOpenRecyclebinPosition()
    {
        return openRecycleBinPosition;
    }

    public void setRecycleBinOpenObject(Transform recycleBin)
    {
        recycleBinOpenObject = recycleBin;
    }

    public Transform getRecycleBinOpenObject()
    {
        return recycleBinOpenObject;
    }


}
