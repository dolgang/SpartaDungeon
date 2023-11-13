# Chapter 2 프로그래밍기초 개인과제
## 과제명 : SpartaDungeon

개인과제로 제작한 콘솔창 텍스트 게임 'SpartaDungeon' 입니다.
지식 및 시간 관계 상 우선 필수기능 위주로 구현하고, 추가 과제는 브랜치를 생성해서 작업하는 식으로 진행하는 중입니다.

### 기능 구성
- 캐릭터 인벤토리 List 추가
- 아이템 클래스 구성 후 객체별로 관리
#### 인벤토리
- 인벤토리 리스트를 반복문으로 출력하여 아이템 생성 및 제거에 자동 대응
```
for (int i = 0; i < player.InventoryCountCheck(); i++)
{
    Item currentItem = player.Inventory[i];

    Console.WriteLine($"- {currentItem.IsEquip()} {currentItem.Name}");
}
```
- 장착 정보를 각 아이템 객체에 가지게 하여 장착중일 시 장착표시 반환
- 장비 장착 시 토글 형식으로 전환, 메소드 호출하여 플레이어 스텟 증감
EquipmentSet(); 메소드
- 상태보기도 Enum을 사용해보고 스텟이 증가했을 때만 증가수치 표기
