using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class winningText : MonoBehaviour
{
    private TextMeshProUGUI mText;

    void Start()
    {
        mText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        int[] scores = BallMovement.getScores();
        mText.text = scores[0]  + "\n-\n" + scores[1];
    }
}
