using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float hp = 40;
    [SerializeField]
    public GameObject Panel;
    [SerializeField]
    public AudioClip ac;



    void Start()
    {
        gameObject.SetActive(true);
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            AudioController.AudioInstance.PlayOneShot(ac);
            Panel.GetComponent<PanelController>().EndGame();
            gameObject.SetActive(false);    
        }
    }
}
