using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSystem : MonoBehaviour {
    [SerializeField] Transform weaponHolder;//�����,�Z�����Ӧb���a��(��)
    [SerializeField] GameObject weapon;//�Z�����H
    [SerializeField] Transform weaponSheath;//�y���t����,�Z�����Ӧb���a��(�y)

    GameObject currentWeaponInHand;//�N����W����
    GameObject currentWeaponInSheath;//�N���y�W����
    // Start is called before the first frame update
    void Start() {
        if (weapon == null || weaponSheath == null) {//��l���ˬd
            Debug.LogError("Weapon or WeaponSheath is not assigned.");
            return;
        }
        //�i������Instantiate�ͦ��@��weapon�bweaponSheath��transform�W
        currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
        if (currentWeaponInSheath != null) {//���A�ˬd
            Debug.Log("Weapon instantiated in sheath.");
        } else {
            Debug.LogError("Failed to instantiate weapon in sheath.");
        }
    }

    // Update is called once per frame
    void Update() {

    }

    public void DrawWeapon() {//���_�Z����k
        if (currentWeaponInHand == null && currentWeaponInSheath != null) {
            currentWeaponInHand = Instantiate(weapon, weaponHolder.transform);
            Destroy(currentWeaponInSheath);//destroy�|�b�U�@�հ���
            currentWeaponInSheath = null;//�����F����Dangling Reference �����]��null
            //�o���޿��������� ���N�O���F����ƤޥΤ@�Ӥw�g�ӳQ��������H
        }
    }

    public void SheathWeapon() {//���Z����k
        if (currentWeaponInSheath == null && currentWeaponInHand != null) {
            currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
            Destroy(currentWeaponInHand);
            currentWeaponInHand = null;//�z�צP�W
        }
    }

}