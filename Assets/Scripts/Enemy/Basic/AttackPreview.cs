using System.Collections;
using UnityEngine;

public class AttackPreview : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    SpriteRenderer sr;    
    Color c;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        c = sr.color;
        c.a = 0;

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartFadeIn(float dur)
    {
        StartCoroutine(FadeIn(dur));
    }

    IEnumerator FadeIn(float duration)
    {
        float elapsed = 0f;
        while(elapsed < duration)
        {   
            elapsed += Time.deltaTime;
            SetAlpha(elapsed/duration);
            yield return null;
        }
        Destroy(gameObject);
    }

    void SetAlpha(float a)
    {
        c.a = a;
        sr.color = c;
    }

    public void SetPosition(Vector3 center, float angle)
    {
        transform.position = center;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
