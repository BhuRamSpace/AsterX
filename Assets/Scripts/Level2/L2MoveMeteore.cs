using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2MoveMeteore : MonoBehaviour
{
    public Transform myTransform;
    public float speed = 10.0f;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        myTransform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        if (myTransform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
            Destroy(gameObject);
            GameObject expJet = Instantiate(explosion, myTransform.position, Quaternion.identity);
            Destroy(expJet, 0.4f);
    }
 
}