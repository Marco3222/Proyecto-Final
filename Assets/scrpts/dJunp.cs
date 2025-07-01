using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dJunp : MonoBehaviour
{
    bool use;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(use == false)
        {
            use = GetComponent<character>().isGrounded;
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.S))
            {
                rb.velocity = new Vector2( rb.velocity.x, 7);
                use = false;
            }
        }
    }
}
