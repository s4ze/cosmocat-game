using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MetalVIew : MonoBehaviour
{
    public TextMeshProUGUI myTextMeshPro;
    public ShipLogic metal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myTextMeshPro.text = metal.allMetal.ToString();
    }
}

