using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuScript : MonoBehaviour
{
    public TextMeshProUGUI hiSliceCore;

    // Start is called before the first frame update
    void Start()
    {
        hiSliceCore.text = "HiSliceCore: "+PlayerPrefs.GetInt("HiScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
