using UnityEngine;
using DG.Tweening;

public static class Tweening
{
    public static void TweenIn(GameObject obj_tween, float timeDuration)
    {
        obj_tween.SetActive(true);
        AttachCG(obj_tween);

        obj_tween.GetComponent<CanvasGroup>().alpha = 0;
        (obj_tween.transform as RectTransform).localScale = new Vector3(0.5f, 0.5f, 0.5f);
        //(obj_tween.transform as RectTransform).localPosition = new Vector3(0, -1000, 0);
        (obj_tween.transform as RectTransform).DOScale(new Vector3(1, 1, 1), timeDuration).SetEase(Ease.Linear);
        //(obj_tween.transform as RectTransform).DOAnchorPos(new Vector2(0, 0), 0.3f, false).SetEase(Ease.InQuint);
        obj_tween.GetComponent<CanvasGroup>().DOFade(1, timeDuration);
    }

    public static void TweenOut(GameObject obj_tween, float timeDuration)
    {
        AttachCG(obj_tween);

        obj_tween.GetComponent<CanvasGroup>().alpha = 1;
        (obj_tween.transform as RectTransform).localScale = new Vector3(1f, 1f, 1f);
        //(obj_tween.transform as RectTransform).localPosition = new Vector3(0, 0, 0);
        (obj_tween.transform as RectTransform).DOScale(new Vector3(0.5f, 0.5f, 0.5f), timeDuration);
        //(obj_tween.transform as RectTransform).DOAnchorPos(new Vector2(0, -1000), 0.2f, false).SetEase(Ease.OutFlash);
        obj_tween.GetComponent<CanvasGroup>().DOFade(0, timeDuration);
        DOVirtual.DelayedCall(timeDuration, () =>
        {
            obj_tween.SetActive(false);
        });
    }

    public static void TweenMove(GameObject obj_tween, float timeduration, Vector2 endPosition, Vector2 startPosition)
    {
        obj_tween.SetActive(true);

        AttachCG(obj_tween);

        obj_tween.GetComponent<CanvasGroup>().alpha = 0;
        //(obj_tween.transform as RectTransform).localScale = new Vector3(0.5f, 0.5f, 0.5f);
        (obj_tween.transform as RectTransform).localPosition = startPosition;
        //(obj_tween.transform as RectTransform).DOScale(new Vector3(1, 1, 1), timeduration).SetEase(Ease.Linear);
        (obj_tween.transform as RectTransform).DOAnchorPos(endPosition, timeduration, false).SetEase(Ease.InQuint);
        obj_tween.GetComponent<CanvasGroup>().DOFade(1, timeduration);
    }

    public static void TweenPunch(GameObject obj_tween, float timeduration, Vector3 punch)
    {
        obj_tween.transform.DOPunchPosition(punch, timeduration);
    }

    public static void AlphaFadeIn(GameObject obj_tween, float timeduration)
    {
        obj_tween.SetActive(true);

        AttachCG(obj_tween);

        obj_tween.GetComponent<CanvasGroup>().alpha = 0;
        obj_tween.GetComponent<CanvasGroup>().DOFade(1, timeduration);
    }

    public static void AlphaFadeOut(GameObject obj_tween, float timeduration)
    {
        AttachCG(obj_tween);

        obj_tween.GetComponent<CanvasGroup>().alpha = 1;
        obj_tween.GetComponent<CanvasGroup>().DOFade(0, timeduration);
        DOVirtual.DelayedCall(timeduration, () =>
        {
            obj_tween.SetActive(false);
        });
    }

    public static void AttachCG(GameObject obj_tween)
    {
        if (!obj_tween.GetComponent<CanvasGroup>())
            obj_tween.AddComponent<CanvasGroup>();
    }
}
