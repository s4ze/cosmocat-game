using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MetalGenerate : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;

    [SerializeField]
    private float spawnRate = 2f;

    //Счетчик следующего спавна объекта
    float nextSpawn = 0.0f;

    //Максимальное возможное количест во метеоритов
    [SerializeField]
    private int quantity = 1;
    // Start is called before the first frame update

    //Рандомные значения для спавна
    float RandX;
    float RandY;


    //Для определения места спавна
    Vector2 whereToSpawn;

    //Границы спавна
    [SerializeField]
    private float xLeft = -10.69f;
    [SerializeField]
    private float xRight = 10.72f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn) //Генерация метеоров
        {
            nextSpawn = Time.time + spawnRate;
            int randomQuantity = Random.Range(1, quantity + 1);

            List<float> currentSpawnedXPositions = new List<float>(); //для хранения значений заспавнишихся элементов
            int j = 0;
            for (int i = 0; i < randomQuantity; i++)
            {
                RandX = Random.Range(xLeft, xRight);

                RandX = NewRandX(RandX, currentSpawnedXPositions, currentSpawnedXPositions.Count); //Проверяем, чтобы новая позиция была достаточно удалена от существующих

                whereToSpawn = new Vector2(RandX, 9.5f);
                currentSpawnedXPositions.Add(RandX);
                j++;
                GameObject Asteroid = Instantiate(obj, whereToSpawn, Quaternion.identity);
                Destroy(Asteroid, 9f);
            }
        }

    }
    float NewRandX(float RandX, List<float> currentSpawnedXPositions, int attempts) //Проверяем, чтобы новая позиция была достаточно удалена от существующих
    {
        foreach (float xPos in currentSpawnedXPositions)
        {
            if (Mathf.Abs(xPos - RandX) < 3f)
            {
                RandX += (RandX <= xPos) ? 3f : -3f;
                if (attempts > 0)
                {
                    RandX = NewRandX(RandX, currentSpawnedXPositions, attempts - 1);
                }
                return currentSpawnedXPositions.Max() + 3f;
            }
        }
        return RandX;
    }
}
