using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOverTime : MonoBehaviour
{
    private float elapsedTime = 0f;

    // Starting scale factor
    public float startScale = 0.1f;
    //Target scale factor
    public float targetScale = 1f;
    //Duration of the scaling process in seconds
    public float duration = 2f;


    void Update()
    {
        // Update elapsed time
        elapsedTime += Time.deltaTime;
        // claculate the fraction of the duration that has passed
        float t = Mathf.Clamp01(elapsedTime / duration);
        // Interpolate between the initial scale and the target scale
        float scale = Mathf.Lerp(startScale, targetScale, t);
        // Apply the interpolated scale to the GameObject
        transform.localScale = new Vector3(scale, scale, scale);

    }
}