using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int movementSpeed;

    private float h;
    private float v;
    private bool isHorizontal;
    private Vector3 directionVec;

    Rigidbody2D rigid;
    Animator animator;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        if (hDown)
            isHorizontal = true;
        else if (vDown)
            isHorizontal = false;
        else if (hUp || vUp)
            isHorizontal = h != 0;

        if (animator.GetInteger("hAxisRaw") != h)
        {
            animator.SetBool("directionChanged", true);
            animator.SetInteger("hAxisRaw", (int)h);
        }
            
        else if (animator.GetInteger("vAxisRaw") != v)
        {
            animator.SetBool("directionChanged", true);
            animator.SetInteger("vAxisRaw", (int)v);
        }
        else
            animator.SetBool("directionChanged", false);

        if (vDown && v == 1)
            directionVec = Vector3.up;
        else if (vDown && v == -1)
            directionVec = Vector3.down;
        else if (hDown && h == 1)
            directionVec = Vector3.right;
        else if (hDown && h == -1)
            directionVec = Vector3.left;

    }

    void FixedUpdate()
    {
        Vector2 moveVec = isHorizontal ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * movementSpeed;

        Debug.DrawRay(transform.position, directionVec, Color.red);
    }

    
}
