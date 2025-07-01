using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
[SerializeField] private float speed = 5f;
[SerializeField] private float jumpForce = 7f;
[SerializeField] string Horizontal;

[SerializeField] LayerMask groundLayer;
[SerializeField] GameObject iman;
SpriteRenderer spriteRenderer;
public bool isGrounded;
Rigidbody2D rb;
Animator anim;
// El lugar al que debe regresar el jugador    
Vector2 savePoint;
// La altura de caída; si el jugador alguna vez está por debajo de ella, lo devolveremos al punto de guardado.
[SerializeField] float RespawnHeight; 
[SerializeField] GameObject cp;



    // Start is called before the first frame update
    void Start()
    {
        savePoint = transform.position;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);

        if(moveHorizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        if (moveHorizontal != 0)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }

        Collider2D col = GetComponent<Collider2D>();
        isGrounded = Physics2D.OverlapCircle(transform.position - transform.up*((col.bounds.extents.y/transform.localScale.y-col.offset.y)*transform.localScale.y), 0.01f, groundLayer);

        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetFloat("y", rb.velocity.y);
        }
        if(isGrounded)
        {
            anim.SetFloat("y", 0);
        }
        if (transform.position.y<RespawnHeight) // Si la elevación actual del personaje es inferior a RepsawnHeight...
        {
        transform.position = savePoint; // ... cambiamos la posición del personaje a la almacenada en la variable del punto de reaparición.
        }
        if(Input.GetKey(KeyCode.Return))
        {
            anim.SetTrigger("Crounch");
        }
         
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Checkpoint") // Si la etiqueta del objeto que tocamos es 'checkpoint'...
            {
                savePoint = collision.transform.position; // ...el punto de reaparición cambia al centro del objeto tocado.
                cp.GetComponent<Animator>().SetBool("Activate", true);
                print("entro ala detección");
            }
        
            if(collision.tag == "iman")
            {
                iman.SetActive(true);
                Destroy(collision.gameObject);
            }

         }

    }
    private void OnCollisionStay2D(Collision2D other) 
    {
        if(other.transform.GetComponent<PlatformEffector2D>())
        {
            if(Input.GetKey(KeyCode.S))
            {
                other.transform.GetComponent<Collider2D>().isTrigger = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.GetComponent<PlatformEffector2D>())
        {
            other.isTrigger = false;
        }
    }
}
