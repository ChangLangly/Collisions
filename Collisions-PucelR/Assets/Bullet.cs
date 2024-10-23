using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Zapper zapper;
    public GameObject relativeTrap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            zapper = relativeTrap.GetComponent<Zapper>();
            zapper.DestroyAndExplode();
        }
    }
}
