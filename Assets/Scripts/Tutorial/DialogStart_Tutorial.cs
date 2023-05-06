using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogStart_Tutorial : MonoBehaviour
{
	[SerializeField]
	private Dialog_Tutorial dialog01;

	[SerializeField]
	private Dialog_Tutorial dialog02;

    [SerializeField]
    private Dialog_Tutorial dialog03;


    public bool startDialog01 = false, startDialog02 = false;

	PlayerControl playerControl;
    public GameObject line;
	public Image leftB, rightB, jumpB, absorbB;
	bool tutorialNum1, tutorialNum2 = false;

	private void Awake()
	{
		playerControl = FindObjectOfType<PlayerControl>();
	}

	private IEnumerator Start()
	{
		startDialog01 = true;
	    
		line.SetActive(false);
		
		// 첫 번째 대사 분기 시작
		yield return new WaitUntil(() => dialog01.UpdateDialogT());
        leftB.GetComponent<Image>().color = Color.red;
        rightB.GetComponent<Image>().color = Color.red;
		line.SetActive(true);

		// 대사 분기 사이에 원하는 행동을 추가할 수 있다.

		// 캐릭터를 움직이거나 아이템을 획득하는 등의.. 현재는 5-4-3-2-1 카운트 다운 실행
		
		//yield return new WaitForSeconds(2);
	}

	private void Update()
	{
		if (playerControl.leftC >= 1 && playerControl.rightC >= 1 && !tutorialNum1)
		{
			StartCoroutine(Tutorial1());
		}
		if(playerControl.jumpC >= 1 && tutorialNum1 && !tutorialNum2)
		{
			StartCoroutine (Tutorial2());
		}
	}
	private IEnumerator Tutorial1()
	{
        yield return new WaitForSeconds(2);
		playerControl.jumpC = 0;
        leftB.GetComponent<Image>().color = Color.white;
        rightB.GetComponent<Image>().color = Color.white;
		jumpB.GetComponent<Image>().color = Color.red;
		line.SetActive(false);
        // 두 번째 대사 분기 시작
        yield return new WaitUntil(() => dialog02.UpdateDialogT());
		line.SetActive(true);
		tutorialNum1 = true;
	}

	private IEnumerator Tutorial2()
	{
        yield return new WaitForSeconds(2);
        jumpB.GetComponent<Image>().color = Color.white;
        line.SetActive(false);
        // 두 번째 대사 분기 시작
        yield return new WaitUntil(() => dialog03.UpdateDialogT());
        line.SetActive(true);
        tutorialNum2 = true;
    }
}
