using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;

    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        OnMove();
        OnRun();
    }

    #region Movement

    void OnMove()
    {
        if(player.direction.sqrMagnitude > 0)
        {
            if(player.isRolling)
            {
               anim.SetInteger("transition", 3);
            }
            else
            {
                anim.SetInteger("transition", 1); 
            }
           
        }
        else
        {
            anim.SetInteger("transition", 0); 
        }

        if(player.direction.x > 0)
        {
            transform.eulerAngles = new  Vector2(0, 0);
        }
        if(player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    void OnRun()
    {
        if(player.isRunning)
        {
            if(player.isRolling)
            {
               anim.SetInteger("transition", 3);
            }
            else
            {
                anim.SetInteger("transition", 2); 
            }
        }
    }

    #endregion
}
