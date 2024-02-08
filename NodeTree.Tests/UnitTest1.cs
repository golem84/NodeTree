using NodeTreeLib;

namespace NodeTreeView.Tests;

public class UnitTest1
{
    [Fact]
    public void NodeClassTest()
    {
        var obj1 = new SampleClass("Obj1");
        var obj2 = new SampleClass("Obj2");
        var node1 = new NodeTree<SampleClass>(obj1);
        var node2 = new NodeTree<SampleClass>(obj2);
        node1.AddNode(node2);
        // �������� �������� Caption
        Assert.Equal("Obj1", node1.ToString());
        // �������� ��������� ���� ����� ��� ��������� ������� Caption ��� �����
        Assert.False(node1.Equals(node2));
        Assert.True(node1.Equals(new NodeTree<SampleClass>(obj1)));
        Assert.False(node1.Equals(new NodeTree<SampleClass>(new SampleClass("New Obj"))));
    }

    [Fact]
    public void INodeInterfaceTest_GetSetParent()
    {
        var obj1 = new SampleClass("Obj1");
        var obj2 = new SampleClass("Obj2");
        var obj3 = new SampleClass("Obj3");
        var obj4 = new SampleClass("Obj4");
        var node1 = new NodeTree<SampleClass>(obj1);
        var node2 = new NodeTree<SampleClass>(obj2);
        Assert.Same(node1.GetParent(), null);
        Assert.Same(node2.GetParent(), null);
        Assert.NotSame(node2.GetParent(), node1);
        // ��������� node2 � node1
        node1.AddNode(node2);
        // �������� �������� ��� node2
        Assert.Same(node2.GetParent(), node1);
        // �������� ���������� ����� ��� node1
        Assert.Equal(1, node1.GetChildrenList().ToList().Count);
        // �������� ������ ��� node1
        Assert.Equal(0, node1.GetNodeLayer());
        // �������� ������ ��� node2
        Assert.Equal(1, node2.GetNodeLayer());        
        // ����������� ����������� ��������
        var node3 = new NodeTree<SampleClass>(obj3);
        // ������ node3 � node2
        node2.AddNode(node3);
        // ������ new node(obj4) � node1
        node1.AddNode(new NodeTree<SampleClass>(obj4));
        Assert.Equal(2, node3.GetNodeLayer());


    }


}