using System.Collections;
using UnityEngine;
using TMPro;


public class DialogStart_Stage1 : MonoBehaviour
{
    [SerializeField]
    private Dialog_Stage1 dialog01;


    [SerializeField]
    private Dialog_Stage1 dialog02;

	
	public bool startDialog01 = false, startDialog02 = false;

	public AudioSource audioSource;

	GameManager gameManager;
	Anubis_Anim Boss1Anim;
	BoomFX boomFX;
	public GameObject line;

    private void Awake()
    {
		gameManager = FindObjectOfType<GameManager>();
		Boss1Anim = FindObjectOfType<Anubis_Anim>();
		boomFX = FindObjectOfType<BoomFX>();

		
    }

    private IEnumerator Start()
	{
		startDialog01 = true;
		audioSource.Pause();
		gameManager.timeStop = true; Boss1Anim.timeStop = true; boomFX.timeStop = true;
		line.SetActive(false);


		// 첫 번째 대사 분기 시작
		yield return new WaitUntil(() => dialog01.UpdateDialog1());
		audioSource.Play();
		line.SetActive(true); gameManager.timeStop = false; boomFX.timeStop = false;
        Boss1Anim.timeStop = false;
		

		// 대사 분기 사이에 원하는 행동을 추가할 수 있다.

		// 캐릭터를 움직이거나 아이템을 획득하는 등의.. 현재는 5-4-3-2-1 카운트 다운 실행
		//textCountdown.gameObject.SetActive(true);
		int count = 69;
		while (count > 0)
		{
			//textCountdown.text = count.ToString();
			count--;
			/*if(count == 0)
            {
				startDialog02 = true;
            }*/

			yield return new WaitForSeconds(1);
		}
		//textCountdown.gameObject.SetActive(false);
		audioSource.Pause();
		line.SetActive(false); Boss1Anim.timeStop = true; gameManager.timeStop = true;
		boomFX.timeStop = true;
		// 두 번째 대사 분기 시작
		yield return new WaitUntil(() => dialog02.UpdateDialog1());
		line.SetActive(true); Boss1Anim.timeStop = false; gameManager.timeStop = false; boomFX.timeStop = false;
		audioSource.Play();
		

		yield return new WaitForSeconds(2);

		//UnityEditor.EditorApplication.ExitPlaymode();
	}
}
