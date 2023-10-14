using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
	[SerializeField] public AudioSource audio;
	[SerializeField] private AudioClip background;
	[SerializeField] private AudioClip combat;

	[SerializeField] private AudioClip punch;
	[SerializeField] private AudioClip damage;

	public static MusicManager instanse;
	private void Awake()
	{
		audio = GetComponent<AudioSource>();
		background = (AudioClip)Resources.Load("background");
		combat = (AudioClip)Resources.Load("combat");
		punch = (AudioClip)Resources.Load("удар");
		damage = (AudioClip)Resources.Load("урон");

		ambient();
	}
	public void ambient() => audio.PlayOneShot(background);
	public void Combat() => audio.PlayOneShot(combat);

	public void Punch() => audio.PlayOneShot(punch);

	public void Damage() => audio.PlayOneShot(damage);





}
