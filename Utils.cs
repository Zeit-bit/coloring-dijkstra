static class Utils
{
  // Utility to print results of different algorithms that return arrays of weights and routes (e.g. Dijkstra)
  public static void GraphPrint(string title, string description, double[] weights, string[] routes)
  {
    int tableWidth = routes[routes.Length - 1].Length;
    Console.WriteLine($"[{title}]");
    Console.WriteLine($"{description}");
    for (int i = 0; i < weights.Length; i++)
    {
      int spaceNeeded = tableWidth - routes[i].Length;
      Console.Write(routes[i]);
      for (int j = 0; j < spaceNeeded; j++)
      {
        Console.Write(" ");
      }
      Console.Write($" | weight: {weights[i]}");
      Console.WriteLine();
    }
  }
}
