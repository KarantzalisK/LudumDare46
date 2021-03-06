﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
	public GameObject torch;
    public float speed = 2f ;
    public GameObject positionSetObj;
	public float arrowForce = 3f ;
    public GameObject deathPanel;
    public GameObject boss,victoryPanel;
    public Image boltReloadin;
    public Image healthStateimgHolder;
    public Sprite fullHeart, brokenHeart, almostDeadHeart;
    public GameObject torchObject,torchWhenCahrMovesUp, torchWhenCahrMovesLeft, torchWhenCahrMovesDown,crossyOBJatBack,CrossyObjAtUp;
    private SpriteRenderer TorchOBJSB;
    private float enemyReloadTimer=0;
    

    Vector3 arrowRotation;

	public Camera cam;

	Rigidbody2D rb;
	Vector2 movement;

	public GameObject arrowPrefab;
	bool carryFire=false;
	bool readyToCarryFire=false;

	bool reloading = false;
	public float reloadTime = 0.25f;

    public int healthPoints = 3, fullHP = 0;


	public void receiveDamage(int amount) {
		healthPoints -= amount;
		if (healthPoints <= 0){
			playerDie();
            
		}
        StartCoroutine("DamageFlash");
            
	}

	public void playerDie() {
        gameObject.SetActive(false);
		//gameObject.GetComponent<SpriteRenderer>().enabled = false;
		//gameObject.GetComponent<BoxCollider2D>().enabled = false;
        deathPanel.SetActive(true);
        gameObject.GetComponent<PlayerMovement>().enabled=false;
        healthStateimgHolder.enabled = false;
        boltReloadin.enabled = false;
        



        //Draw A Panel Here

    }

    public void Awake()
	{
		rb = GetComponent<Rigidbody2D>();

	}


	// Start is called before the first frame update
	void Start()
    {
        fullHP = healthPoints;
        TorchOBJSB = torchObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyReloadTimer = enemyReloadTimer+Time.deltaTime;
        
        if (!boss.activeSelf) {
            victoryPanel.SetActive(true);
            gameObject.SetActive(false);
            
        }
        if (healthPoints <= fullHP)
        {
            healthStateimgHolder.GetComponent<Image>().sprite = fullHeart;
        
        }
         if (healthPoints < fullHP/ 2)
        {
            healthStateimgHolder.GetComponent<Image>().sprite = brokenHeart;
        }
        if(healthPoints< (fullHP/ 3))
        {
            healthStateimgHolder.GetComponent<Image>().sprite = almostDeadHeart;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        if (Input.GetKeyDown(KeyCode.Space) && !carryFire && !reloading)
		{
			StartCoroutine("shootCountdown");
		}

		if (readyToCarryFire && Input.GetKeyDown(KeyCode.E)) {
			Debug.Log("Pressed");
			carryFire = !carryFire;
		}

		if (carryFire) {
            torch.GetComponent<Transform>().position = positionSetObj.GetComponent<Transform>().position;


        }
        if (!carryFire)
        {
            TorchOBJSB.enabled = true;
            torchWhenCahrMovesUp.SetActive(false);
            torchWhenCahrMovesDown.SetActive(true);
            torchWhenCahrMovesLeft.SetActive(false);
        }



	}


	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);




		if (movement.y > 0.01f && movement.x == 0f)
        {
            crossyOBJatBack.SetActive(true);
            CrossyObjAtUp.SetActive(false);
            arrowRotation = new Vector3(0f, 0f, 0f);
            if (carryFire)
            {
                TorchOBJSB.enabled = false;
                torchWhenCahrMovesUp.SetActive(true);
                torchWhenCahrMovesDown.SetActive(false);
                torchWhenCahrMovesLeft.SetActive(false);
              


            }
        }
		else if (movement.y > 0.01f && movement.x > 0.01f) {
            crossyOBJatBack.SetActive(true);
            CrossyObjAtUp.SetActive(false);
            arrowRotation = new Vector3(0f, 0f, -45f);
            if (carryFire)
            {
                TorchOBJSB.enabled = false;
                torchWhenCahrMovesUp.SetActive(true);
                torchWhenCahrMovesDown.SetActive(false);
                torchWhenCahrMovesLeft.SetActive(false);
                



            }
        }
        else if (movement.y == 0f && movement.x > 0.01f)
		{
            crossyOBJatBack.SetActive(false);
            CrossyObjAtUp.SetActive(true);
            arrowRotation = new Vector3(0f, 0f, -90f);
            if (carryFire)
            {
                TorchOBJSB.enabled = true;
                torchWhenCahrMovesUp.SetActive(false);
                torchWhenCahrMovesDown.SetActive(true);
                torchWhenCahrMovesLeft.SetActive(false);
               




            }
        }
        else if (movement.y < -0.01f && movement.x > 0.01f)
        {
            crossyOBJatBack.SetActive(false);
            CrossyObjAtUp.SetActive(true);
            arrowRotation = new Vector3(0f, 0f, -135f);
            if (carryFire)
            {
                TorchOBJSB.enabled = true;
                torchWhenCahrMovesUp.SetActive(false);
                torchWhenCahrMovesDown.SetActive(true);
                torchWhenCahrMovesLeft.SetActive(false);
               


            }
        }
        else if (movement.y < -0.01f && movement.x == 0f)
        {
            crossyOBJatBack.SetActive(false);
            CrossyObjAtUp.SetActive(true);
            arrowRotation = new Vector3(0f, 0f, -180f);
            if (carryFire)
            {
                TorchOBJSB.enabled = true;
                torchWhenCahrMovesUp.SetActive(false);
                torchWhenCahrMovesDown.SetActive(true);
                torchWhenCahrMovesLeft.SetActive(false);
               



            }
        }
        else if (movement.y < -0.01f && movement.x < -0.01f)
		{
            crossyOBJatBack.SetActive(false);
            CrossyObjAtUp.SetActive(true);
            arrowRotation = new Vector3(0f, 0f, -225f);
            if (carryFire)
            {
                TorchOBJSB.enabled = true;
                torchWhenCahrMovesUp.SetActive(false);
                torchWhenCahrMovesDown.SetActive(true);
                torchWhenCahrMovesLeft.SetActive(false);
                




            }
        }
        else if (movement.y == 0f && movement.x < -0.01f)
        {
            crossyOBJatBack.SetActive(false);
            CrossyObjAtUp.SetActive(true);
            arrowRotation = new Vector3(0f, 0f, -270f);
            if (carryFire)
            {
                TorchOBJSB.enabled = false;
                torchWhenCahrMovesUp.SetActive(false);
                torchWhenCahrMovesDown.SetActive(false);
                torchWhenCahrMovesLeft.SetActive(true);
            



            }
        }
        else if (movement.y > 0.01f && movement.x < -0.01f)
        {
            crossyOBJatBack.SetActive(true);
            CrossyObjAtUp.SetActive(false);
            arrowRotation = new Vector3(0f, 0f, -325f);
            if (carryFire)
            {
                TorchOBJSB.enabled = false;
                torchWhenCahrMovesUp.SetActive(true);
                torchWhenCahrMovesDown.SetActive(false);
                torchWhenCahrMovesLeft.SetActive(false);
             



            }
        }
       

    }

	void shoot() {

		rb.constraints = RigidbodyConstraints2D.FreezeAll;

		Quaternion rotation = Quaternion.Euler(arrowRotation);
		GameObject arrow = Instantiate(arrowPrefab, rb.transform.position, rotation);
		
		Physics2D.IgnoreCollision(arrow.GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>());

		Rigidbody2D arrowRB = arrow.GetComponent<Rigidbody2D>();
		arrowRB.AddForce(arrowRB.transform.up * arrowForce, ForceMode2D.Impulse);

		rb.constraints = RigidbodyConstraints2D.FreezeRotation;


	}


	private void OnTriggerEnter2D(Collider2D collider)
	{

		if (collider.tag.Equals("torch")) {
			Debug.Log("Ready To Carry Torch");
			readyToCarryFire = true;
		}
       


    }
    private void OnTriggerStay2D(Collider2D collider)
	{
        if (collider.gameObject.tag.Equals("fireball"))
        {
            collider.GetComponent<Enemy>().StartCoroutine("meleeAttackCountdown");
        }
        if (collider.gameObject.tag.Equals("enemies") && enemyReloadTimer>=1.2)
        {
            enemyReloadTimer = 0;
            collider.GetComponent<Enemy>().StartCoroutine("meleeAttackCountdown");
        }


    }


	private void OnTriggerExit2D(Collider2D collider)
	{

		if (collider.tag.Equals("torch"))
		{
			Debug.Log("Torch Not Reachable anymore");
			readyToCarryFire = false;
            
		}

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag.Equals("arrow"))
		{

			Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>());
		}
	}


	void pickup()
	{
		
	}

	void checkDrop()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			dropObject();
		}
	}

	void dropObject()
	{
		//carrying = false;
		////carriedObject.gameObject.rigidbody.isKinematic = false;
		//carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
		//carriedObject = null;
	}


	IEnumerator shootCountdown()
	{
		shoot();
        reloading = true;
        boltReloadin.enabled = false;
		yield return new WaitForSeconds(reloadTime);
		reloading = false;
        boltReloadin.enabled = true;



    }
    IEnumerator DamageFlash()
    {
        Color cl = gameObject.GetComponent<SpriteRenderer>().color;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;

        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponent<SpriteRenderer>().color = cl;

    }

}
