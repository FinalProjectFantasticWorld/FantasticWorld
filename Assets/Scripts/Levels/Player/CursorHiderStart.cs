using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHiderStart : MonoBehaviour
{
    private CursorHider cursorHider;
    [Tooltip("visible or hide of the cursor")] [SerializeField] private bool hide;
    // Start is called before the first frame update
    void Start()
    {
        cursorHider = new CursorHider();
        if (hide)
        {
            cursorHider.hideCursor();
        }
        else
            cursorHider.showCursor();

    }

}
