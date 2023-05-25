using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bricks : MonoBehaviour
{
    [SerializeField] private GameObject brickPrefab;
    [SerializeField] private float gapY = 0.5f;
    [SerializeField] private float gapX = 2f;
    [SerializeField] private float columns = 20;

    [SerializeField] private Color Row1;
    [SerializeField] private Color Row2;
    [SerializeField] private Color Row3;

    private Vector3 initPos = new Vector3(0, 0, 0);

    void Start()
    {
        initPos = transform.position;

        for (int i = 0; i < 3; i++)
        {
            Color currentColor = Row1;
            string currentRowTag = "BrickTopOne";
            if (i == 1)
            {
                currentColor = Row2;
                currentRowTag = "BrickTopTwo";
            }
            else if (i == 2)
            {
                currentColor = Row3;
                currentRowTag = "BrickTopThree";
            }

            for (int j = 0; j < columns; j++)
            {
                Vector3 pos = new Vector3(initPos.x + (j * gapX), initPos.y - (gapY * i), initPos.z);
                GameObject brick = Instantiate(brickPrefab, pos, Quaternion.identity) as GameObject;
                brick.GetComponent<SpriteRenderer>().color = currentColor;
                brick.tag = currentRowTag;
                brick.transform.parent = gameObject.transform;
            }
        }
    }
}
