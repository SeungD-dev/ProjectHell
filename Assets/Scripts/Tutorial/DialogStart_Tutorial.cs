using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;


public class DialogStart_Tutorial : MonoBehaviour
{
	[SerializeField]
	private Dialog_Tutorial dialog01;

	[SerializeField]
	private Dialog_Tutorial dialog02;

    [SerializeField]
    private Dialog_Tutorial dialog03;

    [SerializeField]
    private Dialog_Tutorial dialog04;

    [SerializeField]
    private Dialog_Tutorial dialog05;

    [SerializeField]
    private Dialog_Tutorial dialog06;

    [SerializeField]
    private Dialog_Tutorial dialogFail;


    public bool startDialog01 = false;
	public GameObject[] notePrefabs;
	PlayerControl playerControl;
    public GameObject line;
	public Image leftB, rightB, jumpB, absorbB;
	bool tutorialNum1, tutorialNum2, tutorialNum3 = false;
	bool reStart = true;
	int randNote;

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
		if(tutorialNum2)
		{
			if (playerControl.tutorial.CompareTo("first") == 0)
			{
				if (reStart)
				{
                    dialogFail.isFirstT = true;
					dialogFail.isGameStarted = false;
					dialogFail.currentDialogIndex3 = -1;
                }
				reStart = false;
                StartCoroutine(nameof(Tutorial2_fail));
			}
			if (playerControl.tutorial.CompareTo("second") == 0)
			{
                if (reStart)
                {
                    dialog04.isFirstT = true;
                    dialog04.isGameStarted = false;
                    dialog04.currentDialogIndex3 = -1;
                }
                reStart = false;
                StartCoroutine(nameof(Tutorial3));
            }
			if(playerControl.tutorial.CompareTo("third") == 0)
			{
                if (reStart)
                {
                    dialog05.isFirstT = true;
                    dialog05.isGameStarted = false;
                    dialog05.currentDialogIndex3 = -1;
                }
				reStart = false;
                StartCoroutine(nameof(Tutorial04));
            }
			if(playerControl.tutorial.CompareTo("fourth") == 0)
			{
				StartCoroutine(Tutorial05());
			}
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
		absorbB.GetComponent<Image>().color = Color.red;
        line.SetActive(false);
        // 두 번째 대사 분기 시작
        yield return new WaitUntil(() => dialog03.UpdateDialogT());
		randNote = Random.Range(0, 3);
		Instantiate(notePrefabs[randNote], new Vector3(0, 0.2f, 7), Quaternion.identity);
        line.SetActive(true);
        tutorialNum2 = true;
    }

	private IEnumerator Tutorial2_fail()
	{
		yield return new WaitForSeconds(1);
        line.SetActive(false);
        absorbB.GetComponent<Image>().color = Color.red;
        yield return new WaitUntil(() => dialogFail.UpdateDialogT());
		randNote = Random.Range(0, 3);
		Instantiate(notePrefabs[randNote], new Vector3(0, 0.2f, 7), Quaternion.identity);
        line.SetActive(true);
		reStart = true;
        playerControl.tutorial = "";

	}

	private IEnumerator Tutorial3() 
	{
        yield return new WaitForSeconds(1.5f);
        line.SetActive(false);
        absorbB.GetComponent<Image>().color = Color.red;
        yield return new WaitUntil(() => dialog04.UpdateDialogT());
        Instantiate(notePrefabs[randNote], new Vector3(0, 0.2f, 7), Quaternion.identity);
        line.SetActive(true);
        reStart = true;
        playerControl.tutorial = "";
    }

	private IEnumerator Tutorial04()
	{
		yield return new WaitForSeconds(1);
		line.SetActive(false);
        absorbB.GetComponent<Image>().color = Color.white;
        leftB.GetComponent<Image>().color = Color.red;
        rightB.GetComponent<Image>().color = Color.red;
        yield return new WaitUntil(() => dialog05.UpdateDialogT());
        Instantiate(notePrefabs[3], new Vector3(0, 0.2f, 7), Quaternion.identity);
		line.SetActive(true);
        reStart = true;
        playerControl.tutorial = "";
    }

    private IEnumerator Tutorial05()
    {
        yield return new WaitForSeconds(1);
        leftB.GetComponent<Image>().color = Color.white;
        rightB.GetComponent<Image>().color = Color.white;
        line.SetActive(false);
        yield return new WaitUntil(() => dialog06.UpdateDialogT());
        line.SetActive(true);
        reStart = true;
        playerControl.tutorial = "";
    }
}