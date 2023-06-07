using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform targetTr;
    private Transform camTr;

    [Range(2.0f, 20.0f)]
    public float distance = 10.0f;

    [Range(0.0f, 10.0f)]
    public float height = 2.0f;
    public float damping = 10.0f;
    public float targetOffset = 2.0f;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        camTr = GetComponent<Transform>();

        //Ŀ�� �����ϰ� �ϱ�
        Cursor.visible = false;

        //Ŀ�� ����
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //�̽�������(Esc) ������ ����
        if (Input.GetKey(KeyCode.Escape))
#if UNITY_EDITOR    //�����͸� ������
            //������ �÷��� ����
            UnityEditor.EditorApplication.isPlaying = false;
#else               //�����Ͱ� �ƴϸ� ������
            //���ø����̼� �÷��� ����
            Application.Quit();
#endif
    }

    void LateUpdate()
    {
        Vector3 pos = targetTr.position + (-targetTr.forward * distance) + (Vector3.up * height);
        camTr.position = Vector3.SmoothDamp(camTr.position, pos, ref velocity, damping);

        camTr.LookAt(targetTr.position + (targetTr.up * targetOffset));
    }
}