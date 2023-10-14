using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHitHandler : MonoBehaviour
{
    public Material flashMaterial;
    public SpriteRenderer enemyRenderer;
    public float flashDuration = 0.1f;

    public float health = 7f;

    private Material originalMaterial;

    public static Action onKill;

    public MusicManager musicManager;




    private void Start()
    {
        enemyRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = enemyRenderer.material;
        musicManager = GameObject.FindGameObjectWithTag("music").GetComponent<MusicManager>();
    }

    public void HandleHit()
    {
        StartCoroutine(FlashEnemy());
    }

    private IEnumerator FlashEnemy()
    {
        enemyRenderer.material = flashMaterial;
        yield return new WaitForSeconds(flashDuration);
        enemyRenderer.material = originalMaterial;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("PlayerAttackZone"))
		{
           
            HandleHit();
            health--;
            musicManager.Damage();
			if (health == 0)
			{
                Destroy(gameObject);
                musicManager.audio.Stop();
                musicManager.ambient();
                onKill?.Invoke();
			}
		}
	}
}
