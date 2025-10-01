using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplayManager : MonoBehaviour
{
    float maxTime = 60 * 60;

    public float MaxTime
    {
        set { maxTime = value * 60; }
    }

    [SerializeField]
    Image timeMeter;

    [SerializeField]
    List<MonoBehaviour> animations = new();

    [Space, SerializeField]
    EnumAnimationTypes index = EnumAnimationTypes.Smooth;

    void Awake()
    {
        if (!PlayerPrefs.HasKey("AnimationIndex")) return;
        index = (EnumAnimationTypes)PlayerPrefs.GetInt("AnimationIndex");
        animations[(int)index].enabled = true;
    }

    void OnEnable()
    {
        transform.parent.GetComponent<TimeHandler>().TimeChanged += UpdateTime;
    }
    void OnDisable()
    {
        transform.parent.GetComponent<TimeHandler>().TimeChanged -= UpdateTime;
    }   
    void UpdateTime(float time)
    {
        ITimeAnimation animation = animations[(int)index] as ITimeAnimation;
        animation.UpdateAnimation(timeMeter, time, maxTime);
    }
    public void ChangeIndex(int indexStep)
    {
        index += indexStep;

        if ((int)index < 0)
        {
            index = (EnumAnimationTypes)(animations.Count - 1);
        }
        else if ((int)index >= animations.Count)
        {
            index = 0;
        }
    }
    public int Index
    {
        get { return (int)index; }
    }
    public void SaveIndex()
    {
        PlayerPrefs.SetInt("AnimationIndex", (int)index);
    }
}