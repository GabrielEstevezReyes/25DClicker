using UnityEngine;
using UnityEngine.UI;

public class FollowMouse : MonoBehaviour
{
    public Transform izq;
    public Transform der;
    public int score = 0;
    public int toGetPowerUp;
    public bool facing = false;
    public GameObject d;
    public GameObject i;
    public GameObject d1;
    public GameObject i1;
    public Text t;
    public GameObject p;
    public Animator ani;
    public MeshCollider mesh;
    public bool alive = true;
    public float time = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        p.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            d.SetActive(false);
            d1.SetActive(false);
            i.SetActive(false);
            i1.SetActive(false);
            Vector3 upAxis = new Vector3(0, 0, -1);
            Vector3 mouseScreenPosition = Input.mousePosition;
            if (mouseScreenPosition.x >= Screen.width / 2)
            {
                transform.forward = new Vector3(1, 0, 0);
                facing = true;
            }
            else
            {
                transform.forward = new Vector3(-1, 0, 0);
                facing = false;
            }
            if (Input.GetMouseButton(0))
            {
                if (!facing)
                {
                    d.SetActive(true);
                }
                else
                {
                    i.SetActive(true);
                }
                ani.SetTrigger("AT");
            }
            t.text = score.ToString();
            if (toGetPowerUp >= 10)
            {
                p.SetActive(true);
                if (Input.GetMouseButtonDown(1))
                {
                    if (!facing)
                    {
                        d1.SetActive(true);
                    }
                    else
                    {
                        i1.SetActive(true);
                    }
                }
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
        Debug.Log("DEATHH");
        mesh.enabled = false;
        ani.SetTrigger("keypressed");
        alive = false;
        Application.Quit();
    }
}
