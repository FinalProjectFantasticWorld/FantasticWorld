using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [Tooltip("KeyCode that activate the skill")] [SerializeField] private KeyCode keyCodeSkill;
    [Tooltip("the name of the skill")] [SerializeField] private string skill;
    [Tooltip("Skills that contains the all skills")] [SerializeField] private Skills skills;

    private void Update()
    {
        if (Input.GetKeyDown(keyCodeSkill) && PlayerPrefs.GetString(skill).Equals("1"))
        {
            skills.selectSkill(skill); //select skill
            gameObject.SetActive(false); //used skill and disappear
        }
    }
  
}
