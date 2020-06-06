using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform ene;
    public Animator anim;
    public BoxCollider box;
    public float time = 0.0f;
    public bool alive = true;

    public void Start()
    {
        ene = Camera.main.GetComponent<enemyCreation>().character.transform;
    }

    public void setOrientation(bool o)
    {
        if (!o)
        {
            transform.forward = new Vector3(1, 0, 0);
        }
        else
        {
            transform.forward = new Vector3(-1, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            transform.position = Vector3.MoveTowards(transform.position, ene.position, 0.02f);
            float dist = Vector3.Distance(ene.transform.position, transform.position);
            
            if (dist < 2)
            {
                Debug.Log("Dist: " + dist);
                anim.SetTrigger("pu");
            }
        }
        else
        {
            time += Time.deltaTime;
            if (time >= 1.5f)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            box.enabled = false;
            anim.SetTrigger("keypressed");
            alive = false;
        }
    }
}
