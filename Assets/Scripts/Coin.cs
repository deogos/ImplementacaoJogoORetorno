using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationA;
    public float rotationB;

    void Update()
    {
        transform.Rotate(rotationA * Time.deltaTime, rotationB * Time.deltaTime, 0);
    }

}
