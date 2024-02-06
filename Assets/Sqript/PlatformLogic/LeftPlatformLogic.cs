using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPlatformLogic : MonoBehaviour
{
    [SerializeField]
    private float health = 200f;
    public static LeftPlatformLogic Instance;
    float health2 = 0f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    [SerializeField]
    private float Damage = 30;
    public int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        health2 = health;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (health > 0)
            {
                health -= Damage;
            }
            if (health < 0)
            {
                ShipLogic.Instance.freely[3] = 0;
                health = health2;
                Destroy(gameObject);
            }

        }
    }
}
