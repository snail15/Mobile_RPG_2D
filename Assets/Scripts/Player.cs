using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int movementSpeed;
    
    private float h;
    private float v;
    private bool isHorizontal;

    Rigidbody2D rigid;

    private void Awake() 
    {
        rigid = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp= Input.GetButtonUp("Horizontal");
        bool vUp= Input.GetButtonUp("Vertical");

        if (hDown || vUp)
            isHorizontal = true;
        else if (vDown || hUp)
            isHorizontal = false;
        

    }

    void FixedUpdate()
    {
        Vector2 moveVec = isHorizontal ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * movementSpeed;
    }

    
}
