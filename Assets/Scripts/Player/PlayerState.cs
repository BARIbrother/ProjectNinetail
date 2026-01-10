using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public int direction = 2;

    [System.Serializable]
    public class PlayerStats
    {
        [Header("Base Stats")]
        public float maxHp = 100f;
        public float currentHp;
        public float maxSpirit = 100f; // 요기 (마나)
        public float currentSpirit;

        [Header("Combat")]
        public float atkPower = 70f;       // 공격력
        public float basicAtkCoeff = 0.1f; // 평타 계수
        public float atkRange = 1.0f;      // 평타 사거리 (1 Unit)
        public float atkInterval = 0.3f;   // 평타 딜레이

        [Header("Movement")]
        public float moveSpeed = 5.0f;     // 이동 속도
        public float dashSpeedCoeff = 3.0f;// 정기흡수 속도 계수

        // 평타 데미지 계산 도우미
        public float GetBasicDamage()
        {
            return atkPower * basicAtkCoeff;
        }

        public void Init()
        {
            currentHp = maxHp;
            currentSpirit = 0;
        }
    }

    public PlayerStats stats = new PlayerStats();

    private void Awake()
    {
        stats.Init();
    }
}
