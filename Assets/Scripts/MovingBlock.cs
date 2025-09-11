using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    [Header("�ړ�����/����/�Ԋu")]
    public float moveX = 0.0f;          //X�ړ�����
    public float moveY = 0.0f;          //Y�ړ�����
    public float times = 0.0f;          //����
    public float wait = 0.0f;           //��~����

    [Header("����Ă��瓮���t���O")]
    public bool isMoveWhenOn = false;   //��������ɓ����t���O

    bool isCanMove = true;       //�����t���O
    Vector3 startPos;                   //�����ʒu
    Vector3 endPos;                     //�ړ��ʒu
    bool isReverse = false;             //���]�t���O
    float movep = 0;                    //�ړ��⊮�l

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;                                 //�����ʒu
        endPos = new Vector2(startPos.x + moveX, startPos.y + moveY);  //�ړ��ʒu
        if (isMoveWhenOn)
        {
            //��������ɓ����̂ōŏ��͓������Ȃ�
            isCanMove = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isCanMove)
        {
            float distance = Vector2.Distance(startPos, endPos);        //�ړ�����
            float ds = distance / times;                                //1�b�̈ړ�����
            float df = ds * Time.deltaTime;                             //�P�t���[���̈ړ�����
            movep += df / distance;                                     //�ړ��⊮�l
            if (isReverse)
            {
                transform.position = Vector2.Lerp(endPos, startPos, movep);  //�t�ړ�
            }
            else
            {
                transform.position = Vector2.Lerp(startPos, endPos, movep);  //���ړ�
            }
            if (movep >= 1.0f)
            {
                movep = 0.0f;                   //�ړ��⊮�l���Z�b�g
                isReverse = !isReverse;         //�ړ����t�]
                isCanMove = false;              //�ړ���~
                if (isMoveWhenOn == false)
                {
                    //��������ɓ����t���OOFF
                    Invoke("Move", wait);       //�ړ��t���O�𗧂Ă�x�����s
                }
            }
        }
    }

    //�ړ��t���O�𗧂Ă�
    public void Move()
    {
        isCanMove = true;
    }

    //�ړ��t���O�����낷
    public void Stop()
    {
        isCanMove = false;
    }

    //�ڐG�J�n
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //�ڐG�����̂��v���C���[�Ȃ�ړ����̎q�ɂ���
            collision.transform.SetParent(transform);
            if (isMoveWhenOn)
            {
                //��������ɓ����t���OON
                isCanMove = true;   //�ړ��t���O�𗧂Ă�
            }
        }
    }
    //�ڐG�I��
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //�ڐG�����̂��v���C���[�Ȃ�ړ����̎q����O��
            collision.transform.SetParent(null);
        }
    }
    //�ړ��͈͕\��
    void OnDrawGizmosSelected()
    {
        Vector2 fromPos;
        if (startPos == Vector3.zero)
        {
            fromPos = transform.position;
        }
        else
        {
            fromPos = startPos;
        }
        //�ړ���
        Gizmos.DrawLine(fromPos, new Vector2(fromPos.x + moveX, fromPos.y + moveY));
        //�X�v���C�g�̃T�C�Y
        Vector2 size = GetComponent<SpriteRenderer>().size;
        //�����ʒu
        Gizmos.DrawWireCube(fromPos, new Vector2(size.x, size.y));
        //�ړ��ʒu
        Vector2 toPos = new Vector3(fromPos.x + moveX, fromPos.y + moveY);
        Gizmos.DrawWireCube(toPos, new Vector2(size.x, size.y));
    }
}
