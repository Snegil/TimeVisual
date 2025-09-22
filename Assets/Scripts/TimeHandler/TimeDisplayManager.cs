using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplayManager : MonoBehaviour
{
    TimeHandler timeHandler;

    float maxTime = 60 * 60;

    Image image;

    [SerializeField]
    List<MonoBehaviour> animations = new();

    [Space, SerializeField]
    EnumAnimationTypes index = EnumAnimationTypes.Smooth;

    void Awake()
    {
        timeHandler = GameObject.FindGameObjectWithTag("TimeHandler").GetComponent<TimeHandler>();
        image = GetComponent<Image>();

        if (!PlayerPrefs.HasKey("AnimationIndex")) return;
        index = (EnumAnimationTypes)PlayerPrefs.GetInt("AnimationIndex");
    }


    void OnEnable()
    {
        timeHandler.TimeChanged += UpdateTime;
    }
    void OnDisable()
    {
        timeHandler.TimeChanged -= UpdateTime;
    }
    public void TimeMaximum(float maxTimeInMinutes)
    {
        maxTime = maxTimeInMinutes * 60;
    }
    void UpdateTime(float time)
    {
        ITimeAnimation animation = animations[(int)index] as ITimeAnimation;
        animation.UpdateAnimation(image, time, maxTime);
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
