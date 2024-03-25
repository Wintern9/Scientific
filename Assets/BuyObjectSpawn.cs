using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyObjectSpawn : MonoBehaviour
{
    Transform transform;
    public void Start()
    {
        transform = GetComponent<Transform>();
    }

    public void Spawn(GameObject obj)
    {
        Instantiate(obj, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
    }
}
