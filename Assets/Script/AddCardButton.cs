using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCardButton : MonoBehaviour
{
    public int PuzzleCount = 4;
    [SerializeField] private Transform puzzleCreateField; // 퍼즐생성 필드의 위치값
    [SerializeField] private GameObject cardButton;
    void Awake()
    {
        for(int i =0; i < PuzzleCount; i++)
        {
            GameObject button = Instantiate(cardButton); // 퍼즐버튼 인스턴스화
            button.name=  "CardButton " + i;
            button.transform.SetParent(puzzleCreateField, false); // false 파라미터 - WorldPositionStays 를 사용하지 않기 위해서 
        }
    }
}
