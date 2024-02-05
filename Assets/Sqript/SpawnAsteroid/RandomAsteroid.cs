using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomAsteroid : MonoBehaviour
{
    [SerializeField]
    private GameObject top; // Для объекта, который будем спавнить
    [SerializeField]
    private GameObject bottom; // Для объекта, который будем спавнить
    [SerializeField]
    private GameObject left; // Для объекта, который будем спавнить
    [SerializeField]
    private GameObject right; // Для объекта, который будем спавнить

    [SerializeField]
    private GameObject warning;

    private GameObject Warn;
    private GameObject[] warn = new GameObject[3];

    float RandX;
    float RandY;
    

    [SerializeField]
    private float xLTop = -10.69f;
    [SerializeField]
    private float xRTop = 10.72f;

    [SerializeField]
    private float xLBottom = -10.69f;
    [SerializeField]
    private float xRBottom = 10.72f;

    [SerializeField]
    private float yTRight = -10.69f;
    [SerializeField]
    private float yBRight = 10.72f;

    [SerializeField]
    private float yTLeft = -10.69f;
    [SerializeField]
    private float yBLeft = 10.72f;

    Vector2 whereToSpawn;

    [SerializeField]
    private float[] minBeforeSpawnWave = new float[8];
    [SerializeField]
    private float[] maxBeforeSpawnWave =  new float[8];

    float nextBeforeSpawnWave = 0f;

    



    [SerializeField]
    private float[] spawnWaveMin = new float[8];
    [SerializeField]
    private float[] spawnWaveMax = new float[8];

    private float nextSpawnWave = 0f;

    [SerializeField]
    private float[] warningSpawn = new float[8];
    float nextWarningSpawn;

    [SerializeField]
    private float[] spawnRate = new float[8];

    float nextSpawn = 0.0f;

    [SerializeField]
    private int[] quantity = new int[8];

    private int level = 0;

    [SerializeField]
    private int[] levelLogic = new int[8];

    private int waveCounter = 0;
    private List<int> side = new List<int>();
    [SerializeField]
    private int[] maxWave = new int[8];

    [SerializeField]
    private int[][] proz = {
        new int[] { 100, 101, 101 },
        new int[] { 90, 100, 101 },
        new int[] { 80, 100, 101 },
        new int[] { 60, 95, 100 },
        new int[] { 40, 80, 100 },
        new int[] { 30, 70, 100 },
        new int[] { 20, 60, 100 },
        new int[] { 10, 30, 100 }
    };


    void Start()
    {
        nextBeforeSpawnWave = Time.time + Random.Range(minBeforeSpawnWave[level], maxBeforeSpawnWave[level] + 1);
        nextSpawnWave = Random.Range(spawnWaveMin[level], spawnWaveMax[level] + 1);
        nextWarningSpawn = nextBeforeSpawnWave - warningSpawn[level];
        //ship = FindObjectOfType<ShipLogic>();
    }


    void Update()           
    {
        //Debug.Log(ship.allMetal >= levelLogic[level]);
        //Debug.Log(ship == null);
        Debug.Log("AllMetal: " + ShipLogic.Instance.allMetal);
        Debug.Log("Array contents: " + string.Join(", ", levelLogic));

        //Debug.Log(level);
        Debug.Log("Level Logic: "+levelLogic[level]);
        if (level < 7 && ShipLogic.Instance.allMetal >= levelLogic[level])
         {
                        level++;

        }
        if (Time.time < nextSpawnWave && Time.time > nextBeforeSpawnWave)
        {
            /*for (int i = 0; i < warn.Length; i++)
            {
                Destroy(warn[i]);
                warn[i] = null;
            }*/
            

            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnRate[level];
                foreach(int k in side)
                {
                    int randomQuantity = Random.Range(1, quantity[level] + 1);
                    int j = 0;
                    List<float> currentSpawnedXPositions = new List<float>();
                    if (k == 0)
                    {
                        
                        for (int i = 0; i < randomQuantity; i++)
                        {
                            RandX = Random.Range(xLTop, xRTop);

                            RandX = NewRandX(RandX, currentSpawnedXPositions, currentSpawnedXPositions.Count); //Проверяем, чтобы новая позиция была достаточно удалена от существующих

                            whereToSpawn = new Vector2(RandX, 9.5f);
                            currentSpawnedXPositions.Add(RandX);
                            j++;
                            GameObject Asteroid = Instantiate(top, whereToSpawn, Quaternion.identity);
                            Destroy(Asteroid, 3f);
                        }
                    }
                    else if(k == 1)
                    {
                        for (int i = 0; i < randomQuantity; i++)
                        {
                            RandX = Random.Range(xLBottom, xRBottom);

                            RandX = NewRandX(RandX, currentSpawnedXPositions, currentSpawnedXPositions.Count); //Проверяем, чтобы новая позиция была достаточно удалена от существующих

                            whereToSpawn = new Vector2(RandX, -9.11f);
                            currentSpawnedXPositions.Add(RandX);
                            j++;
                            GameObject Asteroid = Instantiate(bottom, whereToSpawn, Quaternion.identity);
                            Destroy(Asteroid, 3f);
                        }
                    }
                    else if(k == 2)
                    {
                        for (int i = 0; i < randomQuantity; i++)
                        {
                            RandY = Random.Range(yTRight, yBRight);

                            RandY = NewRandX(RandY, currentSpawnedXPositions, currentSpawnedXPositions.Count); //Проверяем, чтобы новая позиция была достаточно удалена от существующих

                            whereToSpawn = new Vector2(15.08f, RandY);
                            currentSpawnedXPositions.Add(RandY);
                            j++;
                            GameObject Asteroid = Instantiate(right, whereToSpawn, Quaternion.identity);
                            Destroy(Asteroid, 6f);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < randomQuantity; i++)
                        {
                            RandY = Random.Range(yTLeft, yBLeft);

                            RandY = NewRandX(RandY, currentSpawnedXPositions, currentSpawnedXPositions.Count); //Проверяем, чтобы новая позиция была достаточно удалена от существующих

                            whereToSpawn = new Vector2(-14.87f, RandY);
                            currentSpawnedXPositions.Add(RandY);
                            j++;
                            GameObject Asteroid = Instantiate(left, whereToSpawn, Quaternion.identity);
                            Destroy(Asteroid, 6f);
                        }
                    }
                    
                }

}
        }
        else if(Time.time < nextSpawnWave && Time.time > nextWarningSpawn && nextWarningSpawn > 0 )
        {
            waveCounter = Random.Range(1, 101);
            if(waveCounter <= proz[level][0])
            {
                waveCounter = 1;
            }
            else if(waveCounter <= proz[level][1])
            {
                waveCounter = 2;
            }
            else
            {
                waveCounter = 3;
            }
            //waveCounter = Random.Range(1, maxWave[level]+1);
            List<int> l = new List<int>() { 0, 1, 2, 3 };
            for (int i = 0;i < waveCounter; i++)
            {
                int c = Random.Range(0, l.Count);
                side.Add(l[c]);
                NewSide(c, side[i]);
                l.RemoveAt(c);
            }
            nextWarningSpawn = 0;
        }
        

        if (Time.time > nextSpawnWave)
        {
            nextSpawnWave = Time.time + Random.Range(spawnWaveMin[level], spawnWaveMax[level] + 1); ;
            nextBeforeSpawnWave = Time.time + Random.Range(minBeforeSpawnWave[level], maxBeforeSpawnWave[level] + 1);
            nextWarningSpawn = nextBeforeSpawnWave - warningSpawn[level];
            side.Clear();

        }
    }

    float NewRandX(float RandX, List<float> currentSpawnedXPositions, int attempts)
    {
        foreach (float xPos in currentSpawnedXPositions)
        {
            if (Mathf.Abs(xPos - RandX) < 3f)
            {
                RandX += (RandX <= xPos) ? 3f : -3f;
                if(attempts > 0)
                {
                    RandX = NewRandX(RandX , currentSpawnedXPositions, attempts - 1);
                }
                return currentSpawnedXPositions.Max() + 3f;
            }
        }
        return RandX;
    }

    void NewSide(int i, int count)
    {
        if (count == 0)
        {
            Warn = Instantiate(warning, new Vector2(0.03f, 3.54f), Quaternion.identity); //top
            Destroy(Warn, warningSpawn[level]);
        }
        if (count == 1)
        {
            Warn = Instantiate(warning, new Vector2(0.01f, -3.52f), Quaternion.identity); //bottom
            Destroy(Warn, warningSpawn[level]);
        }
        if (count == 2)
        {
            Warn = Instantiate(warning, new Vector2(8.07f, -0.06f), Quaternion.identity); //right
            Destroy(Warn, warningSpawn[level]);
        }
        if (count == 3)
        {
            Warn = Instantiate(warning, new Vector2(-7.21f, -0.04f), Quaternion.identity); //left
            Destroy(Warn, warningSpawn[level]);

        }
    }
}
