using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TopRandomAsteroid : MonoBehaviour
{
    [SerializeField]
    private GameObject obj; // ��� �������, ������� ����� ��������

    [SerializeField]
    private GameObject warning; //��� ��������������

    //��������� �������� ��� ������
    float RandX;
    float RandY;

    //������� ������
    [SerializeField]
    private float xLeft = -10.69f;
    [SerializeField]
    private float xRight = 10.72f;

    //��� ����������� ����� ������
    Vector2 whereToSpawn;

    //��������� �����, ����� ���������� ���
    [SerializeField]
    private float minBeforeSpawnWave = 5f;
    [SerializeField]
    private float maxBeforeSpawnWave = 5f;

    //������� ������������ �������
    float nextBeforeSpawnWave = 0f;


    //����� ����� ����� � ������ ��������
    [SerializeField]
    private float spawnWaveMin = 10f;
    [SerializeField]
    private float spawnWaveMax = 20f;

    //������� �����
    private float nextSpawnWave = 0f;

    //��� ������ ��������������
    [SerializeField]
    private float warningSpawn = 2f;
    float nextWarningSpawn = 2f;

    //������� ������ ��������
    [SerializeField]
    private float spawnRate = 2f;

    //������� ���������� ������ �������
    float nextSpawn = 0.0f;

    //������������ ��������� �������� �� ����������
    [SerializeField]
    private int quantity = 1;


    void Start()
    {
        //������ ������� �������� ���������
        nextBeforeSpawnWave = Time.time + Random.Range(minBeforeSpawnWave, maxBeforeSpawnWave + 1);
        nextSpawnWave = Random.Range(spawnWaveMin, spawnWaveMax + 1);
        nextWarningSpawn = nextBeforeSpawnWave - warningSpawn;
    }

    void Update()
    {

        if (Time.time < nextSpawnWave && Time.time > nextBeforeSpawnWave) // ������� ��� ������� ���������� ����� ����������
        {

            if (Time.time > nextSpawn) //��������� ��������
            {
                nextSpawn = Time.time + spawnRate;
                int randomQuantity = Random.Range(1, quantity + 1);

                List<float> currentSpawnedXPositions = new List<float>(); //��� �������� �������� ������������� ���������
                int j = 0;
                for (int i = 0; i < randomQuantity; i++)
                {
                    RandX = Random.Range(xLeft, xRight);

                    RandX = NewRandX(RandX, currentSpawnedXPositions, currentSpawnedXPositions.Count); //���������, ����� ����� ������� ���� ���������� ������� �� ������������

                    whereToSpawn = new Vector2(RandX, 9.5f);
                    currentSpawnedXPositions.Add(RandX);
                    j++;
                    GameObject Asteroid = Instantiate(obj, whereToSpawn, GetRandom.GetRandomRotationAngle());
                    Destroy(Asteroid, 3f);
                }
            }
        }
        else if (Time.time < nextSpawnWave && Time.time > nextWarningSpawn && nextWarningSpawn > 0) // ��� ������ ��������������
        {
            GameObject Warn = Instantiate(warning, new Vector2(0.03f, 3.54f), Quaternion.identity);
            nextWarningSpawn = 0;
            Destroy(Warn, warningSpawn);
        }


        if (Time.time > nextSpawnWave) //���������� ���������
        {
            nextSpawnWave = Time.time + Random.Range(spawnWaveMin, spawnWaveMax + 1); ;
            nextBeforeSpawnWave = Time.time + Random.Range(minBeforeSpawnWave, maxBeforeSpawnWave + 1);
            nextWarningSpawn = nextBeforeSpawnWave - warningSpawn;
        }
    }

    float NewRandX(float RandX, List<float> currentSpawnedXPositions, int attempts) //���������, ����� ����� ������� ���� ���������� ������� �� ������������
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
