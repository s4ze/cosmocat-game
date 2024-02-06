using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtomFieldShip : MonoBehaviour
{
    // Start is called before the first frame update
    public static ButtomFieldShip Instance;

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
            gameObject.SetActive(false);
        }

    }

    public void NewView()
    {
        gameObject.SetActive(true);
        nextDistroy = Time.time + recharge;

    }
}
