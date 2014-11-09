using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ClickerFunction : MonoBehaviour
{
	public Sprite sprite1; // Drag your first sprite here
	public Sprite sprite2; // Drag your second sprite here

	private SpriteRenderer spriteRenderer;
	public AudioSource soundSource;
	public AudioClip touchButton;

	void Start()
	{
	    spriteRenderer = GetComponent<SpriteRenderer> (); // we are accessing the SpriteRenderer that is attached to the Gameobject
		if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
		spriteRenderer.sprite = sprite1; // set the sprite to sprite1
		AudioSource[] sources = FindObjectsOfType <AudioSource> ();
		foreach (AudioSource s in sources) {
    		if(s.gameObject.name.Contains("keyboard"))
	    		soundSource = s;
		}
		if (soundSource == null) {
			if(sources.Length > 0)
			{
				if(sources[0] != null)
					soundSource = sources[0];
			}
		}

	}
	void Update()
	{
		Ray clickPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitPoint;
		
		// See if the ray collided with an object
		if (Physics.Raycast(clickPoint, out hitPoint))
		{
			if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
			{
				spriteRenderer.sprite = sprite2;
				if(soundSource != null)
				{
				if(touchButton != null)
					{
						soundSource.PlayOneShot(touchButton);
						Debug.Log ("Successfully played sound!");


					}
				}

			}
            if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
			{
				spriteRenderer.sprite = sprite1;

			}
		}
	}
}