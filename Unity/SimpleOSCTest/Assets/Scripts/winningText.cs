using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class winningText : MonoBehaviour
{
    public BallMovement ballMovement;
    private TextMeshProUGUI mText;

    void Start()
    {
        mText = gameObject.GetComponent<TextMeshProUGUI>();
        int[] scores = BallMovement.getScores();
        mText.text = scores[0]  + " - " + scores[1];
    }

    void Update()
    {
        int[] scores = BallMovement.getScores();
        mText.text = scores[0]  + " - " + scores[1];
    }
}
