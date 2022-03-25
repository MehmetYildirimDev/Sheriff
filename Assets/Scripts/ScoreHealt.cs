using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHealt : MonoBehaviour
{
    public static int Healt = 100;
    public Text HealtText;

    public static int Score = 0;
    public Text ScoreText;

    private void Update()
    {

        HealtText.text = Healt.ToString();
        ScoreText.text = Score.ToString();
    }
}
