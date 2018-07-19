using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private static PlayerController instance;
    public static PlayerController player { get { return instance; } }
    private float speed = 4.0f;
    private Rigidbody rb;
   
    private int horizontalDiff = 0;
    private const float accelerate = 1.0005f;

    public bool hitSmoke = false;
    private bool onMove = false;
    public static int health = 3;
    public float whereX, whereY, whereZ;

    private int Diff = 2;
    public int landNum = 1;

    public AudioSource audio;
    /*
     LEFT = 0
     MID  = 1
     RIGHT = 2
         */

    Quaternion rotate = Quaternion.Euler(0, 0, 0);
	// Use this for initialization
	void Start () {
        instance = this;
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        rb.velocity = new Vector2(horizontalDiff, speed);
        rb.rotation = rotate;
        if (AccelerometerManager.Instance.isRotateTo(RotateDirection.LEFT) && onMove == false && landNum != 0)
        {
            horizontalDiff = -Diff;
            onMove = true;
            StartCoroutine(stopSlide());
            landNum -= 1;
        }

        if (AccelerometerManager.Instance.isRotateTo(RotateDirection.RIGHT) && onMove == false && landNum != 2)
        {
            horizontalDiff = Diff;
            onMove = true;
            StartCoroutine(stopSlide());
            landNum += 1;
        }
        speed = speed * accelerate;
    }
   
    void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.tag.Equals("Lethal"))
        {
            loseHP();
            other.gameObject.SetActive(false);
            Debug.Log("Get Hit");
            if (health == 0)
            {
                GM.Instance.GameOver();
                GameControl.instance.MainDie();
            }
        }

        if (other.gameObject.tag.Equals("Die"))
        {
            while (health > 0)
            {
                loseHP();
            }
            GM.Instance.GameOver();
            GameControl.instance.MainDie();
        }

        if (other.gameObject.tag.Equals("PowerUp"))
        {
            other.gameObject.SetActive(false);
          
            if(health <= 2)
            {
                HealthPanel.addHearth(health);
                 health += 1;
            }
            else
            {
                GM.Instance.point += 3;
            }

        }

        if (other.gameObject.tag.Equals("Coin"))
        {
            Debug.Log("Coin collected");
            GM.Instance.coinCollected += 1;
            audio.Play();
            other.gameObject.transform.parent.gameObject.SetActive(false);
        }

        if (other.gameObject.tag.Equals("Fight"))
        {
            hitSmoke = true;
            audio.Play();
            Debug.Log("Giai quyet van de");
            GM.Instance.point += 1;
            whereX = other.transform.position.x;
            whereY = other.transform.position.y - 0.5f;
            whereZ = other.transform.position.z;
            other.gameObject.SetActive(false);
        }
    }
    IEnumerator Wait3Sec()
    {
        yield return new WaitForSeconds(3);
    }
    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(0.5f);
        horizontalDiff = 0;
        onMove = false;
    }

    private void loseHP()
    {
        health -= 1;
        HealthPanel.deleteHearth(health);
    }

    public float getSpeed()
    {
        return speed;
    }
}
