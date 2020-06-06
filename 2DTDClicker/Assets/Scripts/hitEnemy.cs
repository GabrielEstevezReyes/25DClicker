using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitEnemy : MonoBehaviour
{
    public FollowMouse chara;
    public enemyCreation cc;

    public void OnTriggerEnter(Collider other)
    {
        chara.score++;
        chara.toGetPowerUp++;
        other.gameObject.GetComponent<BoxCollider>().enabled = false;
        other.gameObject.GetComponent<Animator>().SetTrigger("keypressed");
        other.gameObject.GetComponent<enemy>().alive = false;
        if(chara.score % 5 == 0)
        {
            cc.upDfifficulty();
        }
    }
}
