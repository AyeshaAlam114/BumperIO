using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 500;
    public Texture[] texture;
    public Color[] colorArray;
    public GameObject hittedBy;
    public bool isToBeDestroyed = false;

    [SerializeField] int sizeIncreaser = 1;
    [SerializeField] int massIncreaser = 2;
    Rigidbody charRb;
    bool once;
    CameraController camera;


    // Start is called before the first frame update
    void Start()
    {
        once = true;
        charRb = GetComponent<Rigidbody>();
        camera = Camera.main.transform.parent.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        Die();
        if (hittedBy != null)
        {
            if (hittedBy.GetComponent<CharacterController>().isToBeDestroyed)
                hittedBy = null;
        }
    }

    public void IncreaseStrength()
    {
        IncreaseSize();
        IncreaseMass();
        IncreaseForce();
        ChangeTexture();
        ChangeColor();
    }
    void IncreaseSize()
    {
        transform.localScale = new Vector3(transform.localScale.x+ sizeIncreaser, 
                                            transform.localScale.y+ sizeIncreaser,
                                            transform.localScale.z+ sizeIncreaser);
    }
    void IncreaseMass()
    {
        charRb.mass = charRb.mass + massIncreaser;
    }
    void IncreaseForce()
    {
        moveSpeed += 1000;
    }
    void ChangeTexture()
    {
        int indexT = UnityEngine.Random.Range(0, texture.Length);
        GetComponent<Renderer>().material.mainTexture = texture[indexT];
    }
    void ChangeColor()
    {
        int indexC = UnityEngine.Random.Range(0, colorArray.Length);
        GetComponent<Renderer>().material.color = colorArray[indexC];
    }

    void Die()
    {
        if (once)
        {
            if (transform.position.y < -3)
            {
                if (hittedBy != null)
                    hittedBy.GetComponent<CharacterController>().IncreaseStrength();
                isToBeDestroyed = true;
                Invoke(nameof(DestroyMe), 1f);
                once = false;
            }
        }
    }

    void DestroyMe()
    {
        int i = camera.target.IndexOf(this.gameObject.transform);
        camera.target.RemoveAt(i);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
            hittedBy = collision.gameObject;
    }

}
