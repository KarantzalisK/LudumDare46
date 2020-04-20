using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    public int health;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0) Die(); 
    }

    private void FixedUpdate()
    {
        Debug.Log(gameObject.GetComponent<Rigidbody2D>().velocity.x.ToString());


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("arrow")) {
            Destroy(collision.gameObject);
            health--;
            StartCoroutine("EndCountdown");

        }
    }

    void Die() { 
        
        
    }

    IEnumerator EndCountdown()
    {
        Color cl = gameObject.GetComponent<SpriteRenderer>().color;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(100, 0, 100);

        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<SpriteRenderer>().color= cl;

    }

}
