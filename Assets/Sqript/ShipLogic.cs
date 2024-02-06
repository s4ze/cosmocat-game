using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipLogic : MonoBehaviour
{
       
    [SerializeField]
    public float health = 200f;

    [SerializeField]
    public int plusMetal = 3;

    public int metal = 3;
    public int allMetal = 3;

    public float HP;

    public static ShipLogic Instance;

    public int[] freely = { 0, 0, 0, 0};

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField]
    private float Damage = 3;
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
            metal += plusMetal;
            allMetal = metal;
        }
        
    }

    public void NewMetal()
    {
        metal += 3;
        allMetal += 3;
    }

    public void MinusMetal(int i)
    {
        metal -= i;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameObject.Find("Shield(Clone)") == null)
        {
            if (collision.CompareTag("Enemy"))
                {
                    if (HP > 0)
                    {
                    HP -= Damage;
                    }
                    if (HP < 0)
                    {
                        Destroy(gameObject);
                    }

                }
        }
        
    }
}
