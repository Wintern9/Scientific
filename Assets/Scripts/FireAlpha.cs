using UnityEngine;

public class ChangeTransparency : MonoBehaviour
{
    public GameObject[] targetObject;
    public float maxDistance = 10f;
    public float minDistance = 2f;

    public GameObject character;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        targetObject = GameObject.FindGameObjectsWithTag("Fire");
        character = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {

        if (spriteRenderer == null || targetObject == null)
        {
            return;
        }
        Vector3 pos = Vector3.zero;

        for (int i = 0; i < targetObject.Length; i++)
        {
            if (Vector2.Distance(character.transform.position, pos) > Vector2.Distance(character.transform.position,targetObject[i].transform.position))
            {
                pos = targetObject[i].transform.position;
            }
        }

        if (pos != Vector3.zero)
        {
            float distance = Vector2.Distance(character.transform.position, pos);

            float transparency = Mathf.Lerp(1f, 0f, Mathf.InverseLerp(minDistance, maxDistance, distance));

            Color currentColor = spriteRenderer.color;
            spriteRenderer.color = new Color(currentColor.r, currentColor.g, currentColor.b, transparency);
        }
    }
}
