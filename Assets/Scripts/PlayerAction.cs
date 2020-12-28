using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    // Start is called before the first frame update
    private float h;
    private float v;
    public float speed = 1.5f;

    Rigidbody2D rigid;
    Animator anim;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        if(anim.GetInteger("hAxisRaw") != h){
            anim.SetBool("isChange",true);
            anim.SetInteger("hAxisRaw",(int)h);
        }else if(anim.GetInteger("vAxisRaw") != v){
            anim.SetBool("isChange",true);
            anim.SetInteger("vAxisRaw",(int)v);
        }else{
            anim.SetBool("isChange",false);
        }
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(h,v)*speed;
    }
}
