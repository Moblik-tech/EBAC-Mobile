using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator animator;
    public List<AnimatorSetup> animatorSetup;

    public enum AnimationType
    {
        IDLE,
        RUN,
        DEATH
    }

    public void Play(AnimationType type)
    {
        //animatorSetup.ForEach(i => 
        //{
        //    if (i.type == type)
        //    {
        //        animator.SetTrigger(i.triggerName);
        //    }
        //});

        foreach (var animation in animatorSetup)
        {
            if (animation.type == type)
            {
                animator.SetTrigger(animation.triggerName);
                break;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Play(AnimationType.RUN);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Play(AnimationType.IDLE);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Play(AnimationType.DEATH);
        }
    }
}

[System.Serializable]
public class AnimatorSetup
{
    public AnimatorManager.AnimationType type;
    public string triggerName;
}