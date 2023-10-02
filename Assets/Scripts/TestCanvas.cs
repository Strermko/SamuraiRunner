using TMPro;
using UnityEngine;

public class TestCanvas : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _textMessage;
   
   public void SetMessage(string message)
   {
      _textMessage.text = message;
   }
}
