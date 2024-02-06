using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopFieldShip : MonoBehaviour
{
    // Start is called before the first frame update
    public static TopFieldShip Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField]
    private float recharge = 5f;

    float nextField = 0f;

    float nextDistroy = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf && nextDistroy < Time.time)
        {
            ShipLogic.Instance.freely[0] = 0;
            Debug.Log("T2: " + ShipLogic.Instance.freely[0]);
            gameObject.SetActive(false);
        }

    }

    public void NewView()
    {
        nextDistroy = Time.time + recharge;

    }
}