using UnityEngine;

public class bulletcs : MonoBehaviour
{
    private void OnEnable()
    {
        gameObject.transform.position = new Vector3(-8.62f, 0.61f, 0);
    }

    void Update()
    {
        gameObject.transform.Translate(Vector3.right * 5f * Time.deltaTime);
        if (gameObject.transform.position.x >= 7.47f)
        {
            ObjectQueue.Instance.EnqueueObject(gameObject); // ObjectQueue에 다시 추가
            gameObject.SetActive(false);
        }
    }
}