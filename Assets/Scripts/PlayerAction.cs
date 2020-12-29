using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    // Start is called before the first frame update
    private float h;
    private float v;
    public float speed = 1.5f;
    private Vector3 dirVec;
    private GameObject scanObj;


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
        if(h !=0 || v!=0)
            dirVec = new Vector3(h,v,0);
        PlayerAnim(h,v);

        if(Input.GetButtonDown("Jump") && scanObj!=null){
            Debug.Log("this is " + scanObj);
        }
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(h,v)*speed;
        Debug.DrawRay(rigid.position, dirVec*0.8f, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.8f,LayerMask.GetMask("Object"));
        if(rayHit.collider != null){
            scanObj = rayHit.collider.gameObject;
        }else{
            scanObj = null;
        }
    }

    private void PlayerAnim(float h,float v){
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
}
