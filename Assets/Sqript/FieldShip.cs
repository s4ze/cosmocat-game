using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldShip : MonoBehaviour
{
    [SerializeField]
    private GameObject field;

    [SerializeField]
    private float recharge = 5f;

    float nextField = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (/*Time.time > nextField && */Input.GetKeyDown(KeyCode.S))
        {
            GameObject Asteroid = Instantiate(field, new Vector2(0,0), Quaternion.identity);
           /* Destroy(Asteroid, 3f);
            nextField = Time.time + 3f + recharge;*/
        }
    }
}
