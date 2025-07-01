using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<character>()) //no es PlayerController, yo lo nombre diferente
        {
            collision.gameObject.AddComponent<dJunp>();
            Destroy(gameObject);
        }
    }
}
