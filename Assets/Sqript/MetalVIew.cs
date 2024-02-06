using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MetalVIew : MonoBehaviour
{
    public TextMeshProUGUI myTextMeshPro;

    [SerializeField]
    private ShipLogic metal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   void Update()
    {
        if (metal != null && myTextMeshPro != null)
        {
            myTextMeshPro.text = metal.metal.ToString();
        }
    }
}

