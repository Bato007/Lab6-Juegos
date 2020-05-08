using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yoshi : MonoBehaviour
{

    private Rigidbody2D yoshi;
    private bool canKilled = true;

    public float jumpForce = 5f;
    // Start is called before the first frame update
    void Start()
    {
        yoshi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (yoshi && Input.GetButtonDown("Jump"))
        {
            Jump();
        }

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
            yoshi.AddForce(new Vector2(Input.GetAxis("Horizontal") * 8, 0));
        }    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && canKilled)
            Destroy(gameObject);
        else if(collision.gameObject.CompareTag("Enemy") && !canKilled)
            Destroy(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {
            Destroy(collision.gameObject);
            canKilled = false;
        }                      
    }

    private void Jump()
    {
        if (Mathf.Abs(yoshi.velocity.y) < 0.05f)
            yoshi.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

}
