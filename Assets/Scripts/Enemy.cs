using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Pathfinding.AIPath))]
public class Enemy : MonoBehaviour
{

    public bool isRanged = false;


    public GameObject playerInstance;
    public float chaseDistanceX = 1;
    public float chaseDistanceY = 1;


    public float rangeAttackDistance = 2.5f;
    public float meleeAttackDistance = 0.5f;

    public int doesDamage = 1;


    public GameObject fireBallPrefab;

    public Vector3 attackOffset;
    //public Vector2 playerEnemyDistance,setMeleeDistance;
    public float fireBallSpeed = 2f;
    //private float enemyPlayerDistanceX, enemyPlayerDistanceY;

    public int health = 3;
    public float reloadTime = 1.2f;

    bool reloading = false;


    private void Awake()
    {
        playerInstance = GameObject.FindGameObjectWithTag("player");
        gameObject.GetComponent<Pathfinding.AIDestinationSetter>().target = playerInstance.transform;

    }

    // Start is called before the first frame update
    void Start()
    {
        playerInstance=GameObject.FindGameObjectWithTag("player");
        gameObject.GetComponent<Pathfinding.AIDestinationSetter>().target = playerInstance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //playerEnemyDistance = (playerInstance.GetComponent<Rigidbody2D>().position - gameObject.GetComponent<Rigidbody2D>().position);
        //enemyPlayerDistanceX = Mathf.Abs(playerEnemyDistance.x);
        //enemyPlayerDistanceY = Mathf.Abs(playerEnemyDistance.y);
       
            if (health == 0) Die();
        if (Mathf.Abs(transform.position.x - playerInstance.transform.position.x) <= chaseDistanceX && Mathf.Abs(transform.position.y - playerInstance.transform.position.y) <= chaseDistanceY)
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
        if (isRanged)
        {
            if (Mathf.Abs(transform.position.x - playerInstance.transform.position.x) <= rangeAttackDistance && !reloading)
            {
                StartCoroutine("shootFireballCountdown");
            }
        }
        //else {
        //    if (Mathf.Abs(transform.position.x - playerInstance.transform.position.x) <= meleeAttackDistance && Mathf.Abs(transform.position.y - playerInstance.transform.position.y) <= meleeAttackDistance && !reloading)
        //    {
        //        StartCoroutine("meleeAttackCountdown");
        //    }
        //}

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("arrow")) {
            Destroy(collision.gameObject);
            health--;
            StartCoroutine("DamageFlash");

        }
        //if (collision.gameObject.tag.Equals("player"))
        //{
         //   StartCoroutine("meleeAttackCountdown");
       // }
    }

   // private void OnCollisionStay2D(Collider2D collision)
   // {
       // if (collision.gameObject.tag.Equals("player"))
       // {
        //    StartCoroutine("meleeAttackCountdown");
       // }


   // }


    void Die() {
        //Destroy(this.gameObject);
        gameObject.SetActive(false);
        
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

    IEnumerator meleeAttackCountdown()
    {
            reloading = true;
            playerInstance.GetComponent<PlayerMovement>().receiveDamage(doesDamage);
        yield return new WaitForSeconds(reloadTime);
        reloading = false;

    }


}
