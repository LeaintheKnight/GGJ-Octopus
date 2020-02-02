using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    [SerializeField] Color color = new Color(0, 72, 132);
    [SerializeField] float density = 0.1f;

    // Start is called before the first frame update
    void Awake()
    {
        RenderSettings.fog = true;
        RenderSettings.fogMode = FogMode.Exponential;
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.fogColor = color;
        RenderSettings.fogDensity = density;
    }
}
