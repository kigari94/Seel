using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bricks : MonoBehaviour
{
    public enum RowPosition
    {
        TopRow,
        BottomRow
    }
    [SerializeField] private RowPosition rowPosition;
    [SerializeField] private GameObject brickPrefab;
    [SerializeField] private float gapY = 0.5f;
    [SerializeField] private float gapX = 2f;
    [SerializeField] private float columns = 20;
    [SerializeField] private Color Row1;
    [SerializeField] private Color Row2;
    [SerializeField] private Color Row3;

    private Vector3 initPos = new Vector3(0, 0, 0);
    private ParticleSystem ps;

    void Start()
    {
        initPos = transform.position;

        float brickWidth = brickPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        float xOffset = 0f;
        int extraBrick = 0;

        for (int i = 0; i < 3; i++)
        {
            Color currentColor = Row1;
            string currentRowTag = rowPosition == RowPosition.TopRow ? "BrickTopOne" : "BrickBottomOne";
            if (i == 1)
            {
                currentColor = Row2;
                currentRowTag = rowPosition == RowPosition.TopRow ? "BrickTopTwo" : "BrickBottomTwo";
            }
            else if (i == 2)
            {
                currentColor = Row3;
                currentRowTag = rowPosition == RowPosition.BottomRow ? "BrickTopThree" : "BrickBottomThree";
            }

            if (i % 2 == 0)
            {
                xOffset = 0f;
                extraBrick = 0;
            }
            else
            {
                xOffset = (brickWidth + gapX) / 2;
                extraBrick = 1;
            }

            for (int j = 0; j < columns + extraBrick; j++)
            {
                Vector3 pos = new Vector3(initPos.x + (j * (brickWidth + gapX)) - xOffset, initPos.y - (gapY * i), initPos.z);
                GameObject brick = Instantiate(brickPrefab, pos, Quaternion.identity) as GameObject;
                brick.GetComponent<SpriteRenderer>().color = currentColor;
                ps = brick.GetComponent<ParticleSystem>();
                var main = ps.main;
                main.startColor = currentColor;
                brick.tag = currentRowTag;
                brick.transform.parent = gameObject.transform;
            }
        }
    }
}
