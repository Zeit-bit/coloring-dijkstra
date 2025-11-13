class Graph
{
  public Dictionary<string, Node> Nodes { get; private init; } = [];
  public int Vertices
  {
    get { return Nodes.Count; }
  }
  public List<Edge> Edges { get; private init; } = [];

  public Graph(List<Tuple<string, string, double>> edges)
  {
    foreach (var e in edges)
    {
      Node nodeSrc = ValidateNode(e.Item1);
      Node nodeDst = ValidateNode(e.Item2);
      var edge = new Edge(nodeSrc, nodeDst, e.Item3);
      Edges.Add(edge);
    }
  }

  private Node ValidateNode(string nodeName)
  {
    if (!Nodes.ContainsKey(nodeName))
    {
      Nodes.Add(nodeName, new Node(nodeName, Vertices));
    }
    return Nodes[nodeName];
  }

  public List<Tuple<Node, double>>[] GetAdjMatrix()
  {
    var adjMatrix = new List<Tuple<Node, double>>[Vertices];
    for (int i = 0; i < adjMatrix.Length; i++)
      adjMatrix[i] = new List<Tuple<Node, double>>();
    foreach (var edge in Edges)
    {
      adjMatrix[edge.Src.Id].Add(new(edge.Dst, edge.Weight));
      adjMatrix[edge.Dst.Id].Add(new(edge.Src, edge.Weight));
    }
    return adjMatrix;
  }
}
