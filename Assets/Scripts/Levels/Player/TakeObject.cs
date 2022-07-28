using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TakeObject : MonoBehaviour
{
    [Tooltip("The hand of the player")] [SerializeField] private Transform hand;
    [Tooltip("Array of the RecycleBin")] [SerializeField] private RecycleBin[] recycleBins;
    [Tooltip("GameObject that contain all the objects of the game")] [SerializeField] private Transform allObjects;
    [Tooltip("The text gui of the coins")] [SerializeField] private TextMeshProUGUI textPoints;
    [Tooltip("The image gui on the hand")] [SerializeField] Image imageCanvas;
    [Tooltip("The text gui empty hand")] [SerializeField] TextMeshProUGUI textEmptyCanvas;
    [Tooltip("AudioManager the sound of the game")] [SerializeField] private AudioManager audioManager;
    [Tooltip("The text gui signifies that the player put the object into a wrong recycle bin")] [SerializeField] private TextMeshProUGUI textWrongBin;
    private Sprite lastImageCanvas; // save the last image hand
    private RecycleBinManager recycleBinManager; // RecycleBinManager 
    private Vector3 lastPosition; // last position of the object.
    private int coins = 0; // score of the player
    private GameObject onHand;

    


    private void Start()
    {
        recycleBinManager = new RecycleBinManager();
        coins = PlayerPrefs.GetInt("coins");
        Debug.Log("score saved: " + coins);
        textPoints.text = "Coins: " + (coins); // add point to the GUI
        Debug.Log("textPoints saved: " + textPoints.text);
        lastImageCanvas = imageCanvas.sprite;
    }
    private void OnCollisionStay(Collision collision)
    {


        if (collision.gameObject.tag == "pickup" && hand.childCount == 0)
        {

            Debug.Log("Collision");
            lastPosition = collision.transform.position;
            collision.transform.parent = hand;
            //collision.transform.position = hand.position;

            collision.gameObject.SetActive(false);
            onHand = collision.gameObject;
            imageCanvas.sprite = collision.gameObject.GetComponent<TypeObject>().getSprite();
            textEmptyCanvas.gameObject.SetActive(false);
            //Debug.Log("ZZZ");

            for (int i = 0; i < recycleBins.Length; i++)
            {
                if (collision.gameObject.GetComponent<TypeObject>() != null)
                {
                    if (recycleBins[i].getType().Equals(collision.gameObject.GetComponent<TypeObject>().getType()))
                    {
                        recycleBins[i].setOpen(true);
                        recycleBinManager.setOpenRecyclebinPosition(recycleBins[i].transform.position);
                        recycleBinManager.setRecycleBinOpenObject(recycleBins[i].transform);
                        Debug.Log(recycleBinManager.getOpenRecyclebinPosition());
                    }
                }
                else
                {
                    Debug.Log("need to put TypeObject");
                }


            }

        }


    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "recyclebin" && hand.childCount != 0)
        {
            textEmptyCanvas.gameObject.SetActive(true);
            imageCanvas.sprite = lastImageCanvas;
            if (onHand != null)
                onHand.SetActive(true);
            if (collision.gameObject.GetComponent<RecycleBin>().getOpen())
            {
                Destroy(hand.GetChild(0).gameObject);
                addPoint();
                audioManager.successBin();
                collision.gameObject.GetComponent<RecycleBin>().setOpen(false);
            }
            else
            {
                audioManager.failedBin();
                GameObject g = hand.GetChild(0).gameObject;
                hand.GetChild(0).transform.parent = null;
                g.transform.position = lastPosition;
                g.transform.parent = allObjects;
                for (int i = 0; i < recycleBins.Length; i++)
                {
                    recycleBins[i].setOpen(false);
                }

                StartCoroutine(failBin());
            }

            //recycleBinManager.setOpenRecyclebin(null);




        }
    }


    private IEnumerator failBin()
    {
        textWrongBin.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        textWrongBin.gameObject.SetActive(false);
    }

    private void addPoint()
    {
        //AddPoint
        textPoints.text = "Coins: " + (++coins); // add point to the GUI
    }


    // Start is called before the first frame update

}