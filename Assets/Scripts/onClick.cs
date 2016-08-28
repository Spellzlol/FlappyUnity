using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class onClick : MonoBehaviour
{
	public void transition(int sceneId)
	{
		SceneManager.LoadScene(sceneId);
	}
}
