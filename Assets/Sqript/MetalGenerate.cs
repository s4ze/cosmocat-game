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

    //������� ���������� ������ �������
    float nextSpawn = 0.0f;

    //������������ ��������� �������� �� ����������
    [SerializeField]
    private int quantity = 1;
    // Start is called before the first frame update

    //��������� �������� ��� ������
    float RandX;
    float RandY;


    //��� ����������� ����� ������
    Vector2 whereToSpawn;

    //������� ������
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
                Destroy(Asteroid, 9f);
            }
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
