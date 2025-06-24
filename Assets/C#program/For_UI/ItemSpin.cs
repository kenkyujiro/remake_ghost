using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpin : MonoBehaviour
{
    float rotateAngleY = 360;
    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 0)
        {
            this.transform.Rotate(0, rotateAngleY / 150, 0);
        }
    }
}
