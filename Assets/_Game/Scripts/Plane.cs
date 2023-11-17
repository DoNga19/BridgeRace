using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField] private int width;
    public int Width { get => width; }

    [SerializeField] public int height;

    public int Height { get => height; }
}
