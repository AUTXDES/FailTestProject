using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingAxe : MonoBehaviour
{
    public int damageAmount = 10;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().TakeDamag(damageAmount);
        }
    }
}
