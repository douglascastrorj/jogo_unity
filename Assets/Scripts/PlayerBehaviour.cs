using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour {

    public int lifes;
    public int rings;
    public float velocidade;
    public float forcaPulo;
    public string nome;

    public Text textLifes;
    public Text textRings;

    private Rigidbody2D rigidBody;
    private Animator animator;

    private bool isOnGround = true;
    private int maxJumps = 2;
    private int countJumps = 0;

    // Use this for initialization
    void Start () {
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        Animator animator = GetComponent<Animator>();

        this.rigidBody = rigidBody;
        this.animator = animator;

        textLifes.text = lifes.ToString();
        textRings.text = rings.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("plataforma"))
        {
            isOnGround = true;
            countJumps = 0;
            animator.SetBool("jumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("plataforma"))
        {
            isOnGround = false;
        }
    }

    void jump()
    {
        float movimento = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector2(movimento * velocidade, rigidBody.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && (isOnGround || countJumps < maxJumps))
        {
            rigidBody.velocity = new Vector2(0, forcaPulo);
            //rigidBody.AddForce(new Vector2(0, forcaPulo));
            countJumps++;
            animator.SetBool("jumping", true);
            
        }
    }
	
	// Update is called once per frame
	void Update () {

        float movimento = Input.GetAxis("Horizontal");
        

        bool isWalking = movimento != 0;
        animator.SetBool("walking", isWalking);
        if(movimento < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(movimento > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        this.jump();

    }
}
