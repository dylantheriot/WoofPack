using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
	public int index; //might want to make private in future
	//public string levelName;
	public Animator animator;
	
	public void FadeToLevel(int levelIndex)
	{
		//index = LevelIndex;
		animator.SetTrigger("FadeOut");
		Debug.Log("Successfully setTrigger to fade out");
	}
	
	public void OnFadeComplete() //upon completion of the FadeOut Animation, loads next scene
	{
		Debug.Log("Fade has been completed");
		SceneManager.LoadScene(index);
		Debug.Log("Change scenes successfully");
	}
	
	void OnTriggerEnter2D(Collider2D other) //If player collides with trigger to next level
	{
			if(other.CompareTag("Player"))
			{
				Debug.Log("Successfully collided with Player");
				//Loading level with building index
				FadeToLevel(index); //calls FadeToLevel, which triggers FadeOut Animation
							
				//Loading level with scene name
				//SceneManager.LoadScene("Level2");
				
				//Restart Level
				//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
	}
}
