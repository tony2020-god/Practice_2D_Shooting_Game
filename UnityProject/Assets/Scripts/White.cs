using UnityEngine;

public class White : MonoBehaviour
{
    #region 練習區域 - 在此區域內練習

    #endregion
    public AudioClip SoundFire;
    public Transform point;
    [Header("子彈速度"), Range(0, 5000)]
    public int bulletspeed = 800;
    [Header("子彈"), Tooltip("用來儲存子彈的預置物")]
    public GameObject bullet;
    public AudioSource aud;

    public void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        aud = GetComponent<AudioSource>();
    }
    public void Update()
    {
        
        Fire();
        
    }
    private void Fire()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            aud.PlayOneShot(SoundFire);
            GameObject temp = Instantiate(bullet, point.position, point.rotation);
            temp.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletspeed + transform.up * 100);
        }
    }
    #region KID 區域 - 不要偷看 @3@
    [Header("移動速度"), Range(0f, 100f)]
    public float speed = 1.5f;

    private Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        rig.AddForce(transform.right * Input.GetAxisRaw("Horizontal") * speed);
    }
    #endregion
}
