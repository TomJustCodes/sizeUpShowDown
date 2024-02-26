using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PulsatingLogo : MonoBehaviour
{
    public RawImage logoImage;
    public float minSize = 1f; // Minimum size
    public float maxSize = 1.15f; // Maximum size
    public float duration = 1.5f; // Duration of one cycle (in seconds)

    private float timer = 0f;
    private bool increasing = true;
    
    void Start()
    {
        // Find the RawImage with the name "Logo"
        logoImage = GameObject.Find("Logo").GetComponent<RawImage>();
    }

    void Update()
    {
        // Update the timer
        timer += Time.deltaTime;

        // Calculate the current size based on timer and duration
        float t = Mathf.PingPong(timer / duration, 1f);
        float currentSize = Mathf.Lerp(minSize, maxSize, t);

        // Apply the current size to the RawImage
        logoImage.transform.localScale = new Vector3(currentSize, currentSize, 1f);
    }

}
