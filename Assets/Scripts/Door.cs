using UnityEngine;

public class AreaClearChecker : MonoBehaviour
{
    public string enemyTag = "Enemy"; // Тег врагов
    public Vector3 areaCenter; // Центр области проверки
    public Vector3 areaSize; // Размер области проверки

    private Renderer objectRenderer;
    private BoxCollider2D boxCollider;

    void Start()
    {
        // Получить компонент Renderer для управления видимостью объекта
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer == null)
        {
            Debug.LogWarning("Renderer not found on the object.");
        }

        // Получить компонент BoxCollider2D для управления его активностью
        boxCollider = GetComponent<BoxCollider2D>();
        if (boxCollider == null)
        {
            Debug.LogWarning("BoxCollider2D not found on the object.");
        }
    }

    void Update()
    {
        // Найти все объекты с тегом "Enemy" в сцене
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        // Флаг, указывающий, есть ли в области объекты с тегом "Enemy"
        bool enemiesInArea = false;

        // Проверить каждого врага, находится ли он в области
        foreach (GameObject enemy in enemies)
        {
            if (IsInArea(enemy.transform.position))
            {
                enemiesInArea = true;
                break;
            }
        }

        // Установить видимость объекта и активность коллайдера в зависимости от наличия врагов в области
        if (objectRenderer != null)
        {
            objectRenderer.enabled = enemiesInArea;
        }

        if (boxCollider != null)
        {
            boxCollider.enabled = enemiesInArea;
        }
    }

    // Метод для проверки, находится ли позиция в заданной области
    bool IsInArea(Vector3 position)
    {
        return position.x > areaCenter.x - areaSize.x / 2 &&
               position.x < areaCenter.x + areaSize.x / 2 &&
               position.y > areaCenter.y - areaSize.y / 2 &&
               position.y < areaCenter.y + areaSize.y / 2 &&
               position.z > areaCenter.z - areaSize.z / 2 &&
               position.z < areaCenter.z + areaSize.z / 2;
    }

    // Для удобства визуализации области проверки в редакторе
    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireCube(areaCenter, areaSize);
    //}
}