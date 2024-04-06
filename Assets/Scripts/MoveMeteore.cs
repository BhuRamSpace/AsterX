using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMeteore : MonoBehaviour
{
    public Transform transform;
    public float speed = 8.0f;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
            Destroy(gameObject);
            GameObject expJet = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(expJet, 0.4f);
    }
 
}