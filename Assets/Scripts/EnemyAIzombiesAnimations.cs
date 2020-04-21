using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Pathfinding.AIPath))]
public class EnemyAIzombiesAnimations : MonoBehaviour
{
    private SpriteRenderer sb;
    private Rigidbody2D rb,rbplayer;
    public Vector2 currentPosition, previousPosition,playerPosition;
    private float xRythm, yRythm;
    private GameObject player;

    public bool flip;


    public void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sb = gameObject.GetComponent<SpriteRenderer>();
        currentPosition = rb.position;
        previousPosition = rb.position;
        player = gameObject.GetComponent<Enemy>().playerInstance;
        rbplayer = player.GetComponent<Rigidbody2D>();

    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        xRythm = Mathf.Abs(playerPosition.x - currentPosition.x);
        yRythm = Mathf.Abs(playerPosition.y - currentPosition.y);

        currentPosition = transform.position;
        playerPosition = player.transform.position;
        Vector2 direction = previousPosition - currentPosition;
        if (direction.normalized.x < playerPosition.x && xRythm>yRythm)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (direction.normalized.x > playerPosition.x && xRythm > yRythm)
        {
            transform.rotation = Quaternion.Euler(0, 0, -   90);

        }
        if (direction.y > playerPosition.y && xRythm < yRythm)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            sb.flipY = false;

            //if (gameObject.GetComponentInChildren<SpriteRenderer>().flipY == true)
            //{
            //    gameObject.GetComponentInChildren<SpriteRenderer>().flipY = false;
            //}

        }
        if (direction.y < playerPosition.y && xRythm < yRythm)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
            sb.flipY = true;

            //gameObject.GetComponentInChildren<SpriteRenderer>().flipY = true;

        }
        previousPosition = transform.position;

    }



}
