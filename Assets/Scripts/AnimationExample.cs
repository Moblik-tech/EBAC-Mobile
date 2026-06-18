using UnityEngine;

public class AnimationExample : MonoBehaviour
{
    public Animation animation;
    public AnimationClip idle;
    public AnimationClip run;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayAnimation(run);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            PlayAnimation(idle);
        }
    }

    void PlayAnimation(AnimationClip c)
    {
        // método pra trocar animações sem uma transição, ou seja, de forma brusca
        //animation.clip = c;

        // método pra trocar animações com uma transição, que pode receber um parâmetros float pra ajustar o tempo de troca
        animation.CrossFade(c.name);
    }
}