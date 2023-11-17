using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        PoolBrick.instance.Oninit();
        BrickSpawn.instance.Oninit();
    }
}
