namespace NodeTreeLib;

public interface ITreeNode<T>
{
    public ITreeNode<T>? Parent { get; }
    public ICollection<ITreeNode<T>> NodeList { get; }

    public void Print();
    public void PrintTree();
    
    public int GetNodeLayer();
    public void SetNodeLayer(int layer);
    
    public ITreeNode<T> GetParent();
    public void SetParent(ITreeNode<T> node);

    public ICollection<ITreeNode<T>> GetChildrenList();

    public void AddNode(ITreeNode<T> node);
    public int FindNode(ITreeNode<T> node); // не реализован
}