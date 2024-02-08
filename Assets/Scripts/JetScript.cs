using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetScript : MonoBehaviour
{
    public Transform transform;
    public float speed = 5f;
    public float speed2 = -5f;
    public float rotationSpeed = 5f;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Clamp();

    }

    void Movement()
    {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -25), rotationSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(speed2 * Time.deltaTime, 0, 0);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 25), rotationSpeed * Time.deltaTime);
            }

            if (transform.rotation.z != 90)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 10f * Time.deltaTime);
            }
    }

    void Clamp()
    {
            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(pos.x, -2f, 2f);
            transform.position = pos;
    }


     private void OnTriggerEnter2D(Collider2D collision)
     {
         if(collision.gameObject.tag == "Meteoriti")
         {
             Destroy(gameObject);
            GameObject expJet=Instantiate(explosion,transform.position,Quaternion.identity);
            Destroy(expJet,0.4f);
        }
     }
}
