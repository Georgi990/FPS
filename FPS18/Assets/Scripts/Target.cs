using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public float health = 50f;
    public static int killedTargets;

    public void TakenDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Die();
            killedTargets += 1;
            Debug.Log(killedTargets);
        }
    }

    private void OnBecameVisible()
    {
        GunDamage.VisibleTargets.Add(gameObject);
    }
    private void OnBecameInvisible()
    {
        GunDamage.VisibleTargets.Remove(gameObject);
    }


    public void Die()
    {
        Destroy(gameObject);
    }
}
