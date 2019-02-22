using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoleController : MonoBehaviour
{
    Vector3 groundLevel;
    Vector3 undergroundLevel;
    public GameObject effect;
    //public GameObject effect;

    bool isOnGround = true;
    float time = 0;

    void Up()
    {
        transform.DOMoveY(groundLevel.y, 0.5f);
        this.isOnGround = true;
    }
    void Down()
    {
        transform.DOMoveY(undergroundLevel.y, 0.5f);
        this.isOnGround = false;
    }
    void Start()
    {
        this.groundLevel = transform.position;
        this.undergroundLevel = this.groundLevel - new Vector3(0, 0.2f, 0);
        Down();
    }

    public void Hit()
    {
        GameObject g = Instantiate(effect, transform.position + new Vector3(0, 0.04f, 0), effect.transform.rotation);
        Destroy(g, 1.0f);

        this.time = 0;
        Down();
    }

    // Update is called once per frame
    void Update()
    {
        this.time += Time.deltaTime;

        if (this.time > 2.0f)
        {
            this.time = 0;
            if (this.isOnGround)
            {
                Down();
            }
            else
            {
                Up();
            }
        }
    }
}
