using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using Unity.VisualScripting;

[RequireComponent(typeof(PlayerState))]
//[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBasicAttack : MonoBehaviour
{
    private PlayerState playerState;
    //private Rigidbody2D rb;
    private Camera mainCam;

    [Header("Combo Settings")]
    private int comboStep = 0; // 0: 오른손, 1: 왼손
    private float lastInputTime = 0f;
    private float comboResetTime = 1.0f; // 1초 이상 입력 없으면 초기화
    private bool isAttacking = false;

    [Header("Attack Motion")]
    private float lungeDistance = 0.5f; // 전진 거리 0.5 unit
    private float lungeSpeedMultiplier = 5.0f; // 이동속도의 5배
    private float attackFanAngle = 60f; // 좁은 부채꼴 각도

    private void Awake()
    {
        playerState = GetComponent<PlayerState>();
        //rb = GetComponent<Rigidbody2D>();
        mainCam = Camera.main;
    }

    private void Update()
    {
        // 1. 콤보 초기화 체크 (1초 경과 시)
        if (Time.time - lastInputTime > comboResetTime && comboStep != 0)
        {
            comboStep = 0; // 오른손(0)으로 초기화
        }

        // 2. 공격 입력 (좌클릭)
        // 공격 중이 아니고, 공격 간격(0.3초)이 지났을 때만 가능
        if (Mouse.current.leftButton.wasPressedThisFrame && !isAttacking && playerState.stats.can_attack)
        {
            if (Time.time - lastInputTime >= playerState.stats.atkInterval)
            {
                StartCoroutine(PerformAttackRoutine());
            }
        }
    }

    private IEnumerator PerformAttackRoutine()
    {
        isAttacking = true;
        lastInputTime = Time.time;

        // 마우스 방향 계산
        Vector3 mousePos = mainCam.ScreenToWorldPoint(
            new Vector3(
                Mouse.current.position.ReadValue().x,
                Mouse.current.position.ReadValue().y,
                -Camera.main.transform.position.z
            )
        );
        Vector3 attackDir = (mousePos - transform.position).normalized;
        //Debug.Log(attackDir);
        // --- [1] 전진 이동 (Lunge) ---
        // 속도 = 이동속도(5) * 5 = 25
        float speed = playerState.stats.moveSpeed * lungeSpeedMultiplier;
        Vector3 startPos = transform.position;
        Vector3 targetPos = startPos + (attackDir * lungeDistance);
        
        float distance = Vector2.Distance(startPos, targetPos);
        float duration = distance / speed; // 이동에 걸리는 시간
        float elapsed = 0f;

        //짧은 시간 동안 빠르게 이동
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
        // --- [2] 타격 판정 (부채꼴) ---
        CheckHit(attackDir);

        // --- [3] 애니메이션 및 로직 처리 ---
        if (comboStep == 0)
        {
            // Debug.Log("오른손 할퀴기!");
            // TODO: animator.SetTrigger("AttackRight");
        }
        else
        {
            // Debug.Log("왼손 할퀴기!");
            // TODO: animator.SetTrigger("AttackLeft");
        }

        // --- [4] 콤보 단계 갱신 (0 -> 1 -> 0 반복) ---
        comboStep = (comboStep + 1) % 2;

        isAttacking = false;
    }

    private void CheckHit(Vector2 dir)
    {
        float range = playerState.stats.atkRange;
        float damage = playerState.stats.GetBasicDamage();

        // 1. 사거리 내의 모든 적 감지 (원형)
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range);

        foreach (Collider2D hit in hits)
        {
            // 자기 자신 제외 및 Enemy 태그 확인
            if (hit.gameObject == gameObject) continue;
           if (!hit.CompareTag("Enemy")) continue; // 태그 설정 시 주석 해제

            // 2. 부채꼴 각도 체크
            Vector2 dirToTarget = (hit.transform.position - transform.position).normalized;
            float angleToTarget = Vector2.Angle(dir, dirToTarget);

            // 설정한 각도(60도)의 절반(30도) 이내에 적이 있는지 확인
            if (angleToTarget <= attackFanAngle / 2f)
            {
                // 데미지 적용
                Debug.Log($"[Hit] {hit.name}에게 {damage} 데미지 (손: {(comboStep == 0 ? "오른손" : "왼손")})");
                
                // 적 스크립트의 TakeDamage 함수 호출 예시:
                // hit.GetComponent<Enemy>()?.TakeDamage(damage);
                hit.GetComponent<Damageable>()?.TakePhysicalDamage(damage);
            }
        }
    }

    // 에디터에서 사거리 확인용
    private void OnDrawGizmosSelected()
    {
        if (playerState != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, playerState.stats.atkRange);
        }
    }
}