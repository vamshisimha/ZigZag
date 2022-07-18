using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{

    public GameObject roadBlock;

    public Vector3 lastPosition;
    public float offset = 0.707f;

    public void SartBuilding()
    {
        InvokeRepeating("CreateNewRoadPart", 0, 0.5f);
    }

    public void CreateNewRoadPart()
    {
        Vector3 spawnPos = Vector3.zero;
        float chance = Random.Range(0, 100);
        if(chance < 50)
        {
            spawnPos = new Vector3(lastPosition.x + offset, lastPosition.y, lastPosition.z + offset);
        }
        else
        {
            spawnPos = new Vector3(lastPosition.x - offset, lastPosition.y, lastPosition.z + offset);
        }

        GameObject gameObject = Instantiate(roadBlock, spawnPos, Quaternion.Euler(0, 45, 0));
        lastPosition = gameObject.transform.position;

        float diamondChance = Random.Range(0, 100);
        if(diamondChance > 70)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

}
