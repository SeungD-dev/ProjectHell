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


	GameManager gameManager;
	private IEnumerator Start()
	{
		startDialog01 = true;

		// 첫 번째 대사 분기 시작
		
		yield return new WaitUntil(() => dialog01.UpdateDialog2());
		


		// 대사 분기 사이에 원하는 행동을 추가할 수 있다.

		// 캐릭터를 움직이거나 아이템을 획득하는 등의.. 현재는 5-4-3-2-1 카운트 다운 실행
		//textCountdown.gameObject.SetActive(true);
		int count = 50;
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
		
		yield return new WaitUntil(() => dialog02.UpdateDialog2());
		
		/*textCountdown.gameObject.SetActive(true);
		textCountdown.text = "The End";*/

		yield return new WaitForSeconds(2);

		//UnityEditor.EditorApplication.ExitPlaymode();
	}
}
