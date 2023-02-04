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
    private int leaves = 30;
    public float timer;
    public int towerCost = 4;
    public int pillboxCost = 3;
    public Canvas canvas;



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


    public void BuyTower()
    {
        if(leaves > towerCost)
        {
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

            for(var i = 0; i < towers.Length; i++)
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

            for(var i = 0; i < pillboxes.Length; i++)
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
        canvas.GetComponent<UpdateCanvas>().GameOverText();
    }
}
