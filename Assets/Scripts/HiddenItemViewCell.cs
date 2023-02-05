using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class HiddenItemViewCell : MonoBehaviour
    {
        [SerializeField] Image _thumb;

        public void Populate(HiddenItem item)
        {
            _thumb.sprite = item.Sprite;
            _thumb.color = Color.black;
            
            item.OnFound += _ => 
            _thumb.color = Color.white;
        }



    }
}