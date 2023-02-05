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
    [SerializeField]
    public GameObject FullPanel;
    [SerializeField]
    public GameObject PlayButton;
    [SerializeField]
    public GameObject Cred;
    [SerializeField]
    public GameObject GameTitle;

    public void UpdateLeaves(int leaves)
    {
        Leaves.text = "Leaves " + leaves.ToString();
    }

    public void StartGame()
    {
        Buttons.active = true;
        FullPanel.active = false;
        PlayButton.active = false;
        Cred.active = false;
        GameTitle.active = false;
    }

    public void GameOverText()
    {
        FullPanel.active = true;
        GameOver.active = true;
        PlayButton.active = true;

        Buttons.active = false;
    }
}
