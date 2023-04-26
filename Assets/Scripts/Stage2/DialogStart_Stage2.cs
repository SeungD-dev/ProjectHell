using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogStart_Stage2 : MonoBehaviour
{
    [SerializeField]
    private Dialog_Stage2 dialog01;


    [SerializeField]
    private Dialog_Stage2 dialog02;
    public bool startDialog01 = false, startDialog02 = false;

	public GameObject line;
	public AudioSource audioSource;

	LineActive_2 lineActive;
	Note note;
	SwordTrail_Y swordTrail;
	BossRandomMove_Y bossRandomMove;
	Izanami_Anim Boss2Anim;

	private void Awake()
    {
        lineActive = FindObjectOfType<LineActive_2>();
		note = FindObjectOfType<Note>();
		bossRandomMove = FindObjectOfType<BossRandomMove_Y>();
		swordTrail = FindObjectOfType<SwordTrail_Y>();
		Boss2Anim = FindObjectOfType<Izanami_Anim>();
	}

    private IEnumerator Start()
	{
		startDialog01 = true;
		audioSource.Pause();
		line.SetActive(false); bossRandomMove.timeStop = true; swordTrail.timeStop = true;
		Boss2Anim.timeStop = true;

		
		// 첫 번째 대사 분기 시작

		yield return new WaitUntil(() => dialog01.UpdateDialog2());
		Invoke("delayBGM", 1.2f); // 여기서 노래 시작 부분 확인(원민이랑 조정 해야함)
		line.SetActive(true); bossRandomMove.timeStop = false; swordTrail.timeStop = false;
		Boss2Anim.timeStop = false;
		// 대사 분기 사이에 원하는 행동을 추가할 수 있다.

		// 캐릭터를 움직이거나 아이템을 획득하는 등의.. 현재는 5-4-3-2-1 카운트 다운 실행
		//textCountdown.gameObject.SetActive(true);
		int count = 53;
		while (count > 0)
		{
			//textCountdown.text = count.ToString();
			count--;
			/*if(count == 0)
            {
				startDialog01 = false;
				startDialog02 = true;
            }*/

			yield return new WaitForSeconds(1);
		}
		//textCountdown.gameObject.SetActive(false);

		// 두 번째 대사 분기 시작
		audioSource.Pause();
		line.SetActive(false); bossRandomMove.timeStop = true; swordTrail.timeStop = true;
		Boss2Anim.timeStop = true;
		yield return new WaitUntil(() => dialog02.UpdateDialog2());
		line.SetActive(true); bossRandomMove.timeStop = false; swordTrail.timeStop = false;
		Boss2Anim.timeStop = false;
		audioSource.Play();
		/*textCountdown.gameObject.SetActive(true);
		textCountdown.text = "The End";*/

		yield return new WaitForSeconds(2);

		//UnityEditor.EditorApplication.ExitPlaymode();
	}

	void delayBGM()
    {
		audioSource.Play();
    }
}
