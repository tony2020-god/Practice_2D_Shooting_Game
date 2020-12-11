using UnityEngine;
using UnityEngine.UI;

public class Black : MonoBehaviour
{
    #region 練習區域 - 在此區域內練習
     public int HP = 10;
    [Header("血量")]
    public Text HPTEXT;
    public AudioClip Soundhit;
    public AudioSource aud;
    private Rigidbody2D rig;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    private void Hit()
    {
        if (HP > 1)
        {
            HP = HP - 1;
            HPTEXT.text = "HP: "+ HP;
        }
        else if (HP <= 1)
        {
            Dead();
        }
    }
    private void Dead()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        rig.Sleep();
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        aud.PlayOneShot(Soundhit);
        if (collision.gameObject.tag == "子彈")
        {
            print("hi");
            Hit();
        }
    }
    #endregion

}
