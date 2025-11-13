class Program
{
  public static void Main()
  {
    // Edges of the map
    var edges = new List<Tuple<string, string, double>>()
    {
      new("UA", "TH", 1.05),
      new("TH", "CC", 2.85),
      new("TH", "GP", 2.85),
      new("GP", "CC", 2.25),
      new("GP", "SC", 1.15),
      new("SC", "CC", 2.60),
      new("CC", "LI", 2.15),
      new("CC", "RH", 5.40),
      new("RH", "UM", 2.85),
      new("CC", "UM", 3.95),
      new("CC", "GI", 2.45),
      new("GI", "PA", 2.35),
      new("PA", "UM", 2.15),
    };

    // Creation of graph based on edges
    var graph = new Graph(edges);

    // Printing the result of the assignment of colors
    Coloring.PrintColors(graph);
    // Printing the result of modified dijkstra to skip same color nodes
    Dijkstra.EZPrint(graph, "UA");
  }
}
