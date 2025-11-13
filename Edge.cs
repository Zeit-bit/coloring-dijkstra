class Edge
{
  public Node Src { get; private init; }
  public Node Dst { get; private init; }

  public double Weight { get; private init; }

  public Edge(Node src, Node dst, double weight)
  {
    Src = src;
    Dst = dst;
    Weight = weight;
  }
}
