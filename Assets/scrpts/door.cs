using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] gema;
    int conteo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
    if(other.tag == "Gem")
    {
        gema[conteo].color = Color.white;
        conteo++;
        Destroy(other.gameObject);
        if(conteo >= 3)
        {
            GetComponent<SpriteRenderer>().color = Color.black;
        }
    }
    }
}
