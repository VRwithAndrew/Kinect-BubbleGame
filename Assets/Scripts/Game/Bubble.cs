using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public Sprite mBubbleSprite;
    public Sprite mPopSprite;

    [HideInInspector]
    public BubbleManager mBubbleManager = null;

    private Vector3 mMovementDirection = Vector3.zero;
    private SpriteRenderer mSpriteRenderer = null;
    private Coroutine mCurrentChanger = null;

    private void Awake()
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        mCurrentChanger = StartCoroutine(DirectionChanger());
    }

    private void OnBecameInvisible()
    {
        transform.position = mBubbleManager.GetPlanePosition();
    }

    private void Update()
    {
        // Movement
        transform.position += mMovementDirection * Time.deltaTime * 0.35f;

        // Rotation
        transform.Rotate(Vector3.forward * Time.deltaTime * mMovementDirection.x * 20, Space.Self);
    }

    public IEnumerator Pop()
    {
        mSpriteRenderer.sprite = mPopSprite;

        StopCoroutine(mCurrentChanger);
        mMovementDirection = Vector3.zero;

        yield return new WaitForSeconds(0.5f);

        transform.position = mBubbleManager.GetPlanePosition();

        mSpriteRenderer.sprite = mBubbleSprite;
        mCurrentChanger = StartCoroutine(DirectionChanger());
    }

    private IEnumerator DirectionChanger()
    {
        while (gameObject.activeSelf)
        {
            mMovementDirection = new Vector2(Random.Range(-100, 100) * 0.01f, Random.Range(0, 100) * 0.01f);

            yield return new WaitForSeconds(5.0f);
        }
    }
}
