using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeftRandomAsteroid : MonoBehaviour
{
    [SerializeField]
    private GameObject obj; // Для объекта, который будем спавнить

    [SerializeField]
    private GameObject warning; //Для предупреждения

    //Рандомные значения для спавна
    float RandY;

    //Границы спавна
    [SerializeField]
    private float yLeft = -10.69f;
    [SerializeField]
    private float yRight = 10.72f;

    //Для определения места спавна
    Vector2 whereToSpawn;

    //Спокойное время, когда метеоритов нет
    [SerializeField]
    private float minBeforeSpawnWave = 5f;
    [SerializeField]
    private float maxBeforeSpawnWave = 5f;

    //Счетчик безмятежного рвемени
    float nextBeforeSpawnWave = 0f;


    //Общая длина волны с мирным временем
    [SerializeField]
    private float spawnWaveMin = 10f;
    [SerializeField]
    private float spawnWaveMax = 20f;

    //Счетчик волны
    private float nextSpawnWave = 0f;

    //Для спавна предупреждения
    [SerializeField]
    private float warningSpawn = 2f;
    float nextWarningSpawn = 2f;

    //Частота спавна объектов
    [SerializeField]
    private float spawnRate = 2f;

    //Счетчик следующего спавна объекта
    float nextSpawn = 0.0f;

    //Максимальное возможное количест во метеоритов
    [SerializeField]
    private int quantity = 1;


    void Start()
    {
        //Задаем базовые значения счетчикам
        nextBeforeSpawnWave = Time.time + Random.Range(minBeforeSpawnWave, maxBeforeSpawnWave + 1);
        nextSpawnWave = Random.Range(spawnWaveMin, spawnWaveMax + 1);
        nextWarningSpawn = nextBeforeSpawnWave - warningSpawn;
    }

    void Update()
    {

        if (Time.time < nextSpawnWave && Time.time > nextBeforeSpawnWave) // Условие при котором начинается налет метеоритов
        {

            if (Time.time > nextSpawn) //Генерация метеоров
            {
                nextSpawn = Time.time + spawnRate;
                int randomQuantity = Random.Range(1, quantity + 1);

                List<float> currentSpawnedXPositions = new List<float>(); //для хранения значений заспавнишихся элементов
                int j = 0;
                for (int i = 0; i < randomQuantity; i++)
                {
                    RandY = Random.Range(yLeft, yRight);

                    RandY = NewRandX(RandY, currentSpawnedXPositions, currentSpawnedXPositions.Count); //Проверяем, чтобы новая позиция была достаточно удалена от существующих

                    whereToSpawn = new Vector2(-14.87f, RandY);
                    currentSpawnedXPositions.Add(RandY);
                    j++;
                    GameObject Asteroid = Instantiate(obj, whereToSpawn, Quaternion.identity);
                    Destroy(Asteroid, 6f);
                }
            }
        }
        else if (Time.time < nextSpawnWave && Time.time > nextWarningSpawn && nextWarningSpawn > 0) // для спавна предупреждения
        {
            GameObject Warn = Instantiate(warning, new Vector2(-7.21f, -0.04f), Quaternion.identity);
            nextWarningSpawn = 0;
            Destroy(Warn, warningSpawn);
        }


        if (Time.time > nextSpawnWave) //обновление счетчиков
        {
            nextSpawnWave = Time.time + Random.Range(spawnWaveMin, spawnWaveMax + 1); ;
            nextBeforeSpawnWave = Time.time + Random.Range(minBeforeSpawnWave, maxBeforeSpawnWave + 1);
            nextWarningSpawn = nextBeforeSpawnWave - warningSpawn;
        }
    }

    float NewRandX(float RandY, List<float> currentSpawnedXPositions, int attempts) //Проверяем, чтобы новая позиция была достаточно удалена от существующих
    {
        foreach (float xPos in currentSpawnedXPositions)
        {
            if (Mathf.Abs(xPos - RandY) < 3f)
            {
                RandY += (RandY <= xPos) ? 3f : -3f;
                if (attempts > 0)
                {
                    RandY = NewRandX(RandY, currentSpawnedXPositions, attempts - 1);
                }
                return currentSpawnedXPositions.Max() + 3f;
            }
        }
        return RandY;
    }
}
