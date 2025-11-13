using System.Collections;

namespace MyList;

public class MyList<T> : IEnumerable<T>
{
  private MyListNode<T>? firstNode;

  public MyList()
  {
    firstNode = null;
  }

  public void Add(T value)
  {
    MyListNode<T> newNode = new MyListNode<T>(value);

    if (firstNode is null)
    {
      firstNode = newNode;
      return;
    }

    MyListNode<T> current = firstNode;
    while (current.NextNode != null)
    {
      current = current.NextNode;
    }
    current.NextNode = newNode;
  }

  public void Remove(T value)
  {
    if (firstNode is null)
      return;

    if (firstNode.Value!.Equals(value))
    {
      firstNode = firstNode.NextNode;
      return;
    }

    MyListNode<T> currentNode = firstNode;
    while (currentNode.NextNode != null && !currentNode.NextNode.Value!.Equals(value))
    {
      currentNode = currentNode.NextNode;
    }

    if (currentNode.NextNode != null)
      currentNode.NextNode = currentNode.NextNode.NextNode;
  }

  public T? First()
  {
    if (firstNode is null)
      throw new Exception("The list is empty");

    return firstNode.Value;
  }

  public bool IsEmpty()
  {
    return firstNode is null;
  }

  public IEnumerator<T> GetEnumerator()
  {
    MyListNode<T>? currentNode = firstNode;
    while (currentNode != null)
    {
      yield return currentNode.Value;
      currentNode = currentNode.NextNode;
    }
  }

  IEnumerator IEnumerable.GetEnumerator()
  {
    return GetEnumerator();
  }
}
