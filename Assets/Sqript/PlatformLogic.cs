using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLogic : MonoBehaviour
{
    [SerializeField]
    private float health = 200f;

    [SerializeField]
    private float minDamage=3;
    [SerializeField]
    private float maxDamage = 40;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if(health > 0)
            {
                health -= Random.Range(minDamage, maxDamage);
            }
            if(health < 0)
            {
                Destroy(gameObject);
            }
            
        }
    }
}
