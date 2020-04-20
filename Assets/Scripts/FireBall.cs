using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("enemies"))
        {

            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>());
        }
        else if (collision.gameObject.tag.Equals("arrow")) { 
        
        }
        else if (collision.gameObject.tag.Equals("player"))
        {
            Destroy(this.gameObject);

        }
        else {
            Destroy(this.gameObject);

        }

    }

}
