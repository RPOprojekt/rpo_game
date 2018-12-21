using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeatlh : MonoBehaviour
{
    public GameObject health;
    public GameObject healthBar;
    private float width = 80;

    public GameObject target;

    public AudioSource explosion;

    private void OnTriggerEnter2D(Collider2D other) //ce se sprozi trigger metka
    {
        if (other.CompareTag("Bullet"))
        {
            width = width - 5;
            var theBarRectTransform = health.transform as RectTransform;
            theBarRectTransform.sizeDelta = new Vector2(width, theBarRectTransform.sizeDelta.y);

            if (width == 0)
            {
                Destroy(target); //unici tarco
                explosion.Play();
                Destroy(healthBar);
            }
        }

        if (other.CompareTag("OldRifleBullet"))
        {
            width = width - 15;
            var theBarRectTransform = health.transform as RectTransform;
            theBarRectTransform.sizeDelta = new Vector2(width, theBarRectTransform.sizeDelta.y);

            if (width <= 0)
            {
                Destroy(target); //unici tarco
                explosion.Play();
                Destroy(healthBar);
            }
        }
    }
}
