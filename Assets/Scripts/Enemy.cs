using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //public float turnSpeed = .1f;
    //public float moveSpeed = 4f;


    //Rigidbody2D target;

    //Rigidbody2D rb;

    //public Vector2 attackOffset;

    //float rotAngle = 0f;



    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();

        //target = GameObject.FindGameObjectWithTag("player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //Vector2 dir = (target.position - (rb.position + attackOffset)).normalized;

        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        //rotAngle = Mathf.LerpAngle(rotAngle, angle, turnSpeed);

        //Vector2 newDir = Quaternion.AngleAxis(rotAngle + 90, Vector3.forward) * Vector3.right;

        //Vector2 force = newDir * Time.fixedDeltaTime * moveSpeed;

        //rb.AddForce(force);

    }




}
