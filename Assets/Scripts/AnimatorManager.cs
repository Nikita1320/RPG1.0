using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    private Animator animator;
    public Animator Animator { get { return animator; }}
    public AnimatorOverrideController overrideController;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = overrideController;
    }

    public void ChangeAnimation(string nameAnimationInBaseAnimator, AnimationClip newAnimationClip)
    {
        overrideController[nameAnimationInBaseAnimator] = newAnimationClip;
    }
}
