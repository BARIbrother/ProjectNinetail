using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerSpiritAbsorption : MonoBehaviour
{
    private PlayerState playerState; 
    private Camera mainCam;

    [Header("Absorption Settings")]
    private float lastInputTime = 0f;

    public GameObject AttackArea;

    private void Awake()
    {
        playerState = GetComponent<PlayerState>();
        //rb = GetComponent<Rigidbody2D>();
        mainCam = Camera.main;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame && playerState.stats.can_attack)
        {
            if (Time.time - lastInputTime >= playerState.stats.AbsorbCooldown)
            {
                StartCoroutine(PerformAttackRoutine());
            }
        }
    }

    private IEnumerator PerformAttackRoutine()
    {
        playerState.stats.can_attack = false;
        lastInputTime = Time.time;

        Vector3 mousePos = mainCam.ScreenToWorldPoint(
            new Vector3(
                Mouse.current.position.ReadValue().x,
                Mouse.current.position.ReadValue().y,
                -Camera.main.transform.position.z
            )
        );

        Vector3 attackDir = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(attackDir.y, attackDir.x) * Mathf.Rad2Deg; // attackarea angle
        float speed = playerState.stats.dashSpeed;
        Vector3 startPos = transform.position;

        Vector3 targetPos = startPos + (attackDir * playerState.stats.AbsorbRange);
        
        float distance = Vector3.Distance(startPos, targetPos);
        float duration = distance / speed; 
        float elapsed = 0f;

        AttackArea attackArea = Instantiate(AttackArea).GetComponent<AttackArea>();
        attackArea.SetPosition(startPos + attackDir * playerState.stats.AbsorbRange * 0.5f, angle);
        attackArea.checkHitEnemies();

        while(elapsed < duration)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                targetPos,
                elapsed / duration
            );
            elapsed += Time.deltaTime;
            yield return null;
        }

        foreach(GameObject e in attackArea.hitEnemies)
        {
            Enemy enemy = e.GetComponent<Enemy>();
            if(enemy.runtime.currentAction == EnemyRuntime.EnemyAction.Charmed)
            {
                e.GetComponent<Damageable>().Die_Charmed();
            }
        }
        attackArea.des();

        playerState.stats.can_attack = true;
    }
}
