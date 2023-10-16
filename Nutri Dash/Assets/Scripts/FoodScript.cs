using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    private Rigidbody2D foodRig;
    private SpriteRenderer foodSprite;
    [SerializeField] float minForce;
    [SerializeField] float maxForce;

    [SerializeField] private Sprite[] foodSprites;

    void Awake()
    {
        foodRig = GetComponent<Rigidbody2D>();
        foodSprite = GetComponent<SpriteRenderer>();
        SetSprite();
    }


    void Start()
    {
        float forceX = Random.Range(minForce, maxForce);
        float forceY = Random.Range(minForce, maxForce);
        foodRig.AddForce(new Vector2(forceX,forceY));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            GameManager.instance.LoseScore();
        }

        Destroy(gameObject);
    }
    private void SetSprite()
    {
        int randomSprite = Random.Range(0, foodSprites.Length);
        foodSprite.sprite = foodSprites[randomSprite];
    }


}
