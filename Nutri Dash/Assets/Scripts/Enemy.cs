using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Start()
    {
        StartCoroutine(LifeSpawn());
        Transform playerLocation = PlayerScript.instance.GetPlayerTransform();
        if (transform.position.x - playerLocation.position.x < 0)
        {
            speed *= -1;
        }
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private IEnumerator LifeSpawn()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
