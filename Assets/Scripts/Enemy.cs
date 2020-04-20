using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Pathfinding.AIPath))]
public class Enemy : MonoBehaviour
{
    public GameObject playerInstance;
    public float chaseDistance = 5;
    public float fireDistance = 2.5f;


    public int health = 3;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0) Die(); 
        //if(Mathf.Abs(transform.position.x - playerInstance.transform.position.x)<=chaseDistance || Mathf.Abs(transform.position.y - playerInstance.transform.position.y) <= chaseDistance){
        //    gameObject.GetComponent<Pathfinding.AIPath>().canMove = true;
        //}
    }

    private void FixedUpdate()
    {


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("arrow")) {
            Destroy(collision.gameObject);
            health--;
            StartCoroutine("EndCountdown");

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        


    }


    void Die() {
        Destroy(this.gameObject);
        
    }

    IEnumerator EndCountdown()
    {
        Color cl = gameObject.GetComponent<SpriteRenderer>().color;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(100, 0, 100);

        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<SpriteRenderer>().color= cl;

    }

}
