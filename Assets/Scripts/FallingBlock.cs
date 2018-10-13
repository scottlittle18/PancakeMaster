using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    [SerializeField]
    private int FallDelay = 3;
    [SerializeField]
    private int FallSpeed = 5;

    private bool isFalling;

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
    }
    private void Update()
    {
        if(isFalling)
        {
            transform.Translate(Vector3.down * Time.deltaTime * FallSpeed);
        }
    }
}
