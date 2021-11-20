using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryMeter : MonoBehaviour
{
    /// <summary>
    /// O meter só vai de 0 a 1
    /// </summary>
    [Range(0f, 1f)]
    private float _meter;

    public float Meter
    {
        get
        {
            return _meter;
        }

        set
        {
            if (value > 0f)
                _meter = Mathf.Min(1, value);
            else
                _meter = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
