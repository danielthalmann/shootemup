using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEvent : MonoBehaviour
{
    public UnityEvent onFinish;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0)
        {
            onFinish?.Invoke();
            this.enabled = false;
        }
        
    }


}
