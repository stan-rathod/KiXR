using UnityEngine;
using UnityEngine.UI;
using PolyAndCode.UI;
using TMPro;

public class ProductCell : MonoBehaviour, ICell
{
    //UI
    public TMP_Text dispName;
    public TMP_Text price;
    public TMP_Text main;
    public TMP_Text sub;

    //Model
    private ProductInfo _productInfo;
    private int _cellIndex;

    public void ConfigureCell(ProductInfo productInfo,int cellIndex)
    {
        _cellIndex = cellIndex;
        _productInfo = productInfo;
        
        dispName.text = $"Name: {_productInfo.Name}";
        price.text = $"Price: {_productInfo.Price}";
        main.text = $"{_productInfo.Catergory}";
        sub.text = $"{_productInfo.Subcatergory}";
    }
}

