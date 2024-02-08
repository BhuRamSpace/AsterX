using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
   // private Point point;
    // Start is called before the first frame update
    void Start()
    {
       // point = GameObject.Find("Point").GetComponent<Point>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (transform.position.y >= 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collisionB)
    {
        if (collisionB.gameObject.tag == "Meteoriti")
        {
            Destroy(gameObject);
         //   point.UpdateScore(50);
        }
    }


}
