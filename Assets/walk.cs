using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class walk : MonoBehaviour
{
    public Transform[] points;
    private Vector3 destination;
    public float speed=3;
    private int location; 
    
    // Start is called before the first frame update
    void Start()
    {
        destination = points[location].position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= .1f) {
            location++;
            Debug.Log(location);
            Debug.Log(points.Length);
            if (location >= points.Length)
            {
                SceneManager.LoadScene("lose screen");
                Destroy(gameObject);
            }
            try
            {

                destination = points[location].position;
            }
            catch {

            }
            }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        }

    }
}
