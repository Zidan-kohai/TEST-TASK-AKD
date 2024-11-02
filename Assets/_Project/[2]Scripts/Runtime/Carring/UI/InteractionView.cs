using Runtime.Carring;
using TMPro;
using UnityEngine;
using Zenject;

public class InteractionView : MonoBehaviour
{
    [SerializeField] private RectTransform _handlerRectTransform;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private TextMeshProUGUI _buttonText;

    private IInteractionValidator _validator;

    [Inject]
    public void Constructor(IInteractionValidator validator)
    {
        _validator = validator;
    }

    private void Update()
    {
        if(_validator.CheckContainer())
        {
            _handlerRectTransform.gameObject.SetActive(true);
            _descriptionText.text = "Поставить";
        }
        else if(_validator.CheckPickable())
        {
            _handlerRectTransform.gameObject.SetActive(true);
            _descriptionText.text = "Поднять";
        }
        else
        {
            _handlerRectTransform.gameObject.SetActive(false);
        }
    }
}
