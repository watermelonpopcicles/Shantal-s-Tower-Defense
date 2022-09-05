using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackEnemy : MonoBehaviour
{
    public float rotSpeed = 90f;

    public Transform enemy;

    // Update is called once per frame
    void Update()
    {

        // At this point, we've either found the player,
        // or he/she doesn't exist right now.

        if (enemy == null)
            return; // Try again next frame!

        // HERE -- we know for sure we have a player. Turn to face it!

        Vector3 dir = enemy.position - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && enemy == null) {

            enemy = other.transform;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && enemy == null)
        {

            enemy = other.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) {
            enemy = null;
        }
    }
}
