using System.Collections.Generic;
using UnityEngine;
using PolyAndCode.UI;
using System.Diagnostics.Tracing;
using System.Linq;

public struct ProductInfo
{
    public string Name;
    public string Price;
    public string Catergory;
    public string Subcatergory;
}

public class FilterExample : MonoBehaviour, IRecyclableScrollRectDataSource
{
    [SerializeField] RecyclableScrollRect _recyclableScrollRect;
    [SerializeField] int _dataLength;
    private List<ProductInfo> _productList = new List<ProductInfo>();
    private List<ProductInfo> filterList = new List<ProductInfo>();
    [SerializeField] string[] main = { "Watch", "Cloth", "Jewelry" };
    [SerializeField] string[] sub = { "Male", "Female", "Kids" };

    List<string> filterOptions = new List<string>();

    private void Awake()
    {
        // if (Screen.orientation == ScreenOrientation.LandscapeLeft || 
        // Screen.orientation == ScreenOrientation.LandscapeRight)
        //     _recyclableScrollRect.Segments = 6;
        // else
        //     _recyclableScrollRect.Segments = 3;


        InitData();
        _recyclableScrollRect.DataSource = this;
    }

    //Initialising _contactList with dummy data 
    private void InitData()
    {
        if (_productList != null) _productList.Clear();

        for (int i = 0; i < _dataLength; i++)
        {
            ProductInfo obj = new ProductInfo();
            obj.Name = i + "_Name";
            obj.Price = $"{Random.Range(100, 1500)}";
            obj.Catergory = main[Random.Range(0, main.Length)];
            obj.Subcatergory = sub[Random.Range(0, sub.Length)];
            _productList.Add(obj);
        }

        filterList = _productList;
    }

    public void FilterOption(int mainIndex, int subIndex, bool add)
    {
        var opt = $"{main[mainIndex]}_{sub[subIndex]}";
        if (filterOptions.Contains(opt) && !add)
        {
            filterOptions.Remove(opt);
        }
        else
        {
            if (add)
            {
                filterOptions.Add(opt);
            }
        }
    }

    public void ApplyFilter()
    {
        // List<string> filterOptions = new List<string>();
        filterList = _productList.Where(p => filterOptions.Contains($"{p.Catergory}_{p.Subcatergory}")).ToList();
        Debug.Log($"TODO: filtered items count {filterList.Count()}");
        _recyclableScrollRect.ReloadData();
    }

    public void ResetFilter()
    {
        filterList = _productList;
        Debug.Log($"TODO: filtered items count {filterList.Count()}");
        _recyclableScrollRect.ReloadData();
    }

    #region DATA-SOURCE
    public int GetItemCount()
    {
        return filterList.Count;
    }

    public void SetCell(ICell cell, int index)
    {
        //Casting to the implemented Cell
        var item = cell as ProductCell;
        item.ConfigureCell(filterList[index], index);
    }
    #endregion
}
