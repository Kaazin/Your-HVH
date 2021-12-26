using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxScript : MonoBehaviour
{
    EnemyHealth enemyHealth;

    public float meleeDmg;

    private void OnTriggerEnter(Collider col)
    {
        if(col.transform.gameObject.layer == 6)
        {
            enemyHealth = col.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
                enemyHealth.TakeDamage(meleeDmg);
            GetComponent<BoxCollider>().enabled = false;

        }
    }
}
