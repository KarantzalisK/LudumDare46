using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{ 
    public Sprite UP,DOWN,LEFT,RIGHT;
    private SpriteRenderer sb;
    private Rigidbody2D rb;
    public Vector2 currentPosition, previousPosition;
    public bool flip;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sb= gameObject.GetComponent<SpriteRenderer>();
        currentPosition = rb.position;
        previousPosition = rb.position;
    }

    // Update is called once per frame
    void Update()
    {

        
        currentPosition = transform.position;

        Vector2 direction = previousPosition - currentPosition;
        if (direction.normalized.x < 0){
            sb.sprite = LEFT;
            
                sb.flipX = false;
            
        }if (direction.normalized.x > 0){
            sb.sprite = RIGHT;
           
            sb.flipX = true;
            
        }
        if (direction.y < 0)
        {
            sb.sprite = UP;
            
            //if (gameObject.GetComponentInChildren<SpriteRenderer>().flipY == true)
            //{
            //    gameObject.GetComponentInChildren<SpriteRenderer>().flipY = false;
            //}

        }
        if (direction.y > 0)
        {
            sb.sprite = DOWN;
            //gameObject.GetComponentInChildren<SpriteRenderer>().flipY = true;

        }
        previousPosition = transform.position;

    }
   

}
