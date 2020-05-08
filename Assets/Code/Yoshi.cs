using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yoshi : MonoBehaviour
{

    private Rigidbody2D yoshi;
    // Start is called before the first frame update
    void Start()
    {
        yoshi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newScale = transform.localScale;
        if(Input.GetAxis("Horizontal") > 0.0f)
        {
            newScale.x = 4.0f;
        }else if(Input.GetAxis("Horizontal") < 0.0f)
        {
            newScale.x = -4.0f;
        }

        transform.localScale = newScale;
    }

    private void FixedUpdate()
    {
        if (yoshi)
        {
            yoshi.AddForce(new Vector2(Input.GetAxis("Horizontal") * 5, 0));
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Star"))
        {
            Destroy(collision.gameObject);
        }

    }

}
