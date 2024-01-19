

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEvent : MonoBehaviour
{
    public UnityEvent onFinish;

    private Animator animator;
    private bool invoked = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!invoked)
        {
            if (animator?.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.999)
            {
                invoked = true;
                Debug.Log("Finish Anim");
                onFinish?.Invoke();
            } else
            {
                Debug.Log(animator?.GetCurrentAnimatorStateInfo(0).normalizedTime);
            }
        }
        
    }


}
