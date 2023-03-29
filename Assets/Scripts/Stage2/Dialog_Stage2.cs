using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog_Stage2 : MonoBehaviour
{
    [SerializeField]
    private Speaker[] speakers; //대화에 참여하는 캐릭터들의 UI 배열
    [SerializeField]
    private DialogData[] dialogs1; // 현재 분기의 대사 목록 배열
    [SerializeField]

    DialogStart_Stage2 dialogStart_Stage2;
    private bool isFirst2 = true; // 최초 1회만 호출하기 위한 변수
    private int currentDialogIndex2 = -1; // 현재 대사 순번
    private int currentSpeakerIndex2 = 0; // 현재 말을 하는 화자(Speaker)의 speakers 배열 순번
    private float typingSpeed2 = 0.1f;           // 텍스트 타이핑 효과의 재생 속도
    private bool isTypingEffect2 = false;        // 텍스트 타이핑 효과를 재생중인지

    // Update is called once per frame
    private void Awake()
    {
        if (dialogStart_Stage2.startDialog01 == true)
            UpdateDialog2();


    }

    private void DisableObjects()
    {
        // 모든 대화 관련 게임 오브젝트 비활성화

        for (int i = 0; i < speakers.Length; ++i)
        {
            SetActiveObjects(speakers[i], false);
            //캐릭터 이미지도 안 보이게
            speakers[i].spriteRenderer2.gameObject.SetActive(false);
        }
    }

    private void Setup2()
    {
        //모든 대화 관련 게임 오브젝트 비활성화
        for (int i = 0; i < speakers.Length; ++i)
        {
            SetActiveObjects(speakers[i], false);
            //캐릭터 이미지 보이게
            speakers[i].spriteRenderer2.gameObject.SetActive(true);
        }
    }
	public bool UpdateDialog2()
	{
		// 대사 분기가 시작될 때 1회만 호출
		if (isFirst2 == true)
		{
			// 초기화. 캐릭터 이미지는 활성화하고, 대사 관련 UI는 모두 비활성화
			Setup2();


			// 자동 재생(dialogStart_Stage2.startDialog=true)으로 설정되어 있으면 첫 번째 대사 재생
			if (dialogStart_Stage2.startDialog01 == true) SetNextDialog2();

			isFirst2 = false;
		}

		if (Input.GetKeyDown(KeyCode.Mouse0))//Input.touchCount > 0 ||
		{
			//Touch touch = Input.GetTouch(0);
			//if (touch.phase == TouchPhase.Began || Input.GetKeyDown(KeyCode.Space))
			//{
			// 텍스트 타이핑 효과를 재생중일때 터치하면 타이핑 효과 종료
			if (isTypingEffect2 == true)
			{
				isTypingEffect2 = false;

				// 타이핑 효과를 중지하고, 현재 대사 전체를 출력한다
				StopCoroutine("OnTypingText");
				speakers[currentSpeakerIndex2].textDialog2.text = dialogs1[currentDialogIndex2].dialog;
				// 대사가 완료되었을 때 출력되는 커서 활성화
				speakers[currentSpeakerIndex2].objectArrow2.SetActive(true);

				return false;
			}

			// 대사가 남아있을 경우 다음 대사 진행
			if (dialogs1.Length > currentDialogIndex2 + 1)
			{
				SetNextDialog2();
			}
			// 대사가 더 이상 없을 경우 모든 오브젝트를 비활성화하고 true 반환
			else
			{
				// 현재 대화에 참여했던 모든 캐릭터, 대화 관련 UI를 보이지 않게 비활성화
				for (int i = 0; i < speakers.Length; ++i)
				{
					SetActiveObjects(speakers[i], false);
					// SetActiveObjects()에 캐릭터 이미지를 보이지 않게 하는 부분이 없기 때문에 별도로 호출
					speakers[i].spriteRenderer2.gameObject.SetActive(false);
				}

				return true;
			}
			//}
		}

		return false;
	}
	private void SetNextDialog2()
	{
		// 이전 화자의 대화 관련 오브젝트 비활성화
		SetActiveObjects(speakers[currentSpeakerIndex2], false);

		// 다음 대사를 진행하도록 
		currentDialogIndex2++;

		// 현재 화자 순번 설정
		currentSpeakerIndex2 = dialogs1[currentDialogIndex2].speakerIndex;

		// 현재 화자의 대화 관련 오브젝트 활성화
		SetActiveObjects(speakers[currentSpeakerIndex2], true);
		// 현재 화자 이름 텍스트 설정
		speakers[currentSpeakerIndex2].textName2.text = dialogs1[currentDialogIndex2].name;
		// 현재 화자의 대사 텍스트 설정
		//speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;
		StartCoroutine("OnTypingText2");
	}
	private void SetActiveObjects(Speaker speaker, bool visible)
	{
		speaker.imageDialog2.gameObject.SetActive(visible);
		speaker.textName2.gameObject.SetActive(visible);
		speaker.textDialog2.gameObject.SetActive(visible);

		// 화살표는 대사가 종료되었을 때만 활성화하기 때문에 항상 false
		speaker.objectArrow2.SetActive(false);

		// 캐릭터 알파 값 변경
		Color color = speaker.spriteRenderer2.color;
		color.a = visible == true ? 1 : 0.2f;
		speaker.spriteRenderer2.color = color;
	}
	private IEnumerator OnTypingText2()
	{
		int index = 0;

		isTypingEffect2 = true;

		// 텍스트를 한글자씩 타이핑치듯 재생
		while (index < dialogs1[currentDialogIndex2].dialog.Length)
		{
			speakers[currentSpeakerIndex2].textDialog2.text = dialogs1[currentDialogIndex2].dialog.Substring(0, index);

			index++;

			yield return new WaitForSeconds(typingSpeed2);
		}

		isTypingEffect2 = false;

		// 대사가 완료되었을 때 출력되는 커서 활성화
		speakers[currentSpeakerIndex2].objectArrow2.SetActive(true);
	}
	[System.Serializable]
	public struct Speaker
	{
		public SpriteRenderer spriteRenderer2; // 캐릭터 이미지(알파값 제어)
		public Image imageDialog2; // 대화창 Image UI
		public TextMeshProUGUI textName2; // 현재 대사중인 캐릭터 이름출력 Text UI
		public TextMeshProUGUI textDialog2; // 현재 대사 출력 Text UI
		public GameObject objectArrow2; //대사가 완료되었을 때 출력되는 커서 오브젝트
	}

	[System.Serializable]
	public struct DialogData1
	{
		public int speakerIndex2; // 이름과 대사를 출력할 현재 DialogSystem의 speakers 배열 순번
		public string name2; // 캐릭터 이름
		[TextArea(3, 5)]
		public string dialog2; // 대사
	}


}
