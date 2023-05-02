using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog_Stage3 : MonoBehaviour
{
	[SerializeField]
	private Speaker[] speakers; //대화에 참여하는 캐릭터들의 UI 배열

	public GameObject line;
	public AudioSource bgm;

	[SerializeField]
	private DialogData3[] dialogs3; // 현재 분기의 대사 목록 배열
	[SerializeField]

	DialogStart_Stage3 dialogStart_Stage3;
	private bool isFirst3 = true; // 최초 1회만 호출하기 위한 변수
	private int currentDialogIndex3 = -1; // 현재 대사 순번
	private int currentSpeakerIndex3 = 0; // 현재 말을 하는 화자(Speaker)의 speakers 배열 순번
	private float typingSpeed3 = 0.1f;           // 텍스트 타이핑 효과의 재생 속도
	private bool isTypingEffect3 = false;       // 텍스트 타이핑 효과를 재생중인지
	public bool isGameStarted = false;
	// Update is called once per frame
	private void Awake()
	{
		if (dialogStart_Stage3.startDialog01 == true)
		{
			UpdateDialog3();
		}
		//if (dialogStart_Stage2.startDialog02 == true && dialogStart_Stage2.startDialog01 == false)
		//UpdateDialog2();
	}

	private void Setup3()
	{
		//모든 대화 관련 게임 오브젝트 비활성화
		for (int i = 0; i < speakers.Length; ++i)
		{
			SetActiveObjects(speakers[i], false);
			//캐릭터 이미지 보이게
			speakers[i].spriteRenderer3.gameObject.SetActive(true);
		}
		//line.SetActive(false);
		//gameManager.Pause();
	}
	public bool UpdateDialog3()
	{
		// 대사 분기가 시작될 때 1회만 호출
		if (isFirst3 == true)
		{
			// 초기화. 캐릭터 이미지는 활성화하고, 대사 관련 UI는 모두 비활성화
			Setup3();

			// 자동 재생(dialogStart_Stage2.startDialog=true)으로 설정되어 있으면 첫 번째 대사 재생
			if (dialogStart_Stage3.startDialog01 == true) SetNextDialog3();

			isFirst3 = false;
		}

		/*if(dialogStart_Stage2.startDialog02 == true && dialogStart_Stage2.startDialog01 == false)
        {
			SetNextDialog2();
        }*/

		if (Input.GetKeyDown(KeyCode.Mouse0) && isGameStarted == false)//Input.touchCount > 0 ||
		{
			//Touch touch = Input.GetTouch(0);
			//if (touch.phase == TouchPhase.Began || Input.GetKeyDown(KeyCode.Space))
			//{
			// 텍스트 타이핑 효과를 재생중일때 터치하면 타이핑 효과 종료
			if (isTypingEffect3 == true)
			{
				isTypingEffect3 = false;

				// 타이핑 효과를 중지하고, 현재 대사 전체를 출력한다
				StopCoroutine("OnTypingText3");
				speakers[currentSpeakerIndex3].textDialog3.text = dialogs3[currentDialogIndex3].dialog3;
				// 대사가 완료되었을 때 출력되는 커서 활성화
				speakers[currentSpeakerIndex3].objectArrow3.SetActive(true);

				return false;
			}

			// 대사가 남아있을 경우 다음 대사 진행
			if (dialogs3.Length > currentDialogIndex3 + 1)
			{
				SetNextDialog3();
			}
			// 대사가 더 이상 없을 경우 모든 오브젝트를 비활성화하고 true 반환
			else
			{
				// 현재 대화에 참여했던 모든 캐릭터, 대화 관련 UI를 보이지 않게 비활성화
				for (int i = 0; i < speakers.Length; ++i)
				{
					SetActiveObjects(speakers[i], false);
					// SetActiveObjects()에 캐릭터 이미지를 보이지 않게 하는 부분이 없기 때문에 별도로 호출
					speakers[i].spriteRenderer3.gameObject.SetActive(false);
				}
				//line.SetActive(true);
				//bgm.Play();

				isGameStarted = true;
				/*
				if (isTypingEffect2 == true)
				{
					line.SetActive(false);
				}
				else if (isTypingEffect2 == false)
				{
					line.SetActive(true);
					isGameStarted = true;
				}*/
				return true;
			}
		}
		return false;
	}

	private void SetNextDialog3()
	{
		// 이전 화자의 대화 관련 오브젝트 비활성화
		SetActiveObjects(speakers[currentSpeakerIndex3], false);

		// 다음 대사를 진행하도록 
		currentDialogIndex3++;

		// 현재 화자 순번 설정
		currentSpeakerIndex3 = dialogs3[currentDialogIndex3].speakerIndex3;

		// 현재 화자의 대화 관련 오브젝트 활성화
		SetActiveObjects(speakers[currentSpeakerIndex3], true);
		// 현재 화자 이름 텍스트 설정
		speakers[currentSpeakerIndex3].textName3.text = dialogs3[currentDialogIndex3].name3;
		// 현재 화자의 대사 텍스트 설정
		//speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;
		StartCoroutine("OnTypingText3");
	}
	private void SetActiveObjects(Speaker speaker, bool visible)
	{
		speaker.imageDialog3.gameObject.SetActive(visible);
		speaker.textName3.gameObject.SetActive(visible);
		speaker.textDialog3.gameObject.SetActive(visible);

		// 화살표는 대사가 종료되었을 때만 활성화하기 때문에 항상 false
		speaker.objectArrow3.SetActive(false);

		// 캐릭터 알파 값 변경
		Color color = speaker.spriteRenderer3.color;
		color.a = visible == true ? 1 : 0.2f;
		speaker.spriteRenderer3.color = color;
	}

	private IEnumerator OnTypingText3()
	{
		int index = 0;

		isTypingEffect3 = true;

		// 텍스트를 한글자씩 타이핑치듯 재생
		while (index < dialogs3[currentDialogIndex3].dialog3.Length)
		{
			speakers[currentSpeakerIndex3].textDialog3.text = dialogs3[currentDialogIndex3].dialog3.Substring(0, index);

			index++;

			yield return new WaitForSeconds(typingSpeed3);
		}

		isTypingEffect3 = false;

		// 대사가 완료되었을 때 출력되는 커서 활성화
		speakers[currentSpeakerIndex3].objectArrow3.SetActive(true);
	}
	[System.Serializable]
	public struct Speaker
	{
		public SpriteRenderer spriteRenderer3; // 캐릭터 이미지(알파값 제어)
		public Image imageDialog3; // 대화창 Image UI
		public TextMeshProUGUI textName3; // 현재 대사중인 캐릭터 이름출력 Text UI
		public TextMeshProUGUI textDialog3; // 현재 대사 출력 Text UI
		public GameObject objectArrow3; //대사가 완료되었을 때 출력되는 커서 오브젝트
	}

	[System.Serializable]
	public struct DialogData3
	{
		public int speakerIndex3; // 이름과 대사를 출력할 현재 DialogSystem의 speakers 배열 순번
		public string name3; // 캐릭터 이름
		[TextArea(3, 5)]
		public string dialog3; // 대사
	}
	[System.Serializable]
	public struct GameObejct
	{
		public GameObject tileNote;
		public GameObject noteBreak;
	}
}