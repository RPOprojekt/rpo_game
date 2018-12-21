using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAgent : MonoBehaviour
{

    public Transform target;

    public GameObject player;

    private void LateUpdate()
    {
        transform.localPosition = new Vector3(target.localPosition.x + 8.168f, target.localPosition.y - 10.393f, target.localPosition.z);

        Vector3 norTar = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(norTar.y, norTar.x) * Mathf.Rad2Deg;
        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(0, 0, angle - 270);
        transform.rotation = rotation;
    }
}
