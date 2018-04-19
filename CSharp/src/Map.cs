using System;
using System.Text;
using System.Collections;

namespace PathfindingCSharp
{
    public struct Vector2 : IEquatable<Vector2>
    {
        public int x, y;

        public bool Equals(Vector2 other)
        {
            return x == other.x && y == other.y;
        }
    }
    public class Digraph {
        private int V;
        private int E;
        private List<int>[] adj;
        private int[] indegree;
        public Digraph(int V){
            if (V > 0){
                this.V = V;
                this.E = 0;
                indegree = new int[V];
                adj = new List<int>[];
                for (int i = 0 ; i < V ; v++)
                {
                    adj[i] = new List<int>();
                }
            }
        }

        public void AddEdge(int v, int w){
           adj[v].Add(w);
           indegree[w]++;
           E++;
        }

        public List<int> GetAdj(int v){
            return adj[v];
        }
        public int Indegree(int v){
            return indegree[v];
        }
        public int V(){
            return V;
        }
        public int E(){
            return E;
        }
    }
    //Breadth First Direct Path using DiGraph as input
    public class BFS{
        private bool[] marked;
        private int[] edgeTo;
        private int[] distTo;
        private int Infinity = Int32.MaxValue;
        public BFS(Digraph M, int startV){
            marked = new bool[M.V()];
            distTo = new int[M.V()];
            edgeTo = new int[M.V()];
            for (int i = 0; i <M.V(); i++)
                distTo[i] = Infinity;
            Queue<int> q = new Queue<>();
            marked[startV] = true;
            distTo[startV] = 0;
            q.Enqueue(startV);
            while (!q.isEmpty())
            {
                int v = q.Dequeue();
                foreach (int w : M.GetAdj(v)){
                    if (!marked[w]){
                        edgeTo[w] = v;
                        distTo[w] = distTo[v] + 1;
                        marked[w] = true;
                        q.Enqueue(w);
                    }
                }
            }
        }
    }
    public class Map
    {
        public const char emptyChar = '.';
        public const char blockedChar = '#';
        public const char invalidChar = '?';
        public const char pathChar = '@';

        private char[,] mapPositions;
        Vector2 startPosition;
        Vector2 goalPosition;

        public Map(string[] mapData, Vector2 startPos, Vector2 endPos)
        {
            if (startPos.x < 0 || startPos.x >= mapData.Length || startPos.y < 0 || startPos.y >= mapData.Length)
                throw new Exception("Start position is out of bounds, provided coordinates were: " + startPos.x + "," + startPos.y);

            if (endPos.x < 0 || endPos.x >= mapData.Length || endPos.y < 0 || endPos.y >= mapData.Length)
                throw new Exception("End position is out of bounds, provided coordinates were: " + endPos.x + "," + endPos.y);

            if (mapData[startPos.y][startPos.x] == blockedChar)
                throw new Exception("Start position is invalid, provided coordinates were: " + startPos.x + "," + startPos.y);

            if (mapData[endPos.y][endPos.x] == blockedChar)
                throw new Exception("End position is invalid, provided coordinates were: " + endPos.x + "," + endPos.y);

            startPosition = startPos;
            goalPosition = endPos;

            mapPositions = new char[mapData.Length, mapData.Length];

            for (int i = 0; i < mapData.Length; ++i)
            {
                for (int j = 0; j < mapData[i].Length; ++j)
                {
                    int index = (i * mapData.Length) + j;

                    if (startPos.x == j && startPos.y == i)
                        mapPositions[i, j] = pathChar;
                    else if (endPos.x == j && endPos.y == i)
                        mapPositions[i, j] = pathChar;
                    else
                    {
                        switch (mapData[i][j])
                        {
                            case emptyChar:
                                mapPositions[i, j] = emptyChar;
                                break;

                            case blockedChar:
                                mapPositions[i, j] = blockedChar;
                                break;

                            default:
                                mapPositions[i, j] = invalidChar;
                                break;
                        }
                    }

                }
            }
        }

        private bool IsBlocked(Vector2 position)
        {
            return mapPositions[position.y, position.x] == blockedChar;
        }

        public void DisplayMap()
        {
            Console.Clear();
            Console.WriteLine(SolutionToString());
        }

        public string SolutionToString()
        {
            StringBuilder sb = new StringBuilder(mapPositions.Length + mapPositions.GetLength(0)); //add extra space for the new lines

            for (int i = 0; i < mapPositions.GetLength(0); ++i)
            {
                for (int j = 0; j < mapPositions.GetLength(1); ++j)
                {
                    sb.Append(mapPositions[i, j]);
                }
                sb.Append('\n');
            }

            return sb.ToString();
        }

        public bool ComputePath()
        {
            //TODO: Implement solution here
            //Add list of vectices to make DiGraph
            List<Vector2> vertices = new List<>();
            int count = 0;
            int distance = Math.Abs()
            int startIndex = 0;
            int goalIndex = 0;
            for (int i = 0; i < mapPositions.Length ; i++){
                for (int j = 0; j < mapPositions.Length; j++)
                {
                    if (mapPositions[i,j] == emptyChar || mapPositions[i,j] == pathChar){
                        Vector2 v;
                        v.y = i;
                        v.x = j;
                        vertices.Add(v);
                        if (startPosition.x == j && startPosition.y == i)
                            startIndex = count;
                        if (goalPosition.x == j && goalPosition.y == i)
                            goalIndex = count;
                        count++;
                        
                    }
                }
            }
            //Initialize new DiGraph
            DiGraph graphMap = new Digraph(vertices.Length);
            //Add edges to make DiGraph
            for (int i = 0; i < vertices.Length ; i++)
            {
                for (int j = i+1 ; j < vectices.Length ; j++)
                {
                    graphMap.AddEdge(vertices[i],vertices[j]);
                }
            }
            return false;
        }

    };
}
