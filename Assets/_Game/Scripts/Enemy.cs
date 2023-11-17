using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    [SerializeField] private GameObject finish;

    [SerializeField] private bool isMoveToBridge = false;
    [SerializeField] private bool isSearchBrick = false;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        IState();
    }

    private Vector3 SearchBrick()
    {
        if (planeStart.transform.childCount != 0)
        {
            Vector3 brickTarget = transform.position;
            for (int i = 0; i < planeStart.transform.childCount; i++)
            {
                if (planeStart.transform.GetChild(i).GetComponent<MeshRenderer>().material.color == skinRenderer.material.color)
                {
                    if (brickTarget == transform.position)
                    {
                        brickTarget = planeStart.transform.GetChild(i).position;
                        continue;
                    }

                    float distance = Vector3.Distance(transform.position, brickTarget);
                    
                    if (distance > Vector3.Distance(transform.position, planeStart.transform.GetChild(i).position))
                    {
                        brickTarget = planeStart.transform.GetChild(i).position;
                    }
                }
            }
            return brickTarget;
        }
        return transform.position;
    }

    private void MoveToBridge()
    {
        agent.destination = finish.transform.position;  
    }

    private void IState()
    {
        int numberBrick = Random.Range(5, 10);
        if (transform.GetChild(1).childCount < numberBrick && !isMoveToBridge)
        {
            isSearchBrick = true;
            agent.destination = SearchBrick();
        }
        else
        {
            isSearchBrick = false;
        }

        if (!isSearchBrick && transform.GetChild(1).childCount > 0)
        {
            isMoveToBridge = true;
            MoveToBridge();
        }
        else
        {
            isMoveToBridge = false;
        }
    }
}
