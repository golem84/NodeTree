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
        // проверка свойства Caption
        Assert.Equal("Obj1", node1.ToString());
        // проверка равенства двух узлов как равенства свойств Caption для узлов
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
        // добавляем node2 к node1
        node1.AddNode(node2);
        // проверка родителя для node2
        Assert.Same(node2.GetParent(), node1);
        // проверка количества детей для node1
        Assert.Equal(1, node1.GetChildrenList().ToList().Count);
        // проверка уровня для node1
        Assert.Equal(0, node1.GetNodeLayer());
        // проверка уровня для node2
        Assert.Equal(1, node2.GetNodeLayer());        
        // увеличиваем вложенность структур
        var node3 = new NodeTree<SampleClass>(obj3);
        // кладем node3 в node2
        node2.AddNode(node3);
        // кладем new node(obj4) в node1
        node1.AddNode(new NodeTree<SampleClass>(obj4));
        Assert.Equal(2, node3.GetNodeLayer());


    }


}