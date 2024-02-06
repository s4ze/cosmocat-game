using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLogic : MonoBehaviour
{
    [SerializeField]
    private float health = 200f;
    public static PlatformLogic Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    [SerializeField]
    private float Damage=30;
    public int index = 0;
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
                health -= Damage;
            }
            if(health < 0)
            {
                ShipLogic.Instance.freely[index] = 0;
                Destroy(gameObject);
            }
            
        }
    }
}
