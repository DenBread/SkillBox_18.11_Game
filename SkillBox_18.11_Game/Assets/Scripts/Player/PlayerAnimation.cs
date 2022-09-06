using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private static readonly int Idle = Animator.StringToHash("PlayerIdle");
    private static readonly int Walk = Animator.StringToHash("PlayerWalk");
    private static readonly int Jump = Animator.StringToHash("PlayerJump"); 
    private static readonly int Fall = Animator.StringToHash("PlayerFall"); 
    private static readonly int Shoot = Animator.StringToHash("PlayerShoot");

    public int State { private get; set; }
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        _anim.CrossFade(State, 0, 0);
    }

    public void StateMove(float speed)
    {
        State = speed == 0 ? Idle : Walk;
    }

    public void StateShoot(bool isShoot)
    {
        if (isShoot)
        {
            State = Shoot;
        }
        else
        {
            //State = Idle;
        }
    }

}
