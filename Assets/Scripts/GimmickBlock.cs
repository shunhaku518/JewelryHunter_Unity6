using UnityEngine;

public class GimmickBlock : MonoBehaviour
{
    [Header("�������m����")]
    public float length = 0.0f;     // �����������m����

    [Header("��������Ńt���O")]
    public bool isDelete = false;   // ������ɍ폜����t���O

    [Header("�����蔻��I�u�W�F�N�g")]
    public GameObject deadObj;      // ���S������

    bool isFell = false;            // �����t���O
    float fadeTime = 0.5f;          // �t�F�[�h�A�E�g����

    // Start is called before the first frame update
    void Start()
    {
        // Rigidbody2D�̕����������~
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        rbody.bodyType = RigidbodyType2D.Static;
        deadObj.SetActive(false);    //���S��������\��
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // �v���C���[��T��
        if (player != null)
        {
            // �v���C���[�Ƃ̋����v��
            float d = Vector2.Distance(transform.position, player.transform.position);
            if (length >= d)
            {
                Rigidbody2D rbody = GetComponent<Rigidbody2D>();
                if (rbody.bodyType == RigidbodyType2D.Static)
                {
                    // Rigidbody2D�̕����������J�n
                    rbody.bodyType = RigidbodyType2D.Dynamic;
                    deadObj.SetActive(true);    //���S�������\��
                }
            }
        }
        if (isFell)
        {
            // ��������
            // �����l��ύX���ăt�F�[�h�A�E�g������
            fadeTime -= Time.deltaTime; // �O�t���[���̍����b�}�C�i�X
            Color col = GetComponent<SpriteRenderer>().color;   // �J���[�����o��
            col.a = fadeTime;   // �����l��ύX
            GetComponent<SpriteRenderer>().color = col; // �J���[���Đݒ肷��
            if (fadeTime <= 0.0f)
            {
                // 0�ȉ�(����)�ɂȂ��������
                Destroy(gameObject);
            }
        }
    }

    // �ڐG�J�n
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDelete)
        {
            isFell = true; // �����t���O�I��
        }
    }
    //�͈͕\��
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, length);
    }


}