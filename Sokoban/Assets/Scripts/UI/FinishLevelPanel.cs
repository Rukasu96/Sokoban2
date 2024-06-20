using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinishLevelPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI completeLeveLText;
    [SerializeField] private TextMeshProUGUI movesCountText;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Transform[] stars;
    [SerializeField] private Transform[] buttons;
    [SerializeField] private GameManager gameManager;

    public void PlayFinishPanel()
    {
        var sequence = DOTween.Sequence();

        GetComponent<Image>().DOFade(1, 1f).OnComplete(() =>
        {
            completeLeveLText.transform.DOMoveY(transform.position.y + 250f, 1f);
            completeLeveLText.DOFade(1, 0.5f).OnComplete(() =>
            {
                movesCountText.text = gameManager._Player.MovesCount.ToString();
                movesCountText.DOFade(1, 0.2f);
                movesCountText.transform.DOScale(2, 0.2f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
                {

                    foreach (Transform star in stars)
                    {
                        star.GetComponent<Image>().DOFade(1f, 1f);
                    }

                    for (int i = 0; i < gameManager.ReturnRating(); i++)
                    {
                        sequence.Append(stars[i].GetChild(0).GetComponent<Image>().DOFade(1f, 0.2f));
                        sequence.Append(stars[i].DOScale(1.4f, 0.2f).SetLoops(2, LoopType.Yoyo));
                    }

                    foreach (Transform button in buttons)
                    {
                        sequence.Append(button.GetComponent<Image>().DOFade(1f, 0.01f));
                        sequence.Append(button.GetChild(0).GetComponent<TextMeshProUGUI>().DOFade(1f, 0.02f));
                        sequence.Append(button.DOScale(1.2f, 0.3f).SetLoops(2, LoopType.Yoyo));
                    }
                });
            });

        }
        );
        
    }

}
