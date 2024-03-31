using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLight : MonoBehaviour
{
    float min = 4.5f;
    float max = 5f;
    float speed = 8f; 

    UnityEngine.Rendering.Universal.Light2D torch;

    // Start is called before the first frame update
    void Start()
    {
        torch = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Use the Sin function to create a value that produces smooth fluctuations under time variation
        float t = Mathf.Sin(Time.time * speed);

        // Maps this value to min and max
        float radius = Mathf.Lerp(min, max, (t + 1) / 2f);

        // Applying values to light outer radius
        torch.pointLightOuterRadius = radius;
    }
}
