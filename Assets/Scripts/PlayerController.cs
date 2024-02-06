using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*public Transform topPreset;
    public Transform bottomPreset;
    public Transform rightPreset;
    public Transform leftPreset;*/
    public GameObject leftShield;
    public GameObject rightShield;
    public GameObject bottomShield;
    public GameObject topShield;
    [SerializeField] GameObject playerObject;
    Coroutine rotationCoroutine;
    public void Start()
    {
        shieldPrevewDeactivate();
    }
    private void OnMouseDown()
    {

    }
    public void Rotate()
    {

    }
    /*public void Update()
    {
        animator.SetBool("IsFlying 0", false);
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (rotationCoroutine == null)
            {
                rotationCoroutine = StartCoroutine(RotatePlayerMoreSmoothly(90.0f, 2.5f));
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (rotationCoroutine == null)
            {
                rotationCoroutine = StartCoroutine(RotatePlayerMoreSmoothly(-90.0f, 2.5f));
            }
        }
    }*/
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (rotationCoroutine == null)
            {
                rotationCoroutine = StartCoroutine(RotatePlayerSmoothly(90.0f, 1.0f));
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (rotationCoroutine == null)
            {
                rotationCoroutine = StartCoroutine(RotatePlayerSmoothly(-90.0f, 1.0f));
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)) shieldPreviewActivate();
    }
    IEnumerator RotatePlayerMoreSmoothly(float angle, float intensity)
    {
        var playerTransform = playerObject.transform;
        var targetRotation = playerTransform.rotation * Quaternion.Euler(0.0f, 0.0f, angle);

        while (true)
        {
            playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, targetRotation, intensity * Time.deltaTime);

            if (Quaternion.Angle(playerTransform.rotation, targetRotation) < 0.01f)
            {
                rotationCoroutine = null;
                playerTransform.rotation = targetRotation;
                yield break;
            }

            yield return null;
        }
    }
    IEnumerator RotatePlayerSmoothly(float angle, float duration)
    {
        var playerTransform = playerObject.transform;
        var startRotation = playerTransform.rotation;
        var targetRotation = playerTransform.rotation * Quaternion.Euler(0.0f, 0.0f, angle);

        float elapsedTime = 0.0f;
        while (elapsedTime < duration)
        {
            float t = Mathf.SmoothStep(0.0f, 1.0f, elapsedTime / duration);
            playerTransform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
            //�������� �� ����� ���� ��� ����������
            animator.SetBool("IsFlying 0", true);
        }

        playerTransform.rotation = targetRotation;
        rotationCoroutine = null; // Reset the coroutine
    }
    public void shieldPreviewActivate()
    {
        topShield.SetActive(true);
        bottomShield.SetActive(true);
        rightShield.SetActive(true);
        leftShield.SetActive(true);
    }
    public void shieldPrevewDeactivate()
    {
        topShield.SetActive(false);
        bottomShield.SetActive(false);
        rightShield.SetActive(false);
        leftShield.SetActive(false);
    }
    public void spawnInPlace()
    {

    }
    /*private void CreatePreviews(Transform spawnPoint, float angle)
    {
        Instantiate(prefab, spawnPoint.position, Quaternion.AngleAxis(angle, Vector3.forward));
    }*/
}