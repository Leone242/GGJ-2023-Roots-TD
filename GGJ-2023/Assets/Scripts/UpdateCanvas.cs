using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCanvas : MonoBehaviour
{
    [SerializeField]
    public Text Leaves;
    [SerializeField]
    public GameObject GameOver;
    [SerializeField]
    public GameObject Buttons;

    public void UpdateLeaves(int leaves)
    {
        Leaves.text = "Leaves " + leaves.ToString();
    }

    public void GameOverText()
    {
        GameOver.active = true;

        Buttons.active = false;
    }
}
