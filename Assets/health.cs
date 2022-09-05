using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public float hp = 3;
    private float currenthp;
    public float killAmount = 5;

    void death() {

    }

    public void takedamage(float hit) {
        currenthp = currenthp - hit;
        if (currenthp <= 0) {
            GameObject.Find("manager").GetComponent<wallet>().moneygained(killAmount);
            Destroy(gameObject);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currenthp = hp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "sprink")
        {
            takedamage(1);
        }
        if (collision.gameObject.tag == "frost")
        {
            takedamage(2);
        }
        if (collision.gameObject.tag == "fire shooty thingy")
        {
            takedamage(3);
        }
        Destroy(collision.gameObject);

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
