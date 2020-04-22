using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
	public GameObject torch;
    public float speed = 2f, timer =0f;
    public GameObject positionSetObj;
	public float arrowForce = 3f;
    public GameObject deathPanel;
    public GameObject boss,victoryPanel;

	Vector3 arrowRotation;

	public Camera cam;

	Rigidbody2D rb;
	Vector2 movement;

	public GameObject arrowPrefab;
	bool carryFire=false;
	bool readyToCarryFire=false;

	bool reloading = false;
	public float reloadTime = 0.25f;

	public int healthPoints = 3;


	public void receiveDamage(int amount) {
		healthPoints -= amount;
		if (healthPoints <= 0){
			playerDie();
		}
	}

	public void playerDie() {
        gameObject.SetActive(false);
		//gameObject.GetComponent<SpriteRenderer>().enabled = false;
		//gameObject.GetComponent<BoxCollider2D>().enabled = false;
        deathPanel.SetActive(true);
        gameObject.GetComponent<PlayerMovement>().enabled=false;

       
		//Draw A Panel Here

	}

	public void Awake()
	{
		rb = GetComponent<Rigidbody2D>();

	}


	// Start is called before the first frame update
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   if (!boss.activeSelf) {
            victoryPanel.SetActive(true);
            
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        if (Input.GetKeyDown(KeyCode.Space) && !carryFire && !reloading)
		{
			StartCoroutine("shootCountdown");
		}

		if (readyToCarryFire && Input.GetKeyDown(KeyCode.Space)) {
			Debug.Log("Pressed");
			carryFire = !carryFire;
		}

		if (carryFire) {
            torch.GetComponent<Transform>().position = positionSetObj.GetComponent<Transform>().position;


        }



	}


	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);




		if (movement.y > 0.01f && movement.x == 0f)
		{
			arrowRotation = new Vector3(0f, 0f, 0f);
		}
		else if (movement.y > 0.01f && movement.x > 0.01f) {
			arrowRotation = new Vector3(0f, 0f, -45f);
		}
		else if (movement.y == 0f && movement.x > 0.01f)
		{
			arrowRotation = new Vector3(0f, 0f, -90f);
		}
		else if (movement.y < -0.01f && movement.x > 0.01f)
		{
			arrowRotation = new Vector3(0f, 0f, -135f);
		}
		else if (movement.y < -0.01f && movement.x == 0f)
		{
			arrowRotation = new Vector3(0f, 0f, -180f);
		}
		else if (movement.y < -0.01f && movement.x < -0.01f)
		{
			arrowRotation = new Vector3(0f, 0f, -225f);
		}
		else if (movement.y == 0f && movement.x < -0.01f)
		{
			arrowRotation = new Vector3(0f, 0f, -270f);
		}
		else if (movement.y > 0.01f && movement.x < -0.01f)
		{
			arrowRotation = new Vector3(0f, 0f, -325f);
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
		yield return new WaitForSeconds(reloadTime);
		reloading = false;

	}

}
