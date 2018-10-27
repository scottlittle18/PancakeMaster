using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    [SerializeField]
    float FallDelay;
    [SerializeField]
    float FallSpeed;

    AudioSource brickFall;

    private bool isFalling;

    private void Start()
    {
        brickFall = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            StartCoroutine("CrumbleDelay");
        }
    }
    public IEnumerator CrumbleDelay()
    {
        yield return new WaitForSeconds(FallDelay);
        this.GetComponent<BoxCollider2D>().enabled = false;
        isFalling = true;
        brickFall.Play();
    }
    private void Update()
    {
        if(isFalling)
        {            
            transform.Translate(Vector3.down * Time.deltaTime * FallSpeed);
        }
    }
}
