using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoisyBoi : MonoBehaviour
{

    public static NoisyBoi Instance;
    public AudioSource shootyNoise;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void MakeNoise()
    {
        shootyNoise.Play();
    }
}