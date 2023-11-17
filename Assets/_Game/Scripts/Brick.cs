using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private Material colorBrick;

    private void Start()
    {
        transform.GetComponent<MeshRenderer>().material = colorBrick;
    }
}
