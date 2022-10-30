using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    
    private int HP = 100;
    public Animator anim;
    public Slider healthBar;
    void Update()
    {
        healthBar.value = HP;
    }
    public void TakeDamag(int damageAmount)
    {
        HP -= damageAmount;

        if (HP < 0)
        {
            anim.SetTrigger("IsDeath");
            GetComponent<Collider>().enabled = false;
            healthBar.gameObject.SetActive(false);
            Destroy(gameObject, 5f);

        }
        else
        {
            anim.SetTrigger("Hit");
        }
    }
}
