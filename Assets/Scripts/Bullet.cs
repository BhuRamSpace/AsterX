using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    private PointManager pointManager;

    // Start is called before the first frame update
    void Start()
    {
       pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
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
            pointManager.UpdateScore(50);
            Destroy(gameObject);
        }
    }


}
