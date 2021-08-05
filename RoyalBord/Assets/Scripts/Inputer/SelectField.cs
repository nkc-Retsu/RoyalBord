using Hand;
using Turn;
using Bridge;
using Piece;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inputer
{
    public class SelectField : MonoBehaviour
    {
        // �t�B�[���h�����擾���鏈��

        [SerializeField] private GameObject knightSpriteObj;
        [SerializeField] private GameObject sheilderSpriteObj;
        [SerializeField] private GameObject archerSpriteObj;
        [SerializeField] private GameObject wallSpriteObj;

        private GameObject cursurObj;


        // �I�u�W�F�N�g�擾�p�ϐ�
        private GameObject clickedObj;
        public GameObject ClickObj
        {
            get
            {
                return clickedObj;
            }
            set
            {
                clickedObj = value;
            }
        }


        // �N���X�ϐ�
        private SendData      sendData;
        private HoldObj       holdObj;
        private GameObject    pieceChild;
        private HandPieceCore handPieceCore;
        private GameObject    MousehandPiece;


        // �I���\�t���O
        private bool selecrFlg = false;


        // Start is called before the first frame update
        void Start()
        {
            // �R���|�[�l���g�擾
            sendData = GetComponent<SendData>();
            holdObj = GetComponent<HoldObj>();
        }

        // Update is called once per frame
        void Update()
        {
            // ���͎�t
            if (!TurnManager.inputFlg) return;

            // ���\�b�h�Ăяo��
            InputClick();
        }



        // �N���b�N����
        private void InputClick()
        {
            // �I���\�t���O��true�̎� (2���)
            if (selecrFlg && holdObj.ClickObj.gameObject.tag == "HandPiece" || selecrFlg && holdObj.ClickObj.gameObject.tag == "PlayerPiece")
            {
                if (ClickLeft())
                {
                    Debug.Log("2���");


                    // �L�����I�� or �t�B�[���h�I��
                    SelectObj();

                    HandPieceDestroy();

                    // 1��ڂ̑I���������̃R�}�̏ꍇ
                    if (holdObj.ClickObj.gameObject.tag == "PlayerPiece")
                    {
                        // �R�}�̖����\��
                        pieceChild.gameObject.SetActive(false);
                    }

                    // �����擾���Ă��Ȃ����͑������^�[��
                    if (clickedObj == null)
                    {
                        return;
                    }
                    // �������I�������ꍇ�͑I������
                    else if (clickedObj == holdObj.ClickObj)
                    {
                        if (clickedObj.gameObject.tag == "HandPiece") return;

                        // ���̕\��������
                        pieceChild.gameObject.SetActive(false);

                        // �擾�����I�u�W�F�N�g�̒��g����ɂ���
                        clickedObj = null;
                        holdObj.ClickObj = null;

                        // 1��ڂ̑I���ɖ߂�
                        selecrFlg = false;
                    }
              

                    // �t���O��ύX
                    selecrFlg = false;

                    // ���𑗂�
                    sendData.Send(holdObj.ClickObj, ClickObj);

                }
            }
            // �I���\�t���O��false�̎� (1���)
            else
            {
                if (ClickLeft())
                {

                    Debug.Log("1���");

                    // �L�����I��
                    holdObj.SelectObj();

                    HandPieceGenerator();

                    // �����擾���Ă��Ȃ��� + Field��I�������瑁�����^�[��
                    if (holdObj.ClickObj == null || holdObj.ClickObj.gameObject.tag == "Field") return;
                    else if (holdObj.ClickObj.gameObject.tag == "PlayerPiece")
                    {
                        // ���̃I�u�W�F�N�g���擾
                        pieceChild = holdObj.ClickObj.transform.GetChild(0).gameObject;

                        // ���̕\��
                        pieceChild.gameObject.SetActive(true);
                    }

                    // �t���O��ύX
                    selecrFlg = true;
                }
            }

        }


        // ��D�����N���b�N�������ɏ����擾���鏈��
        public void SelectObj()
        {
            // �N���b�N�����I�u�W�F�N�g���擾����ϐ�
            clickedObj = null;

            // �N���b�N�ŃI�u�W�F�N�g���擾
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            // �I�u�W�F�N�g���擾������
            if (hit2d)
            {
                // �N���b�N�����I�u�W�F�N�g�̃N���X���擾
                clickedObj = hit2d.transform.gameObject;

                // �����擾���Ă��Ȃ����͑������^�[��
                if (clickedObj == null) return;

            }

        }


        // ���N���b�N����
        private bool ClickLeft()
        {
            return Input.GetMouseButtonDown(0);
        }



        // ��D���N���b�N�������ɃJ�[�\���ɒǏ]����I�u�W�F�N�g�𐶐����鏈��
        private void HandPieceGenerator()
        {
            switch (holdObj.ClickObj.name)
            {
                case "HandPiece_Knight":
                    cursurObj = Instantiate(knightSpriteObj);
                    break;
                case "HandPiece_Shielder":
                    cursurObj = Instantiate(sheilderSpriteObj);
                    break;
                case "HandPiece_Archer":
                    cursurObj = Instantiate(archerSpriteObj);
                    break;
                case "Hand_WallPiece":
                    cursurObj = Instantiate(wallSpriteObj);
                    break;
                case "Hand_WallPiece (1)":
                    cursurObj = Instantiate(wallSpriteObj);
                    break;
                case "Hand_WallPiece (2)":
                    cursurObj = Instantiate(wallSpriteObj);
                    break;

            }
        }


        private void HandPieceDestroy()
        {
            switch (holdObj.ClickObj.name)
            {
                case "HandPiece_Knight":
                    cursurObj.gameObject.SetActive(false);
                    break;
                case "HandPiece_Shielder":
                    cursurObj.gameObject.SetActive(false);
                    break;
                case "HandPiece_Archer":
                    cursurObj.gameObject.SetActive(false);
                    break;
                case "Hand_WallPiece":
                    cursurObj.gameObject.SetActive(false);
                    break;
                case "Hand_WallPiece (1)":
                    cursurObj.gameObject.SetActive(false);
                    break;
                case "Hand_WallPiece (2)":
                    cursurObj.gameObject.SetActive(false);
                    break;

            }
        }

    }



}






