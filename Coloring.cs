static class Coloring
{
  public static int[] GetColored(Graph graph)
  {
    int vertexCount = graph.Vertices;
    int[] colors = new int[vertexCount];
    var adjMatrix = graph.GetAdjMatrix();
    Solve(0, vertexCount, colors, 1, adjMatrix);
    return colors;
  }

  private static void Solve(
    int currentVertex,
    int vertexCount,
    int[] colors,
    int latestColor,
    List<Tuple<Node, double>>[] adjMatrix
  )
  {
    if (currentVertex == vertexCount)
      return;

    for (int color = 1; color <= latestColor; color++)
    {
      bool colorAlreadyPresent = false;
      foreach (var tuple in adjMatrix[currentVertex])
      {
        var nodeNeighbor = tuple.Item1;
        if (colors[nodeNeighbor.Id] == color && color == latestColor)
          latestColor++;
        if (colors[nodeNeighbor.Id] != color)
          continue;

        colorAlreadyPresent = true;
        break;
      }

      if (colorAlreadyPresent)
        continue;

      colors[currentVertex] = color;
      break;
    }
    Solve(currentVertex + 1, vertexCount, colors, latestColor, adjMatrix);
  }

  public static void PrintColors(Graph graph)
  {
    Console.WriteLine("[Coloring]");
    Console.WriteLine("Colors assigned per node:");
    var colorIndex = GetColored(graph);
    for (int i = 0; i < colorIndex.Length; i++)
    {
      var node = graph.Nodes.First(node => node.Value.Id == i).Value;
      Console.WriteLine($"{node.Name} -> {colorIndex[i]}");
    }
    Console.WriteLine();
  }
}
