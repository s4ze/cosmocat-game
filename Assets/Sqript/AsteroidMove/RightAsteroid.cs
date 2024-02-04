using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightAsteroid : MonoBehaviour
{
    [SerializeField]
    private float minSpeed;

    [SerializeField]
    private float maxSpeed;

    float speed;

    private Vector2 newPos; // Используемая переменная для новой позиции

    // Start is called before the first frame update
    void Start()
    {
        newPos = new Vector2(-16, transform.position.y); // Используем transform.position.x вместо gameObject.position.x
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // Изменяем позицию объекта на каждом кадре в сторону новой позиции
        transform.position = Vector2.MoveTowards(transform.position, newPos, speed * Time.deltaTime);

        // Проверяем, достигли ли мы новой позиции с определенным радиусом
        /* if (Vector2.Distance(transform.position, newPos) < 0.2f)
         {
             Destroy(gameObject);
         }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
