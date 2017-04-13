using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    bool noChao = false;
    public Transform chaoCheck;
    float chaoRadius = 0.2f;
    public LayerMask oQueEChao;

    Rigidbody2D rgbd2d;
    Animator anim;
    private float playerSpeed = 1f;
    private float jumpHeight = 150f;

	// Use this for initialization
	void Start () {
        //identifica animator e rigidbody2d
        rgbd2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}

    void FixedUpdate()
    {
        //Cria o radius para o ChaoCheck
        noChao = Physics2D.OverlapCircle(chaoCheck.position, chaoRadius, oQueEChao);
        anim.SetBool("walking", noChao);
    }

        // Update is called once per frame
        void Update () {

        //Pega o valor absoluto da axis Horizontal e seta como speed, se speed for > 0.1 no animator ele começa a animação
        anim.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        //parte da movimentação básica do jogador
        if(Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * playerSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(Vector2.right * playerSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }
        //pulo do jogador com o chaocheck
        if (noChao && Input.GetButtonDown("Jump"))
        {
            rgbd2d.AddForce(Vector2.up * jumpHeight);
        }

        if(anim.GetBool("walking") == true)
        {
            anim.SetBool("jumping", false);
        }
        if (anim.GetBool("walking") == false)
        {
            anim.SetBool("jumping", true);
        }


    }
}
