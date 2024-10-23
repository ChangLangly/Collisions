using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteract : Player
{
    IEnumerator trappedCoroutine;
    public bool isZapping;
    public TMP_Text scoreText;
    public TMP_Text healthText;
    public GameObject teslaArcs;
    public GameObject gun;
    public GameObject bulletObject;
    public Transform bulletPoint;
    Vector3 shootDirection;

    // Start is called before the first frame update
    void Start()
    {
        trappedCoroutine = Trapped();
        Health = 100;
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health " + "- " + health; 
        scoreText.text = "Score " + "- " + score;
        CheckForZapping();
        Shoot();
        Lose();
        Win();
        shootDirection = Camera.main.transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("teslaTrap"))
        {
            Transform trapSpot = other.transform;
            Vector3 modifiedPosition = trapSpot.position;
            GameObject teslaArcers = Instantiate(teslaArcs, modifiedPosition, trapSpot.rotation);
            isZapping = true;
            Invoke("StopZapping", 10);
            Destroy(teslaArcers, 10);
            Destroy(other.gameObject, 10);
            StartCoroutine(trappedCoroutine);
            Invoke("StopZappingDamage", 10);
            Debug.Log("Entered Trap");
        }

        if (other.CompareTag("pickup"))
        {
            Score += 1;
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("teslaTrap"))
        {
            if (trappedCoroutine != null)
            {
                StopZappingDamage();
                Debug.Log("Exited Trap");
            }
        }
    }

    private void StopZapping()
    {
        isZapping = false;
    }

    private void StopZappingDamage()
    {
        StopCoroutine(trappedCoroutine);
    }

    private void CheckForZapping()
    {
        if (GameObject.FindGameObjectWithTag("teslaArcs") == null)
        {
            StopZappingDamage();
        }
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
                Debug.Log("Fired Gun");
                GameObject bullet = Instantiate(bulletObject, bulletPoint.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 80, ForceMode.Impulse);
        }
    }

    private void Lose()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }

    private void Win()
    {
        if (Score >= 10)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
