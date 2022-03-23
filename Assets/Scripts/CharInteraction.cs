
using System.Collections.Generic;
using UnityEngine;

public class CharInteraction : MonoBehaviour
{
   
    public static Animator charAnim;
    public  AudioSource player_SFX;
    public  List<AudioClip> playerDamagedClip;
    public  List<AudioClip> playerHitClip;
    public enum CharachterState
    {
        Run, Attack, Idle, End
    }
    public static CharachterState CharState;

    void Start()
    {
        Debug.Log(Sword.Damage);
        charAnim = GetComponent<Animator>();
       
    }

    void Update()
    {
       
        if (Input.touchCount > 0 && Monster.PlayerHealth > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && CharState == CharachterState.Idle)
            {
                CharState = CharachterState.Attack;
                SetAnimation();

            }

            else if (CharState != CharachterState.Run)
            {
                CharState = CharachterState.Idle;
                SetAnimation();
            }
        }
    
          
    }


    public static void SetAnimation()
    {

        switch (CharState)
        {
            case CharachterState.Attack:
                charAnim.SetBool("Attack", true);
                charAnim.SetBool("Idle", false);
                charAnim.SetBool("Run", false);
                break;
            case CharachterState.Run:
                charAnim.SetBool("Run", true);
                charAnim.SetBool("Attack", false);
                charAnim.SetBool("Idle", false);
                break;
            case CharachterState.Idle:
                charAnim.SetBool("Idle", true);
                charAnim.SetBool("Run", false);
                charAnim.SetBool("Attack", false);
                break;
            case CharachterState.End:
                charAnim.SetBool("Idle", false);
                charAnim.SetBool("Run", false);
                charAnim.SetBool("Attack", false);
                charAnim.SetBool("Congratz", true);
                break;

        }
    }
}