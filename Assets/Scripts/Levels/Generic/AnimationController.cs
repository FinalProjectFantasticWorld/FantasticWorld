using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationController : MonoBehaviour
{
    [Header("Animation Fields")]
    [Tooltip("to activate animator")] [SerializeField] private bool activeAnimation;

    [Tooltip("type float of animator")] [SerializeField] private string typeFloat;
    [Tooltip("value float of animator")] [SerializeField] private float valueFloat;
    [Tooltip("activate (float) in start")] [SerializeField] private bool floatInStart;

    [Tooltip("type int of animator")] [SerializeField] private string typeInt;
    [Tooltip("value int of animator")] [SerializeField] private int valueInt;
    [Tooltip("activate (int) in start")] [SerializeField] private bool intInStart;


    [Tooltip("type bool of animator")] [SerializeField] private string typeBool;
    [Tooltip("value bool of animator")] [SerializeField] private bool valueBool;
    [Tooltip("activate (bool) in start")] [SerializeField] private bool boolInStart;


    [Tooltip("float in patroll animator")] [SerializeField] private bool floatInPatrollAnimator;

    [Tooltip("int in patroll animator")] [SerializeField] private bool intInPatrollAnimator;

    [Tooltip("bool in patroll animator")] [SerializeField] private bool boolInPatrollAnimator;

    [Tooltip("float in patroll animator stop")] [SerializeField] private bool floatInPatrollAnimatorStop;

    [Tooltip("int in patroll animator stop")] [SerializeField] private bool intInPatrollAnimatorStop;

    [Tooltip("bool in patroll animator stop")] [SerializeField] private bool boolInPatrollAnimatorStop;



    private Animator animator;



    protected void Start()
    {
        if (activeAnimation)
            animator = GetComponent<Animator>();
        if (floatInStart)
            animator.SetFloat(typeFloat, valueFloat);
        if(intInStart)
            animator.SetInteger(typeInt, valueInt);
        if(boolInStart)
            animator.SetBool(typeBool, valueBool);

       
        
    }




    protected void playAnimator()
    {
        if (floatInPatrollAnimator)
            animator.SetFloat(typeFloat, valueFloat);
        if (intInPatrollAnimator)
            animator.SetInteger(typeInt, valueInt);
        if (boolInPatrollAnimator)
            animator.SetBool(typeBool, valueBool);
    }

    protected void stopAnimator()
    {
        if (floatInPatrollAnimatorStop)
            animator.SetFloat(typeFloat, 0);
        if (intInPatrollAnimatorStop)
            animator.SetInteger(typeInt, 0);
        if (boolInPatrollAnimatorStop)
            animator.SetBool(typeBool, false);
    }


}
