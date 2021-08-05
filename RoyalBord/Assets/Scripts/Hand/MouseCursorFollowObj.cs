using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorFollowObj : MonoBehaviour
{

    // �I�u�W�F�N�g���}�E�X�J�[�\���ɒǏ]�����鏈��


    // �ʒu���W
    private Vector3 position;

    // �X�N���[�����W�����[���h���W�ɕϊ������ʒu���W
    private Vector3 screenToWorldPointPositon;

    // Update is called once per frame
    void Update()
    {
        // ���\�b�h�Ăяo��
        PositionFollow();
    }

    // �Ǐ]�����鏈��
    private void PositionFollow()
    {
        // Vector3�Ń}�E�X�ʒu���W���擾����
        position = Input.mousePosition;

        // Z���C��
        position.z = 10f;

        // �}�E�X�ʒu���W���X�N���[�����W���烏�[���h���W�ɕϊ�����
        screenToWorldPointPositon = Camera.main.ScreenToWorldPoint(position);

        // ���[���h���W�ɕϊ����ꂽ�}�E�X���W����
        gameObject.transform.position = screenToWorldPointPositon;
    }
}
