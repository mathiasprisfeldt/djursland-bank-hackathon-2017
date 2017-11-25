using System;
using UnityEngine;
using UnityEngine.UI;

namespace QuestBoard
{
    /// <summary>
    /// Purpose:
    /// Creator:
    /// </summary>
    public class AvatarButton : MonoBehaviour
    {
        private enum OverlayState {None, Confirm, Waiting, Done }

        [SerializeField] private Sprite _avatarSprite;
        [SerializeField] private Sprite _confirmSprite;
        [SerializeField] private Sprite _waitingSprite;
        [SerializeField] private Image _overlayImage;
        [SerializeField] private Image _ownImage;

        private OverlayState _state;

        public void OnClick()
        {
            if(_state != OverlayState.Done)
                _state++;

            switch (_state)
            {
                case OverlayState.None:
                    break;
                case OverlayState.Confirm:
                    _ownImage.sprite = _avatarSprite;
                    _overlayImage.sprite = _confirmSprite;
                    break;
                case OverlayState.Waiting:
                    _overlayImage.sprite = _waitingSprite;
                    break;
            }
        }
    }
}