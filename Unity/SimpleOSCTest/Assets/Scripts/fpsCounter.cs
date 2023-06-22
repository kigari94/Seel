using UnityEngine;
using System.Collections;

public class fpsCounter : MonoBehaviour
{
    private float count;

    private IEnumerator Start()
    {
        GUI.depth = 2;
        while (true)
        {
            count = 1f / Time.unscaledDeltaTime;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnGUI()
    {
        Rect location = new Rect(5, 5, 150, 50);
        string text = $"FPS: {Mathf.Round(count)}";
        Texture black = Texture2D.linearGrayTexture;
        GUI.DrawTexture(location, black, ScaleMode.StretchToFill);
        GUI.color = Color.white;
        GUI.skin.label.fontSize = 25;
        GUI.Label(location, text);
    }
}