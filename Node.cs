class Node
{
  public int Id { get; private init; }
  public string Name { get; private init; }

  public Node(string name, int id)
  {
    Name = name;
    Id = id;
  }
}
