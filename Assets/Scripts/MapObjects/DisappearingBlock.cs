using System.Collections;
using UnityEngine;

public class DisappearingBlock : MonoBehaviour
{
    private SpriteRenderer sr;
    private new Collider2D collider;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Player") && other.contacts[0].normal.y < 0f)
        {
            StartCoroutine(DisappearingDelay());
        }
    }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
    }

    IEnumerator DisappearingDelay()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(AppearingDelay());
    }

    IEnumerator AppearingDelay()
    {
        collider.enabled = false;
        sr.enabled = false;
        yield return new WaitForSeconds(3f);
        collider.enabled = true;
        sr.enabled = true;
    }
}
