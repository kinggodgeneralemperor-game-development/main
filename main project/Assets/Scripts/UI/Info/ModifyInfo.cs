using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModifyInfo : MonoBehaviour
{
    public Sprite[] sprite = new Sprite[11];
    public Info info;
    public Image image;
    public TextMeshProUGUI text;
    string[] strings = new string[11];

    private void Start()
    {
        strings[0] = "어디에서나 보이는 흔한 슬라임입니다. 음식을 섭취하면서 해당 음식 속에 함유된 속성을 흡수합니다. 충분히 많은 양의 속성을 흡수하면 가장 적합한 성질로 한 단계 진화하는 특징이 있습니다. 어떠한 음식이든 잘 먹습니다.";
        strings[1] = "물로 이루어진 슬라임입니다. 깨끗한 생수를 주는 슬라임입니다. 레벨이 높은 슬라임의 코어에는 불순물이 전혀 없기에 보통은 공업용이나 종교용으로 사용되곤 합니다. 수박이나 복숭아 같이 수분이 많이 함유된 음식을 선호합니다.\r\n";
        strings[2] = "불처럼 붉게 변한 슬라임입니다. 내부에 마나를 모으는 기관이 존재하며, 이러한 마나는 배출물에 섞여 나옵니다. 레벨이 높을수록 음식의 흡수율이 높아지며 더욱 순수한 마나결정을 코어로 배출합니다. 토마토 외의 음식은 먹지 못합니다.\r\n";
        strings[3] = "어째서인지 멸종해버린 나무의 종을 닮은 슬라임입니다. 음식을 섭취하면 이를 변형해 나무로 만들어 배출합니다. 이에 대한 원리는 아직 밝혀진 바가 없으며, 배출된 나무의 종류는 멸종해버린 자단나무의 원목과 동일하다고 합니다. 콩이나 건과류를 특히 좋아합니다.\r\n";
        strings[4] = "단단한 슬라임입니다. 마치 곤충과 같은 외피를 지니고 있습니다. 아랫배의 경우에는 움직임을 위해 외피가 없어 취약합니다. 음식을 먹으면 탈피를 진행하며, 껍데기의 경우 가공해 금속으로 사용합니다. 레벨이 높아질수록 그 크기가 비대해지는 특징을 가집니다. 코어를 생성하지 않는 유일한 슬라임 종입니다. 철분이 많은 음식을 선호합니다.\r\n";
        strings[5] = "가장 밝혀진 것이 없는 슬라임입니다. 코어로 희귀한 광물을 뱉어냅니다. 음식을 먹는 방식도, 코어 생성의 원리도 밝혀지지 않은 특이한 종입니다. 감자나 고구마 같은 뿌리 음식을 선호합니다.";
        strings[6] = "물 이외에는 아무런 맛이 없는 이세계의 수박이다. 여행자들이 깨끗한 물 섭취하기 위해 야생에 널부러져 있는 과일을 먹곤 한다. 맛이 없기에 비료로 사용되곤 한다.";
        strings[7] = "악마의 과일이라는 소문이 도는 과일이다. 사람들이 채소라는 이름으로 무역을 하지만, 실제는 채소가 아닌 과일이라는 이야기가 돈다. 맛 자체는 무난한 편이다.";
        strings[8] = "콩이다.";
        strings[9] = "당근은 상당히 단단한 채소이다. 극동 지방에서는 종종 이 채소를 가지고 집을 짓기도 한다는 말이 돈다. 해당 채소가 땅 깊숙한 곳의 철의 기운을 흡수해 머금고 있다는 낭설이 돈다.";
        strings[10] = "감자는 귀족의 전유물이며, 극소수의 상위 계층만이 먹을 수 있는 사치품이다. 이를 재배하는 것은 국가의 관리하에 가능하기에 암암리에 거래되는 종자를 구하는 것 외에는 기르는 방법이 없다고 한다.";
    }

    public void ShowInfo(int InfoNum)
    {
        if(info.CheckCollected(InfoNum))
        {
            image.color = new Color(1, 1, 1, 1);

            text.text = strings[InfoNum];
            image.sprite = sprite[InfoNum];
        }
        else
        {
            text.text = "";
            image.color = new Color(1, 1, 1, 0);
        }
    }
}
