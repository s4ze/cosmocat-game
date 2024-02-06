using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShieldButton : MonoBehaviour
{
    public GameObject top;
    public GameObject bottom;
    public GameObject left;
    public GameObject right;
    public GameObject topPreview;
    public GameObject bottomPreview;
    public GameObject leftPreview;
    public GameObject rightPreview;
    // Start is called before the first frame update
    public int coast = 100;
    public static ShieldButton Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public GameObject boat;
    public float time = 3f;
    float nextSpawn = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (boat.transform.rotation.eulerAngles.z == 0)
        {
            if (Input.GetKeyDown(KeyCode.W) && topPreview.activeSelf)
            {
                PrewDel();
                NewTime();
                TopActive();
            }
            else if (Input.GetKeyDown(KeyCode.D) && rightPreview.activeSelf)
            {
                RightActive();
                PrewDel();
                NewTime();
            }
            else if (Input.GetKeyDown(KeyCode.S) && bottomPreview.activeSelf)
            {
                BottomActive();
                PrewDel();
                NewTime();
            }
            else if (Input.GetKeyDown(KeyCode.A) && leftPreview.activeSelf)
            {
                LeftActive();
                PrewDel();
                NewTime();
            }
        }
        else if (boat.transform.rotation.eulerAngles.z == 270f)
        {
            if (Input.GetKeyDown(KeyCode.W) && leftPreview.activeSelf)
            {
                LeftActive();
                PrewDel();
                NewTime();
            }
            else if (Input.GetKeyDown(KeyCode.D) && topPreview.activeSelf)
            {
                TopActive();
                PrewDel();
                NewTime();

            }
            else if (Input.GetKeyDown(KeyCode.S) && rightPreview.activeSelf)
            {
                RightActive();
                PrewDel();
                NewTime();
            }
            else if (Input.GetKeyDown(KeyCode.A) && bottomPreview.activeSelf)
            {
                BottomActive();
                PrewDel();
                NewTime();
            }
        }
        else if (boat.transform.rotation.eulerAngles.z == 180f)
        {
            if (Input.GetKeyDown(KeyCode.W) && bottomPreview.activeSelf)
            {
                BottomActive();
                PrewDel();
                NewTime();
            }
            else if (Input.GetKeyDown(KeyCode.D) && leftPreview.activeSelf)
            {
                LeftActive();
                PrewDel();
                NewTime();
            }
            else if (Input.GetKeyDown(KeyCode.S) && topPreview.activeSelf)
            {
                TopActive();
                PrewDel();
                NewTime();
            }
            else if (Input.GetKeyDown(KeyCode.A) && rightPreview.activeSelf)
            {
                RightActive();
                PrewDel();
                NewTime();
            }
        }
        else if (boat.transform.rotation.eulerAngles.z == 90f)
        {
            if (Input.GetKeyDown(KeyCode.W) && rightPreview.activeSelf)
            {
                RightActive();
                PrewDel();
                NewTime();
            }
            else if (Input.GetKeyDown(KeyCode.D) && bottomPreview.activeSelf)
            {
                BottomActive();
                PrewDel();
                NewTime();
            }
            else if (Input.GetKeyDown(KeyCode.S) && leftPreview.activeSelf)
            {
                LeftActive();
                PrewDel();
                NewTime();

            }
            else if (Input.GetKeyDown(KeyCode.A) && topPreview.activeSelf)
            {
                TopActive();
                PrewDel();
                NewTime();
            }

        }


    }
    void PrewDel()
    {
        PreviewDelete();
    }
    void NewTime()
    {

    }
    void TopActive()
    {
        top.SetActive(true);
        TopPlatformLogic.Instance.index = 0;
        ShipLogic.Instance.freely[0] = 1;

    }
    void BottomActive()
    {
        bottom.SetActive(true);
        BottomPlatformLogic.Instance.index = 2;
        ShipLogic.Instance.freely[2] = 1;
    }
    void LeftActive()
    {
        left.SetActive(true);
        LeftPlatformLogic.Instance.index = 3;
        ShipLogic.Instance.freely[3] = 1;
    }
    void RightActive()
    {
        right.SetActive(true);
        RIghtPlatformLogic.Instance.index = 1;
        ShipLogic.Instance.freely[1] = 1;
    }
    private void OnMouseDown()
    {
        if (nextSpawn < Time.time && ShipLogic.Instance.metal >= coast && !EnergyButton.Instance.Proof() && !RocketButton.Instance.Proof())
        {
            AudioManager.instance.Play("ButtonClick");
            if (!top.activeSelf && ShipLogic.Instance.freely[0] == 0)
            {
                topPreview.SetActive(true);
            }
            if (!bottom.activeSelf && ShipLogic.Instance.freely[2] == 0)
            {
                bottomPreview.SetActive(true);
            }
            if (!left.activeSelf && ShipLogic.Instance.freely[3] == 0)
            {
                leftPreview.SetActive(true);
            }
            if (!right.activeSelf && ShipLogic.Instance.freely[1] == 0)
            {
                rightPreview.SetActive(true);
            }
            ShipLogic.Instance.metal -= coast;
        }

    }
    public bool Proof()
    {
        bool t = false;
        if (topPreview.activeSelf && ShipLogic.Instance.freely[0] == 0)
        {
            t = true;
        }
        if (bottomPreview.activeSelf && ShipLogic.Instance.freely[2] == 0)
        {
            t = true;
        }
        if (leftPreview.activeSelf && ShipLogic.Instance.freely[3] == 0)
        {
            t = (true);
        }
        if (rightPreview.activeSelf && ShipLogic.Instance.freely[1] == 0)
        {
            t = (true);
        }
        return t;
    }
    private void PreviewDelete()
    {
        if (topPreview.activeSelf)
        {
            topPreview.SetActive(false);
        }
        if (bottomPreview.activeSelf)
        {
            bottomPreview.SetActive(false);
        }
        if (leftPreview.activeSelf)
        {
            leftPreview.SetActive(false);
        }
        if (rightPreview.activeSelf)
        {
            rightPreview.SetActive(false);
        }
    }
}