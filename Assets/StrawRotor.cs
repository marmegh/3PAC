using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrawRotor : MonoBehaviour {

    void Update()
    {
        transform.Rotate(new Vector3(10, 0, 0) * Time.deltaTime);
    }
}
