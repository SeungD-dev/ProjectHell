using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog_Stage1 : MonoBehaviour
{
    [SerializeField]
    private Speaker[] speakers; //대화에 참여하는 캐릭터들의 UI 배열
    [SerializeField]
    private DialogData[] dialogs1; // 현재 분기의 대사 목록 배열
	[SerializeField]

	DialogStart_Stage1 dialogStart_Stage1;
    private bool isFirst1 = true; // 최초 1회만 호출하기 위한 변수
    private int currentDialogIndex1 = -1; // 현재 대사 순번
    private int currentSpeakerIndex1 = 0; // 현재 말을 하는 화자(Speaker)의 speakers 배열 순번
    private float typingSpeed1 = 0.1f;           // 텍스트 타이핑 효과의 재생 속도
    private bool isTypingEffect1 = false;        // 텍스트 타이핑 효과를 재생중인지

    // Update is called once per frame
    private void Awake()
    {
		if (dialogStart_Stage1.startDialog01==true)
			UpdateDialog1();
		

	}
    /*private void Update()
    {
		if (dialogStart_Stage1.startDialog02 == true)
			UpdateDialog1();
	}*/

    private void DisableObjects()
    {
		// 모든 대화 관련 게임 오브젝트 비활성화

		for (int i = 0; i < speakers.Length; ++i)
		{
			SetActiveObjects(speakers[i], false);
			//캐릭터 이미지도 안 보이게
			speakers[i].spriteRenderer1.gameObject.SetActive(false);
		}
	}

    private void Setup1()
    {
        //모든 대화 관련 게임 오브젝트 비활성화
        for (int i = 0; i < speakers.Length; ++i)
        {
            SetActiveObjects(speakers[i], false);
            //캐릭터 이미지 보이게
            speakers[i].spriteRenderer1.gameObject.SetActive(true);
        }
    }

	public bool UpdateDialog1()
	{
		// 대사 분기가 시작될 때 1회만 호출
		if (isFirst1 == true)
		{
			// 초기화. 캐릭터 이미지는 활성화하고, 대사 관련 UI는 모두 비활성화
			Setup1();
			

			// 자동 재생(dialogStart_Stage1.startDialog=true)으로 설정되어 있으면 첫 번째 대사 재생
			if (dialogStart_Stage1.startDialog01==true) SetNextDialog1();

			isFirst1 = false;
		}

		if (Input.GetKeyDown(KeyCode.Mouse0))//Input.touchCount > 0 ||
		{
			//Touch touch = Input.GetTouch(0);
			//if (touch.phase == TouchPhase.Began || Input.GetKeyDown(KeyCode.Space))
			//{
				// 텍스트 타이핑 효과를 재생중일때 터치하면 타이핑 효과 종료
				if (isTypingEffect1 == true)
				{
					isTypingEffect1 = false;

					// 타이핑 효과를 중지하고, 현재 대사 전체를 출력한다
					StopCoroutine("OnTypingText");
					speakers[currentSpeakerIndex1].textDialog1.text = dialogs1[currentDialogIndex1].dialog;
					// 대사가 완료되었을 때 출력되는 커서 활성화
					speakers[currentSpeakerIndex1].objectArrow1.SetActive(true);

					return false;
				}

				// 대사가 남아있을 경우 다음 대사 진행
				if (dialogs1.Length > currentDialogIndex1 + 1)
				{
					SetNextDialog1();
				}
				// 대사가 더 이상 없을 경우 모든 오브젝트를 비활성화하고 true 반환
				else
				{
					// 현재 대화에 참여했던 모든 캐릭터, 대화 관련 UI를 보이지 않게 비활성화
					for (int i = 0; i < speakers.Length; ++i)
					{
						SetActiveObjects(speakers[i], false);
						// SetActiveObjects()에 캐릭터 이미지를 보이지 않게 하는 부분이 없기 때문에 별도로 호출
						speakers[i].spriteRenderer1.gameObject.SetActive(false);
					}

					return true;
				}
			//}
		}

		return false;
	}

	private void SetNextDialog1()
	{
		// 이전 화자의 대화 관련 오브젝트 비활성화
		SetActiveObjects(speakers[currentSpeakerIndex1], false);

		// 다음 대사를 진행하도록 
		currentDialogIndex1++;

		// 현재 화자 순번 설정
		currentSpeakerIndex1 = dialogs1[currentDialogIndex1].speakerIndex;

		// 현재 화자의 대화 관련 오브젝트 활성화
		SetActiveObjects(speakers[currentSpeakerIndex1], true);
		// 현재 화자 이름 텍스트 설정
		speakers[currentSpeakerIndex1].textName1.text = dialogs1[currentDialogIndex1].name;
		// 현재 화자의 대사 텍스트 설정
		//speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;
		StartCoroutine("OnTypingText1");
	}

	private void SetActiveObjects(Speaker speaker, bool visible)
	{
		speaker.imageDialog1.gameObject.SetActive(visible);
		speaker.textName1.gameObject.SetActive(visible);
		speaker.textDialog1.gameObject.SetActive(visible);

		// 화살표는 대사가 종료되었을 때만 활성화하기 때문에 항상 false
		speaker.objectArrow1.SetActive(false);

		// 캐릭터 알파 값 변경
		Color color = speaker.spriteRenderer1.color;
		color.a = visible == true ? 1 : 0.2f;
		speaker.spriteRenderer1.color = color;
	}

	private IEnumerator OnTypingText1()
	{
		int index = 0;

		isTypingEffect1 = true;

		// 텍스트를 한글자씩 타이핑치듯 재생
		while (index < dialogs1[currentDialogIndex1].dialog.Length)
		{
			speakers[currentSpeakerIndex1].textDialog1.text = dialogs1[currentDialogIndex1].dialog.Substring(0, index);

			index++;

			yield return new WaitForSeconds(typingSpeed1);
		}

		isTypingEffect1 = false;

		// 대사가 완료되었을 때 출력되는 커서 활성화
		speakers[currentSpeakerIndex1].objectArrow1.SetActive(true);
	}

	[System.Serializable]
	public struct Speaker
	{
		public SpriteRenderer spriteRenderer1; // 캐릭터 이미지(알파값 제어)
		public Image imageDialog1; // 대화창 Image UI
		public TextMeshProUGUI textName1; // 현재 대사중인 캐릭터 이름출력 Text UI
		public TextMeshProUGUI textDialog1; // 현재 대사 출력 Text UI
		public GameObject objectArrow1; //대사가 완료되었을 때 출력되는 커서 오브젝트
	}

	[System.Serializable]
	public struct DialogData1
	{
		public int speakerIndex1; // 이름과 대사를 출력할 현재 DialogSystem의 speakers 배열 순번
		public string name1; // 캐릭터 이름
		[TextArea(3, 5)]
		public string dialog1; // 대사
	}




}
