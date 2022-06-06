using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialGame : MonoBehaviour
{
    [SerializeField] private TutorialModel[] arrayTutorialObjects;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform handPlayer;
    [SerializeField] private GameObject startTextInSceneCanvas;
    [SerializeField] private TextMeshProUGUI textScene;
    private RecycleBinManager recycleBinManager;
    private bool arrowRecycleBin = false;
    private GameObject arrowRecycleBinObject;
    private GameObject objectInHand;
    private int counter = 0;
    public static int distroyCounter = 0;
    void Start()
    {
        recycleBinManager = new RecycleBinManager();
        //transform.position = arrayTutorialChild[0].transform.position+Vector3.up*2;
        //transform.parent = arrayTutorialChild[0].transform;
        distroyCounter = arrayTutorialObjects[counter].getGameObjects().Length;
        for (int i = 0; i < arrayTutorialObjects[counter].getGameObjects().Length; i++)
        {
            GameObject newObject = Instantiate(prefab, arrayTutorialObjects[counter].getGameObjects()[i].transform.position+Vector3.up*2, prefab.transform.rotation);
            newObject.transform.parent = arrayTutorialObjects[counter].getGameObjects()[i].transform;
        }

        showTextTutorial();


    }


    // Update is called once per frame
    void Update()
    {
        if (counter + 1 < arrayTutorialObjects.Length)
        {
            if (distroyCounter <= 0)
            {
                Debug.Log("Destroyed: " + distroyCounter);
                distroyCounter = arrayTutorialObjects[++counter].getGameObjects().Length;
                showTextTutorial();

                for (int i = 0; i < arrayTutorialObjects[counter].getGameObjects().Length; i++)
                {
                    if (arrayTutorialObjects[counter].getGameObjects()[i] == null)
                        continue;
                    GameObject newObject = Instantiate(prefab, arrayTutorialObjects[counter].getGameObjects()[i].transform.position + Vector3.up * 2, prefab.transform.rotation);
                    newObject.transform.parent = arrayTutorialObjects[counter].getGameObjects()[i].transform;
                }
            }
        }
        if (handPlayer.childCount != 0 && !arrowRecycleBin)
        {
            Debug.Log("in");
            GameObject arrowRecycleBinObject1 = Instantiate(prefab, recycleBinManager.getOpenRecyclebinPosition() + Vector3.up * 5, prefab.transform.rotation);
            arrowRecycleBinObject1.transform.parent = recycleBinManager.getRecycleBinOpenObject();
            arrowRecycleBinObject = arrowRecycleBinObject1;
            objectInHand = handPlayer.GetChild(0).gameObject;
            arrowRecycleBin = true;
        }
        else if (handPlayer.childCount == 0 && arrowRecycleBin)
        {
            Debug.Log("out");
            Destroy(arrowRecycleBinObject.gameObject);
            distroyCounter++;
            arrowRecycleBin = false;
        }
        if (arrayTutorialObjects[counter].getIsCollision())
        {
            Debug.Log(Vector3.Distance(arrayTutorialObjects[counter].getGameObjects()[0].transform.position, player.transform.position));
            if (Vector3.Distance(arrayTutorialObjects[counter].getGameObjects()[0].transform.position, player.transform.position) <= 2)
            {
                Destroy(arrayTutorialObjects[counter].getGameObjects()[0].transform.GetChild(0).gameObject);
                distroyCounter--;
            }
        }

    }


    private void showTextTutorial()
    {
        textScene.text = arrayTutorialObjects[counter].getTextTutorial();
        startTextInSceneCanvas.SetActive(false);
        startTextInSceneCanvas.SetActive(true);
    }



}
