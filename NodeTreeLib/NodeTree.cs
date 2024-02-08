using System.Collections.Generic;
namespace NodeTreeLib;

public class NodeTree<T>: INodeTree<T>
{
    //private static int _nodecount = 0;

    private T _node_object;
    private int _layer;
    private INodeTree<T>? _parent;
    private ICollection<INodeTree<T>> _nodelist;
    // Implementation of INodeTree
    public INodeTree<T>? Parent { get => _parent; }
    public ICollection<INodeTree<T>> NodeList { get => _nodelist; }

    public string Caption {get; set;}
    public override string ToString() => Caption;

    public NodeTree() { }

    public NodeTree(T obj)
    {
        _node_object = obj;
        Caption = obj.ToString();
        _nodelist = new List<INodeTree<T>>();
        _parent = null;
        _layer = 0;
    }

    #region [..Print to Console]
    public void Print() => Console.WriteLine(this);

    public void PrintTree()
    {
        this.Print();
        var list = this._nodelist.ToList();
        int this_layer = this._layer;
        for (int j = 0; j < list.Count; j++)
        {
            int node_layer = list[j].GetNodeLayer();
            /// TODO: Вынести печать в консоль в отдельный класс, реализовать вывод с отступами
        }
    }
    #endregion

    #region [..Override object.Equals]

    // override object.Equals
    public override bool Equals(object obj)
    {        
        if (obj == null || GetType() != obj.GetType()) return false;
        
        if (obj is NodeTree<T> node) return Caption == node.Caption;
        return false;
    }
    
    // override object.GetHashCode
    public override int GetHashCode() => this.Caption.GetHashCode();
    #endregion

    #region [..Interface INodeTree<T> implementation]
    public int GetNodeLayer() => _layer;

    public void SetNodeLayer(int layer)
    {
        this._layer = layer;
        foreach(var n in _nodelist) n.SetNodeLayer(layer+1);
    }

    public INodeTree<T> GetParent() => _parent;

    public void SetParent(INodeTree<T> node)
    {
        this._parent = node;
        this._layer = node.GetNodeLayer() + 1;
    }

    public ICollection<INodeTree<T>> GetChildrenList() => _nodelist;

    public void AddNode(INodeTree<T> node)
    {
        this._nodelist.Add(node);
       node.SetParent(this);
    }
    
    // метод не реализован
    public int FindNode(INodeTree<T> node)
    {
        throw new System.NotImplementedException();      
    }
    

    #endregion
}
