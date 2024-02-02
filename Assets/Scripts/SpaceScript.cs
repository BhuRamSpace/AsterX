using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceScript : MonoBehaviour
{
    public Renderer mashRenderer;
    public float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mashRenderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);   
    }
}
