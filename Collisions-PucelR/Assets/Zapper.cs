using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zapper : MonoBehaviour
{

    private AudioSource playerMan;
    [SerializeField] private AudioClip zappingSound;
    [SerializeField] private AudioClip boom;
    public GameObject trapExplosion;
    // Start is called before the first frame update
    void Start()
    {
        playerMan = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayZappingSound();
            Invoke("PlayZappingSound", 4.3f);
            Invoke("PlayBoomSound", 9.7f);
            Invoke("DestroyAndExplode", 10);
        }
    }

    private void PlayZappingSound()
    {
        playerMan.clip = zappingSound;
        playerMan.Play();
    }

    private void PlayBoomSound()
    {
        playerMan.clip = boom;
        playerMan.Play();
    }

    public void DestroyAndExplode()
    {
        Destroy(gameObject, 1.5f);
        Transform trapSpot = gameObject.transform;
        Vector3 modifiedPosition = trapSpot.position;
        Instantiate(trapExplosion, modifiedPosition, trapSpot.rotation);
        PlayBoomSound();
    }
}
