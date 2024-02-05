using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalMove : MonoBehaviour
{

    [SerializeField]
    private float minSpeed;

    [SerializeField]
    private float maxSpeed;

    float speed;

    private Vector2 newPos;
    // Start is called before the first frame update
    void Start()
    {
        newPos = new Vector2(transform.position.x, -10); // Используем transform.position.x вместо gameObject.position.x
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
    }
    private void OnMouseDown()
    {
        CollectResource();
    }

    private void CollectResource()
    {
        // Логика сбора ресурса
        ShipLogic.Instance.NewMetal();
        // Дополнительные действия, например, уничтожение объекта ресурса
        Destroy(gameObject);
    }
}
