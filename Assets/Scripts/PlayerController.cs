using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    [SerializeField] private float _jumpForce;
    [SerializeField] private ContactFilter2D _platform;
    private Rigidbody2D _rigidBody;

    public GameObject top;
    public GameObject bottom;
    public GameObject left;
    public GameObject right;

    public Animator animator; // ���������� ��� ����
    /*private bool _isOnPlatform => _rigidBody.IsTouching(_platform);
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    public void Jump()
    {
        if (_isOnPlatform)
        {
            _rigidBody.AddForce(UnityEngine.Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }*/
    public void Rotate()
    {

    }
    [SerializeField] GameObject playerObject;
    Coroutine rotationCoroutine;
    public float nextDistroy = 0f;
    private void Update()
    {
        animator.SetBool("IsFlying 0", false);
        /*if (gameObject.activeSelf)
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
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (rotationCoroutine == null)
            {
                rotationCoroutine = StartCoroutine(RotatePlayerSmoothly(90.0f, 1.0f));
            }
        }*/
        if (top.activeSelf || left.activeSelf || right.activeSelf || bottom.activeSelf)
        {
            if (rotationCoroutine == null)
            {
                rotationCoroutine = StartCoroutine(RotatePlayerSmoothly(-90.0f, 1.0f));
            }
            if (top.activeSelf && nextDistroy < Time.time)
            {
                top.SetActive(false);
            }
            else if (left.activeSelf && nextDistroy < Time.time)
            {
                left.SetActive(false);
            }
            else if (right.activeSelf && nextDistroy < Time.time)
            {
                right.SetActive(false);
            }
            else if (bottom.activeSelf && nextDistroy < Time.time)
            {
                bottom.SetActive(false);
            }
        }
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
}