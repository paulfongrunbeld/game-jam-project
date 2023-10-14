using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private List<GameObject> healthPoints;
    [SerializeField] private GameObject numberToRemove;
    [SerializeField] private PlayerBehaviorSetter setter;
    [SerializeField] private GameObject player;
    public MusicManager musicManager;
    public int health = 10;
    private void Awake() => numberToRemove = healthPoints[healthPoints.Count - 1];

	private void Start()
	{
        setter = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviorSetter>();
        player = GameObject.FindGameObjectWithTag("Player");
        musicManager = GameObject.FindGameObjectWithTag("music").GetComponent<MusicManager>();
    }

	public void GetDamage()
    {
        
        numberToRemove.SetActive(false);
        musicManager.Punch();
        health--;
		if (health == 0)
		{
            Destroy(player.gameObject);
		}
		
        int indexToRemove = healthPoints.IndexOf(numberToRemove);
        if (indexToRemove > 0)
            numberToRemove = healthPoints[indexToRemove - 1];
	
    }
}
