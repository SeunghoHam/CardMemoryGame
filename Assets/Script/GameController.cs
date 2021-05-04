using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [SerializeField] private Sprite BGImage;

    public Sprite[] puzzles;
    public List<Sprite> gamePuzzles = new List<Sprite>(); 
    
    public List<Button> buttons = new List<Button>(); // 리스트로 선언된 ' buttons '

    void Awake() // 카드 앞면 리소스를 할당하기 위해 생성
    {
        puzzles = Resources.LoadAll<Sprite>("PlayingCards"); // Resource -> PlayingCards 폴더의 스프라이트들 puzzles 에 할당
    }
    void Start() // AddCardButton 스크립트의 Awake 함수에서 인스턴스화를 시킨 후 함수를 실행한다. -> Start
    {
        GetButtons();
        AddListeners();
        AddGamePuzzles();
    }

    void GetButtons()
    {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

            for(int i=0; i < objects.Length; i++)
            {
                buttons.Add(objects[i].GetComponent<Button>()); // 인스턴스화 시킨 버튼을 받아온다
                buttons[i].image.sprite = BGImage; // 버튼의 이미지를 카드 뒷면으로 
            }
    }


    void AddGamePuzzles() // 리스트로 선언된 gamePuzzles 를 이용해서 스프라이트 중   펼쳐진 카드갯수/2 개의 짝을 찾아오기 위한 함수
    {
        int looper = buttons.Count;
        int index = 0;

        for(int i =0; i< looper; i++)
        {
            if(index == looper / 2)
            {
                index = 0;
            }
            gamePuzzles.Add(puzzles[index]);
            index++;
        }
    }
    void AddListeners() // AddListener 매서드를 사용하기 위한 함수
    {
        //for(int i=0; i < buttons.Count; i++)
        // foreach 반복문 = 변수를 배열에 담아서 배열에 담긴 변수들을 반복
        // 리스트 Button 형은 buttons의 갯수만큼 반복.
        // 리스트를 가져오는 경우 for 반복 보다 foreach 반복이 더 좋다.

        // 카드들을 동적으로 생성하기때문에 인스펙터에서 실행할 함수를 적용시킬 수 없다.
        foreach(Button btn in buttons)
        {
            btn.onClick.AddListener(() => PickPuzzle()); // AddListener = 함수를 불러온다. 콜백
           
        }

        
        
        
    }   
    public void PickPuzzle()    
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name; //
        Debug.Log("용 별 " + name);
    }
}
