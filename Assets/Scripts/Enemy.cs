﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Pathfinding.AIPath))]
public class Enemy : MonoBehaviour
{

    public bool isRanged = false;


    public GameObject playerInstance;
    public float chaseDistance = 1;
    public float fireDistance = 2.5f;

    public GameObject fireBallPrefab;

    public Vector3 attackOffset;
    public float fireBallSpeed = 2f;


    public int health = 3;
    public float reloadTime = 1.2f;

    bool reloading = false;

    // Start is called before the first frame update
    void Start()
    {
        playerInstance=GameObject.FindGameObjectWithTag("player");
        gameObject.GetComponent<Pathfinding.AIDestinationSetter>().target = playerInstance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0) Die();
        if (Mathf.Abs(transform.position.x - playerInstance.transform.position.x) <= chaseDistance )
        {
            gameObject.GetComponent<Pathfinding.AIPath>().maxSpeed = 1;
        }
        
    }


    void shootFireball() {

        

        Vector2 dir = playerInstance.transform.position - (transform.position + attackOffset);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        GameObject go = Instantiate(fireBallPrefab, transform.position + attackOffset,
                                    Quaternion.AngleAxis(angle, Vector3.forward),
                                    transform.parent) as GameObject;

        Physics2D.IgnoreCollision(go.GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>());
        go.GetComponent<Rigidbody2D>().AddForce(dir.normalized * fireBallSpeed, ForceMode2D.Impulse);


    }


    private void FixedUpdate()
    {
        if (Mathf.Abs(transform.position.x - playerInstance.transform.position.x) <= fireDistance && isRanged &&!reloading)
        {
            StartCoroutine("shootFireballCountdown");
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("arrow")) {
            Destroy(collision.gameObject);
            health--;
            StartCoroutine("DamageFlash");

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        


    }


    void Die() {
        Destroy(this.gameObject);
        
    }

    IEnumerator DamageFlash()
    {
        Color cl = gameObject.GetComponent<SpriteRenderer>().color;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(100, 0, 100);

        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<SpriteRenderer>().color= cl;

    }
    IEnumerator shootFireballCountdown()
    {
        shootFireball();
        reloading = true;
        yield return new WaitForSeconds(reloadTime);
        reloading = false;

    }
}
