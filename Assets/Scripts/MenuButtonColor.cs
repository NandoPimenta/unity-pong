using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonColor : MonoBehaviour
{
    private Button btn;
    private Image btnImage;

    public Color color;
    [Range(1f,2f)]
    public int player=1;

    // Start is called before the first frame update
    void Start()
    {
        btnImage = GetComponent<Image>();
        btn = GetComponent<Button>();

        btn.onClick.AddListener(() => changePlayerColor());

       btnImage.color = color;
    }

    void changePlayerColor()
  {
      Menu.Instance.changeColor(color,player);
      btnImage.color = color;
  }

   void Destroy()
  {
       btn.onClick.RemoveListener(() => changePlayerColor());
  }
}
