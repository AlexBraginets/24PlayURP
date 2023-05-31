using UnityEngine;

public class TrackPositionTracker : MonoBehaviour
{
    public float leftOffset;
    public int maxIndex;
    public float fullSize = 1f;
    public float reducedSize = .95f;
    private float delta => fullSize - reducedSize;


    public void GetPosition(float pos, out int pos1, out int pos2)
    {
        pos1 = maxIndex;
        pos2 = maxIndex;

        for (int i = 0; i < maxIndex; i++)
        {
            Debug.Log($"i: {i}");
            Range range = GetRange(i);
            if (range.IsInside(pos))
            {
                pos1 = i;
                pos2 = i;
                Debug.Log($"is inside, pos: {pos}");
                break;
            }
            if (range.ToLeft(pos))
            {
                pos1 = i - 1;
                pos2 = i;
                Debug.Log($"to left, pos: {pos}");
                break;
            }
        }


        pos1 = Mathf.Clamp(pos1, 0, maxIndex);
        pos2 = Mathf.Clamp(pos2, 0, maxIndex);
    }

    private Range GetRange(int index)
    {
        return new Range()
        {
            a = -delta + (leftOffset + index),
            b = delta + (leftOffset + index)
        };
    }

    public class Range
    {
        public float a;
        public float b;
        public bool IsInside(float x) => x > a && x < b;
        public bool ToLeft(float x) => x <= a;
    }
}