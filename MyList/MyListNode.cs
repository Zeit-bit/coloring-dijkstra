namespace MyList;

public class MyListNode<T>
{
  public T Value { get; set; }
  public MyListNode<T>? NextNode { get; set; }

  public MyListNode(T value)
  {
    Value = value;
    NextNode = null;
  }
}
