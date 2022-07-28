using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OnHand : MonoBehaviour
{

    [Tooltip("GUI image on hand player")] [SerializeField] private Image onHand;
    [Tooltip("GUI empty text on hand player")] [SerializeField] private TextMeshProUGUI emptyTextHand;
    private Sprite oldSprite;
    private void Start()
    {
        oldSprite = onHand.sprite;
    }
    // Start is called before the first frame update

    public void setHand(Sprite sprite)
    {
        if (onHand != null && emptyTextHand != null)
        {
            onHand.sprite = sprite;
            emptyTextHand.gameObject.SetActive(false);
        }
    }

    public void setToDefault()
    {
        if(onHand != null && emptyTextHand != null)
        {
            onHand.sprite = oldSprite;
            emptyTextHand.gameObject.SetActive(true);
        }
          
    }
    
}
