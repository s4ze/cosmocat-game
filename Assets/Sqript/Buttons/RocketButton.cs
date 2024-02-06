using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketButton : MonoBehaviour
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
    public int coast;

    public GameObject boat;
    public float time = 0f;
    float nextSpawn = 0f;
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
        PlayerController.Instance.nextDistroy = Time.time + 0.8f;
    }
    void TopActive()
        {
        top.SetActive(true);
    }
    void BottomActive()
    {
        bottom.SetActive(true);
    }
    void LeftActive()
    {
        left.SetActive(true);
    }
    void RightActive()
    {
        right.SetActive(true);
    }
    private void OnMouseDown()
    {   if(nextSpawn < Time.time && ShipLogic.Instance.metal >= coast && !topPreview.activeSelf && !bottomPreview.activeSelf && !leftPreview.activeSelf && !rightPreview.activeSelf)
        {
            
                if (!top.activeSelf)
                {
                    topPreview.SetActive(true);
                }
                if (!bottom.activeSelf)
                {
                    bottomPreview.SetActive(true);
                }
                if (!left.activeSelf)
                {
                    leftPreview.SetActive(true);
                }
                if (!right.activeSelf)
                {
                    rightPreview.SetActive(true);
                }


            nextSpawn = Time.time + time;
            ShipLogic.Instance.metal -= coast;
        }
       
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
