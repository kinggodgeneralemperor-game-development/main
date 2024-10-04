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
        strings[0] = "��𿡼��� ���̴� ���� �������Դϴ�. ������ �����ϸ鼭 �ش� ���� �ӿ� ������ �Ӽ��� �����մϴ�. ����� ���� ���� �Ӽ��� �����ϸ� ���� ������ ������ �� �ܰ� ��ȭ�ϴ� Ư¡�� �ֽ��ϴ�. ��� �����̵� �� �Խ��ϴ�.";
        strings[1] = "���� �̷���� �������Դϴ�. ������ ������ �ִ� �������Դϴ�. ������ ���� �������� �ھ�� �Ҽ����� ���� ���⿡ ������ �������̳� ���������� ���ǰ� �մϴ�. �����̳� ������ ���� ������ ���� ������ ������ ��ȣ�մϴ�.\r\n";
        strings[2] = "��ó�� �Ӱ� ���� �������Դϴ�. ���ο� ������ ������ ����� �����ϸ�, �̷��� ������ ���⹰�� ���� ���ɴϴ�. ������ �������� ������ �������� �������� ���� ������ ���������� �ھ�� �����մϴ�. �丶�� ���� ������ ���� ���մϴ�.\r\n";
        strings[3] = "��°������ �����ع��� ������ ���� ���� �������Դϴ�. ������ �����ϸ� �̸� ������ ������ ����� �����մϴ�. �̿� ���� ������ ���� ������ �ٰ� ������, ����� ������ ������ �����ع��� �ڴܳ����� ����� �����ϴٰ� �մϴ�. ���̳� �ǰ����� Ư�� �����մϴ�.\r\n";
        strings[4] = "�ܴ��� �������Դϴ�. ��ġ ����� ���� ���Ǹ� ���ϰ� �ֽ��ϴ�. �Ʒ����� ��쿡�� �������� ���� ���ǰ� ���� ����մϴ�. ������ ������ Ż�Ǹ� �����ϸ�, �������� ��� ������ �ݼ����� ����մϴ�. ������ ���������� �� ũ�Ⱑ ��������� Ư¡�� �����ϴ�. �ھ �������� �ʴ� ������ ������ ���Դϴ�. ö���� ���� ������ ��ȣ�մϴ�.\r\n";
        strings[5] = "���� ������ ���� ���� �������Դϴ�. �ھ�� ����� ������ �����ϴ�. ������ �Դ� ��ĵ�, �ھ� ������ ������ �������� ���� Ư���� ���Դϴ�. ���ڳ� ������ ���� �Ѹ� ������ ��ȣ�մϴ�.";
        strings[6] = "�� �̿ܿ��� �ƹ��� ���� ���� �̼����� �����̴�. �����ڵ��� ������ �� �����ϱ� ���� �߻��� �κη��� �ִ� ������ �԰� �Ѵ�. ���� ���⿡ ���� ���ǰ� �Ѵ�.";
        strings[7] = "�Ǹ��� �����̶�� �ҹ��� ���� �����̴�. ������� ä�Ҷ�� �̸����� ������ ������, ������ ä�Ұ� �ƴ� �����̶�� �̾߱Ⱑ ����. �� ��ü�� ������ ���̴�.";
        strings[8] = "���̴�.";
        strings[9] = "����� ����� �ܴ��� ä���̴�. �ص� ���濡���� ���� �� ä�Ҹ� ������ ���� ���⵵ �Ѵٴ� ���� ����. �ش� ä�Ұ� �� ������ ���� ö�� ����� ������ �ӱݰ� �ִٴ� ������ ����.";
        strings[10] = "���ڴ� ������ �������̸�, �ؼҼ��� ���� �������� ���� �� �ִ� ��ġǰ�̴�. �̸� ����ϴ� ���� ������ �����Ͽ� �����ϱ⿡ �Ͼϸ��� �ŷ��Ǵ� ���ڸ� ���ϴ� �� �ܿ��� �⸣�� ����� ���ٰ� �Ѵ�.";
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