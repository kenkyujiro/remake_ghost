using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugBlend : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        float blendValue = animator.GetFloat("Blend");
        Debug.Log("Blend Parameter: " + blendValue);
    }
}
