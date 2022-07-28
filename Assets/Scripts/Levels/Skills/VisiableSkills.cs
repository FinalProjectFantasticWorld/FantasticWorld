using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisiableSkills : MonoBehaviour
{
    [Tooltip("array's name of the skills")] [SerializeField] private string[] skills;
    [Tooltip("array's objects that represents the skills")] [SerializeField] private GameObject[] skillsObjects;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < skills.Length; i++)
        {
            if (PlayerPrefs.GetString(skills[i]).Equals("1"))
            {
                skillsObjects[i].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
