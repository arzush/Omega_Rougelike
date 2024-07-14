using UnityEngine;

public class AreaClearChecker : MonoBehaviour
{
    public string enemyTag = "Enemy"; // ��� ������
    public Vector3 areaCenter; // ����� ������� ��������
    public Vector3 areaSize; // ������ ������� ��������

    private Renderer objectRenderer;
    private BoxCollider2D boxCollider;

    void Start()
    {
        // �������� ��������� Renderer ��� ���������� ���������� �������
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer == null)
        {
            Debug.LogWarning("Renderer not found on the object.");
        }

        // �������� ��������� BoxCollider2D ��� ���������� ��� �����������
        boxCollider = GetComponent<BoxCollider2D>();
        if (boxCollider == null)
        {
            Debug.LogWarning("BoxCollider2D not found on the object.");
        }
    }

    void Update()
    {
        // ����� ��� ������� � ����� "Enemy" � �����
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        // ����, �����������, ���� �� � ������� ������� � ����� "Enemy"
        bool enemiesInArea = false;

        // ��������� ������� �����, ��������� �� �� � �������
        foreach (GameObject enemy in enemies)
        {
            if (IsInArea(enemy.transform.position))
            {
                enemiesInArea = true;
                break;
            }
        }

        // ���������� ��������� ������� � ���������� ���������� � ����������� �� ������� ������ � �������
        if (objectRenderer != null)
        {
            objectRenderer.enabled = enemiesInArea;
        }

        if (boxCollider != null)
        {
            boxCollider.enabled = enemiesInArea;
        }
    }

    // ����� ��� ��������, ��������� �� ������� � �������� �������
    bool IsInArea(Vector3 position)
    {
        return position.x > areaCenter.x - areaSize.x / 2 &&
               position.x < areaCenter.x + areaSize.x / 2 &&
               position.y > areaCenter.y - areaSize.y / 2 &&
               position.y < areaCenter.y + areaSize.y / 2 &&
               position.z > areaCenter.z - areaSize.z / 2 &&
               position.z < areaCenter.z + areaSize.z / 2;
    }

    // ��� �������� ������������ ������� �������� � ���������
    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireCube(areaCenter, areaSize);
    //}
}