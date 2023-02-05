using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField]
    public Door door;
    [SerializeField]
    public GameObject[] pillboxes;
    [SerializeField]
    public GameObject[] towers;
    [SerializeField]
    public GameObject Spawner;
    private int leaves = 30;
    public float timer;
    public int towerCost = 4;
    public int pillboxCost = 3;
    public Canvas canvas;
    [SerializeField]
    public AudioClip ac;
    [SerializeField]
    public AudioClip acEnd;


    private void Awake()
    {
        Time.timeScale = 0;
    }
    private void Start()
    {
        canvas.GetComponent<UpdateCanvas>().UpdateLeaves(leaves);

        for (var i = 0; i < towers.Length; i++)
        {
                towers[i].gameObject.SetActive(false);                
        }
        for (var i = 0; i < pillboxes.Length; i++)
        {
                pillboxes[i].gameObject.SetActive(false);                
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        Spawner.SetActive(true);
        canvas.GetComponent<UpdateCanvas>().StartGame();
    }


    public void BuyTower()
    {
        if(leaves > towerCost)
        {
            AudioController.AudioInstance.PlayOneShot(ac);
            for (var i = 0; i < towers.Length; i++)
            {
                if (!towers[i].gameObject.active)
                {
                    towers[i].gameObject.SetActive(true);
                    leaves -= towerCost;
                    canvas.GetComponent<UpdateCanvas>().UpdateLeaves(leaves);
                    break;
                }

            }
        }
    }
    public void BuyPillbox()
    {
        if(leaves > pillboxCost)
        {
            AudioController.AudioInstance.PlayOneShot(ac);
            for (var i = 0; i < pillboxes.Length; i++)
            {
                if (!pillboxes[i].gameObject.active)
                {
                    pillboxes[i].gameObject.SetActive(true);
                    leaves -= pillboxCost;
                    canvas.GetComponent<UpdateCanvas>().UpdateLeaves(leaves);
                    break;
                }

            }
        }
    }

    public void UpgradeTower()
    {
        if(leaves > towerCost * 3)
        {
            AudioController.AudioInstance.PlayOneShot(ac);

            for (var i = 0; i < towers.Length; i++)
            {
                towers[i].GetComponent<Tower>().hp += 5;
            }
            leaves -= towerCost * 3;
            canvas.GetComponent<UpdateCanvas>().UpdateLeaves(leaves);
        }
    }
    public void UpgradePillbox()
    {
        if(leaves > pillboxCost * 5)
        {
            AudioController.AudioInstance.PlayOneShot(ac);
            for (var i = 0; i < pillboxes.Length; i++)
            {
                pillboxes[i].GetComponent<Pillbox>().hp += 3;  
            }
            leaves -= pillboxCost * 5;
            canvas.GetComponent<UpdateCanvas>().UpdateLeaves(leaves);
        }
    }

    public void KillEnemy()
    {
        Debug.Log("kill enemy");
        leaves++;
        canvas.GetComponent<UpdateCanvas>().UpdateLeaves(leaves);
    }

    public void EndGame()
    {
        AudioController.AudioInstance.PlayOneShot(acEnd);
        canvas.GetComponent<UpdateCanvas>().GameOverText();
        Time.timeScale = 0;
    }
}
