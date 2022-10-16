using UnityEngine;

class BobTheBuilder : MonoBehaviour
{
    [SerializeField] protected GameObject door;
    [SerializeField] protected Sprite altSprite;
    protected SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!door.activeSelf)
        {
            spriteRenderer.sprite = altSprite;
        }
    }
}
