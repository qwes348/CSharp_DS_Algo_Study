using System;
using System.Collections;
using System.Collections.Generic;

class MainClass 
{
  public static void Main (string[] args) 
  {
    Action<object> print = Console.WriteLine;

    int[][] image = new int [][]
    {
      new int[] {0, 0, 0, 0, 0, 0, 0},
      new int[] {0, 0, 1, 1, 1, 0, 0},
      new int[] {0, 0, 1, 0, 1, 0, 0},
      new int[] {0, 0, 1, 0, 1, 0, 0},
      new int[] {0, 0, 1, 0, 1, 0, 0},
      new int[] {0, 0, 1, 1, 1, 0, 0},
      new int[] {0, 0, 0, 0, 0, 0, 0}
    };

    print(image[0].Stringify() == "0 0 0 0 0 0 0");

    FloodFill(image, 2, 3, 7);
    print(image[0].Stringify() == "0 0 0 0 0 0 0");
    print(image[1].Stringify() == "0 0 1 1 1 0 0");
    print(image[2].Stringify() == "0 0 1 7 1 0 0");
    print(image[3].Stringify() == "0 0 1 7 1 0 0");
    print(image[4].Stringify() == "0 0 1 7 1 0 0");
    print(image[5].Stringify() == "0 0 1 1 1 0 0");
    print(image[6].Stringify() == "0 0 0 0 0 0 0");

    FloodFill(image, 0, 0, 7);
    print(image[0].Stringify() == "7 7 7 7 7 7 7");
    print(image[1].Stringify() == "7 7 1 1 1 7 7");
    print(image[2].Stringify() == "7 7 1 7 1 7 7");
    print(image[3].Stringify() == "7 7 1 7 1 7 7");
    print(image[4].Stringify() == "7 7 1 7 1 7 7");
    print(image[5].Stringify() == "7 7 1 1 1 7 7");
    print(image[6].Stringify() == "7 7 7 7 7 7 7");    

    FloodFill(image, 1, 2, 7);
    print(image[0].Stringify() == "7 7 7 7 7 7 7");
    print(image[1].Stringify() == "7 7 7 7 7 7 7");
    print(image[2].Stringify() == "7 7 7 7 7 7 7");
    print(image[3].Stringify() == "7 7 7 7 7 7 7");
    print(image[4].Stringify() == "7 7 7 7 7 7 7"); 
    print(image[5].Stringify() == "7 7 7 7 7 7 7");
    print(image[6].Stringify() == "7 7 7 7 7 7 7");      
  }

  public static void FloodFill(int[][] image, int StartRow, int StartColumn, 
  int replaceColor)
  {
    int width = image[0].Length;
    int height = image.Length;

    if( !(0 <= StartColumn && StartColumn < width) )
      return;
    if( !(0 <= StartRow && StartRow < height) )     
      return;
    
    int targetColor = image[StartRow][StartColumn];
    Queue<Pos> q = new Queue<Pos>();
    q.Enqueue(new Pos(StartRow, StartColumn));

    while(q.Count > 0)
    {
      Pos pos = q.Dequeue();
      int x = pos.X;
      int y = pos.Y;

      if(image[x][y] == targetColor)  // 자주쓰게될 방식
      {
        image[x][y] = replaceColor;

        if(x-1>=0 && image[x-1][y] == targetColor)
          q.Enqueue(new Pos(x-1, y)); 
        if(y+1<width && image[x][y+1] == targetColor)
          q.Enqueue(new Pos(x, y+1)); 
        if(x+1<height && image[x+1][y] == targetColor)
          q.Enqueue(new Pos(x+1, y)); 
        if(y-1>=0 && image[x][y-1] == targetColor)
          q.Enqueue(new Pos(x, y-1));                               
      }
    }
  }

  class Pos
  {
    public int X {get; set;}
    public int Y {get; set;}
    public Pos(int x, int y) {X=x; Y=y;}
  }
}

public static class ClassExtension
{
  public static string Stringify<T>(this IEnumerable<T> list) 
  {
    return String.Join(" ", list);
  }
}