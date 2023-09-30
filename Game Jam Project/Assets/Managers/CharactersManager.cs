using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> characters;
	[SerializeField] private GameObject currentCharacter;
	private void Awake()
	{
		currentCharacter = characters[0];
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Keypad1))
			SetCharacter(characters[0]);
		
		if(Input.GetKeyDown(KeyCode.Keypad2))
			SetCharacter(characters[1]);

	}

	private void SetCharacter(GameObject character)
	{
		character.transform.position = currentCharacter.transform.position;
		currentCharacter = character;
		currentCharacter.SetActive(true);

		foreach (GameObject gameObject in characters)
		{
			if (gameObject != currentCharacter)
				gameObject.SetActive(false);
		}
	}


}
