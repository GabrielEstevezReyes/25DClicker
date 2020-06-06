using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCreation : MonoBehaviour
{
    public GameObject character;
    public float difficulty = 3.0f;
    public GameObject pref;
    public GameObject Der;
    public GameObject Izq;
    public float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= difficulty)
        {
            time = 0;
            GameObject t;
            if ((Random.value > 0.5f))
            {
                t = Instantiate(pref, Der.transform.position, Quaternion.identity);
                t.GetComponent<enemy>().setOrientation(true);
            }
            else
            {
                t = Instantiate(pref, Izq.transform.position, Quaternion.identity);
                t.GetComponent<enemy>().setOrientation(false);
            }
            
        }        
    }

    public void upDfifficulty()
    {
        if (difficulty >= 0.4f)
        {
            difficulty -= 0.2f;
        }
    }
}
