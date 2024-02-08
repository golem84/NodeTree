using System.Collections.Generic;
namespace NodeTreeLib;

public class TreeNode<T>: ITreeNode<T>
{
    //private static int _nodecount = 0;

    private T _node_object;
    private int _layer;
    private ITreeNode<T>? _parent;
    private ICollection<ITreeNode<T>> _nodelist;
    // Implementation of ITreeNode
    public ITreeNode<T>? Parent { get => _parent; }
    public ICollection<ITreeNode<T>> NodeList { get => _nodelist; }

    public string Caption {get; set;}
    public override string ToString() => Caption;

    public TreeNode() { }

    public TreeNode(T obj)
    {
        _node_object = obj;
        Caption = obj.ToString();
        _nodelist = new List<ITreeNode<T>>();
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
            /// TODO: реализовать корректный вывод с отступами в консоль
        }
    }
    #endregion

    #region [..Override object.Equals]

    // override object.Equals
    public override bool Equals(object obj)
    {        
        if (obj == null || GetType() != obj.GetType()) return false;
        
        if (obj is TreeNode<T> node) return Caption == node.Caption;
        return false;
    }
    
    // override object.GetHashCode
    public override int GetHashCode() => this.Caption.GetHashCode();
    #endregion

    #region [..Interface ITreeNode<T> implementation]
    public int GetNodeLayer() => _layer;

    public void SetNodeLayer(int layer)
    {
        this._layer = layer;
        foreach(var n in _nodelist) n.SetNodeLayer(layer+1);
    }

    public ITreeNode<T> GetParent() => _parent;

    public void SetParent(ITreeNode<T> node)
    {
        this._parent = node;
        this._layer = node.GetNodeLayer() + 1;
    }

    public ICollection<ITreeNode<T>> GetChildrenList() => _nodelist;

    public void AddNode(ITreeNode<T> node)
    {
        this._nodelist.Add(node);
       node.SetParent(this);
    }
    
    public int FindNode(ITreeNode<T> node)
    {
        throw new System.NotImplementedException();      
    }
    

    #endregion
}
