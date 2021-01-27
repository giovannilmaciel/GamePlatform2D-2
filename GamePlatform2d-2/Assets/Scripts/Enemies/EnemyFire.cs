using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public float fireRate;

    public Rigidbody2D bulletPrefab;
    public Transform shotSpawn;
    public Vector2 shotImpulse;

    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SetFire", fireRate, fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetFire()
    {
        anim.SetTrigger("Fire");
    }

    private void Fire()
    {
        Rigidbody2D newBullet = Instantiate(bulletPrefab, shotSpawn.position, transform.rotation);
        newBullet.AddForce(shotImpulse, ForceMode2D.Impulse);
        Destroy(newBullet.gameObject, 5);
    }
}
