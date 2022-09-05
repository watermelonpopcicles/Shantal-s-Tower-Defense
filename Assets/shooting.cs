using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject projectile;
    public Transform barrel;
    public float frequency = 0.4f;
    private float ctime;

 
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        Transform enemy = GetComponent<trackEnemy>().enemy; 
      
        if (ctime >= frequency) {
            if (enemy != null)
            {

                GameObject clone = Instantiate(projectile, barrel.position, barrel.rotation);
                Destroy(clone, 3);
                ctime = 0;
            }
        }
        else
        {
            ctime += Time.deltaTime;
        }
    }
}
