using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private ContactFilter2D _platform;
    private Rigidbody2D _rigidBody;
    private bool _isOnPlatform => _rigidBody.IsTouching(_platform);
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
    }
    public void Rotate()
    {

    }
    [SerializeField] GameObject playerObject;
    Coroutine rotationCoroutine;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (rotationCoroutine == null)
            {
                rotationCoroutine = StartCoroutine(RotatePlayerSmoothly(90.0f, 2.5f));
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (rotationCoroutine == null)
            {
                rotationCoroutine = StartCoroutine(RotatePlayerSmoothly(-90.0f, 2.5f));
            }
        }
    }
    IEnumerator RotatePlayerSmoothly(float angle, float intensity)
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
}