using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawn : MonoBehaviour
{
    public static BrickSpawn instance;

    [SerializeField] private List<GameObject> listPlane;
    public List<GameObject> ListPlane { get => listPlane; }
    [SerializeField] private int width;
    [SerializeField] private int height;

    [SerializeField] private List<GameObject> listBrickOnPlane;
    public List<GameObject> ListBrickOnPlane { get => listBrickOnPlane; }

    [SerializeField] private List<Material> listTag;

    private void Awake()
    {
        instance = this;
    }

    public void Oninit()
    {
        for (int index = 0; index < listPlane.Count; index++)
        {
            int height = listPlane[index].transform.GetComponent<Plane>().Height / 2;
            int width = listPlane[index].transform.GetComponent<Plane>().Width / 2;

            for (int i = - height; i < height; i++)
            {
                for (int j = - width; j < width; j++)
                {
                    Vector3 posBrick = new Vector3(j * 2f + listPlane[index].transform.position.x + 0.8f, listPlane[index].transform.position.y + 1, i * 2f + listPlane[index].transform.position.z + 0.8f);
                    Spawn(posBrick, listPlane[index]);
                }
            }
        }
    }

    private Color RandomTag()
    {
        int indexTagInList = Random.Range(0, listTag.Count);
        return listTag[indexTagInList].color;
    }

    public void Spawn(Vector3 posSpawn, GameObject plane)
    {   
        Color randomTag = RandomTag();

        while (PoolBrick.instance.poolDictionary[randomTag].Count == 0)
        {
            randomTag = RandomTag();
        }

        GameObject brick = PoolBrick.instance.SpawnBrickFromPool(randomTag, posSpawn, Quaternion.identity);

        listBrickOnPlane.Add(brick);

        brick.transform.SetParent(plane.transform);
        
    }
}
