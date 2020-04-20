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

        currentPosition = rb.position;
        Vector2 direction = previousPosition - currentPosition;
        if (direction.x < 0){
            sb.sprite = LEFT;
            if (flip){
                sb.flipX = false;
                directionDetect();
            }
        }if (direction.x > 0){
            sb.sprite = RIGHT;
            if (flip==false)
            {
                sb.flipX = true;
                directionDetect();

            }
        }
        if (direction.y < 0){
            sb.sprite = DOWN;
           if (gameObject.GetComponentInChildren<SpriteRenderer>().flipY == true)
            {
                gameObject.GetComponentInChildren<SpriteRenderer>().flipY = false;
            }
            directionDetect();


        }
        if (direction.y > 0){
            sb.sprite = UP;
            gameObject.GetComponentInChildren<SpriteRenderer>().flipY = true;
            directionDetect();

        }

    }
    IEnumerator directionDetect() {

      
        yield return new WaitForSeconds(0.2f);
        previousPosition = rb.position;

    }

}
