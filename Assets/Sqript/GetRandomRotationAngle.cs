using UnityEngine;

public static class GetRandom
{
    public static Quaternion GetRandomRotationAngle()
    {
        return Quaternion.Euler(0.0f, 0.0f, Random.Range(-180.0f, 180.0f));
    }

}