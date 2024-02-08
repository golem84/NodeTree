namespace NodeTreeLib;

public interface INodeTree<T>
{
    public INodeTree<T>? Parent { get; }
    public ICollection<INodeTree<T>> NodeList { get; }

    public void Print();
    public void PrintTree();
    
    public int GetNodeLayer();
    public void SetNodeLayer(int layer);
    
    public INodeTree<T> GetParent();
    public void SetParent(INodeTree<T> node);

    public ICollection<INodeTree<T>> GetChildrenList();

    public void AddNode(INodeTree<T> node);
    public int FindNode(INodeTree<T> node); // не реализован
}