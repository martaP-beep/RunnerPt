using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public bool jumped;
    public bool doubleJumped;

    public float jumpForce;
    public float liftForce;

    public LayerMask ground;

    BoxCollider2D bc;

    Rigidbody2D rb;
    float timestamp;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded() && Time.time > timestamp) {

            jumped = false;
            doubleJumped = false;
            timestamp = Time.time + 1;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (jumped == false)
            {
                rb.velocity = (new Vector2(0, jumpForce));
                jumped = true;
            }
            else if (doubleJumped == false) 
            {
                rb.velocity = (new Vector2(0, jumpForce));
                doubleJumped = true;
            }
        }

        if (Input.GetMouseButton(0) && rb.velocity.y < 0)
        {
            rb.AddForce(new Vector2(0,liftForce * Time.deltaTime));
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") 
            && GameManager.instance.immortality.isActive == false ){
            PlayerDeath();
        }
        else if (collision.CompareTag("Coin"))
        {
            SoundManager.instance.PlayCoin();

            Destroy(collision.gameObject);
            GameManager.instance.CoinCollected();
        }
        else if (collision.CompareTag("Immortality"))
        {
            Destroy(collision.gameObject);
            GameManager.instance.ImmortalityCollected();
        }
        else if (collision.CompareTag("Magnet"))
        {
            Destroy(collision.gameObject);
            GameManager.instance.MagnetCollected();
        }
    }

    void PlayerDeath()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        GameManager.instance.GameOver();
    }


    bool IsGrounded()
    {
       RaycastHit2D hit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size,
            0, Vector2.down, 0.1f, ground);

        return hit.collider != null;
    }
}
