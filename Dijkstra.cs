static class Dijkstra
{
  public static Tuple<double[], string[]> Solve(Graph graph, string srcName)
  {
    // Setup
    Node srcNode = graph.Nodes[srcName];
    double[] weights = new double[graph.Vertices];
    string[] routes = new string[graph.Vertices];
    bool[] visited = new bool[graph.Vertices];
    var pq = new PriorityQueue<Tuple<Node, int>, double>();
    var adjMatrix = graph.GetAdjMatrix();
    int[] colors = Coloring.GetColored(graph);

    // Initial values
    for (int i = 0; i < graph.Vertices; i++)
    {
      weights[i] = int.MaxValue;
    }
    weights[srcNode.Id] = 0;
    routes[srcNode.Id] = $"{srcNode.Name} ({colors[srcNode.Id]})";
    pq.Enqueue(new(srcNode, 0), 0);

    // Traversing nodes
    while (pq.Count > 0)
    {
      var (node, colorToBlock) = pq.Dequeue();

      if (visited[node.Id])
        continue;
      visited[node.Id] = true;

      foreach (var neighbor in adjMatrix[node.Id])
      {
        Node nodeNeighbor = neighbor.Item1;
        double weightNeighbor = neighbor.Item2;

        double weight = Math.Round(weights[node.Id] + weightNeighbor, 2);
        string route = $"{routes[node.Id]} -> {nodeNeighbor.Name} ({colors[nodeNeighbor.Id]})";

        if (
          !visited[nodeNeighbor.Id]
          && weight < weights[nodeNeighbor.Id]
          && colors[nodeNeighbor.Id] != colorToBlock
        )
        {
          weights[nodeNeighbor.Id] = weight;
          routes[nodeNeighbor.Id] = route;
          pq.Enqueue(new(nodeNeighbor, colors[node.Id]), weights[nodeNeighbor.Id]);
        }
      }
    }

    return new(weights, routes);
  }

  public static void EZPrint(Graph graph, string srcName)
  {
    var (weights, routes) = Solve(graph, srcName);
    string title = "Dijkstra";
    string description = $"Shortest routes from node {srcName} to each node:";
    Utils.GraphPrint(title, description, weights, routes);
  }
}
