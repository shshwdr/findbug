using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour
{
    
    public GameObject bulletPrefab;
    public float cooldownTime = 2f;
    public float bulletSpeed = 10f;
    float currentCooldownTimer;
    HPCharacterController enemyController;
    Vector3 dir = Vector3.left;
    // Start is called before the first frame update
    void Start()
    {
        enemyController = GetComponentInParent<HPCharacterController>();

    }

    public void Attack()
    {
        //SFXManager.Instance.PlaySFX("rockhit");
        var player = GameManager.Instance.player;
        //var dir = player.transform.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        var quat = Quaternion.AngleAxis(angle, Vector3.forward);

        GameObject bullet = Instantiate(bulletPrefab, transform.position, quat) as GameObject;
        //bullet.GetComponent<EnemyBullet>().GetPlayer(player.transform);
        bullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * bulletSpeed;
        //bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        //bullet.GetComponent<EnemyBullet>().isEnemyBullet = true;
        //StartCoroutine(CoolDown());
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.player.GetComponent<BugablePlayer>().roomName == "battle")
        {
            if (!enemyController.isStuned){
                currentCooldownTimer += Time.deltaTime;
                if (currentCooldownTimer > cooldownTime)
                {
                    currentCooldownTimer = 0;
                    Attack();
                }
            }
        }
    }
}
