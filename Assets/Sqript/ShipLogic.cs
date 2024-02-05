using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipLogic : MonoBehaviour
{
       
    [SerializeField]
    public float health = 200f;

    public int metal = 3;
    public int allMetal = 3;

    public float HP;

    public static ShipLogic Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField]
    private float minDamage = 3;
    [SerializeField]
    private float maxDamage = 40;
    // Start is called before the first frame update
    void Start()
    {
        HP = health;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            metal += 3;
            allMetal = metal;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameObject.Find("Shield(Clone)") == null)
        {
            if (collision.CompareTag("Enemy"))
                {
                    if (HP > 0)
                    {
                    HP -= Random.Range(minDamage, maxDamage);
                    }
                    if (HP < 0)
                    {
                        Destroy(gameObject);
                    }

                }
        }
        
    }
}
