using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebAttr : MonoBehaviour
{
    public float disappearTime;
    public int damage;

    void Start()
    {
        Destroy(gameObject, disappearTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fish")
        {
            collision.SendMessage("TakeDamage", damage);
        }
    }

}
