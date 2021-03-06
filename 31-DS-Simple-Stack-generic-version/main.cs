using System;
using System.Collections.Generic;

class MainClass 
{
  public static void Main (string[] args) 
  {
    Action<object> print = Console.WriteLine;

    Stack<int> s = new Stack<int>(3);
    print(s.Stringify() == String.Empty);
    print(s.Count == 0);
    s.Push(10);
    print(s.Count == 1);
    s.Push(20);
    s.Push(30);
    print(s.Count == 3);
    print(s.Stringify() == "10 20 30");
    print(s.Push(40) == false);
    print(s.Stringify() == "10 20 30");
    print(s.Count == 3);

    int v;
    print(s.Pop(out v) == true);  // Pop함수는 리턴값 bool로 만들거기때문에 out에 출려값을 주고 보낸다
    print(v == 30);
    print(s.Pop(out v) == true);  
    print(v == 20);
    print(s.Pop(out v) == true);  
    print(v == 10);
    print(s.Pop(out v) == false);
    print(s.Stringify() == String.Empty);
    print(s.Count == 0);

    Stack<string> s1 = new Stack<string>(5);
    s1.Push("Hi");
    s1.Push("There");
    s1.Push("How");
    s1.Push("About");
    print(s1.Stringify() == "Hi There How About");
    
    string v2;
    
    print(s1.Pop(out v2) == true);
    print(v2 == "About");

    print(default(int) == 0);
    print(default(float) == 0);
    print(default(string) == null);
    print(default(object) == null);
  } 
}

// property
public class Stack<T>
{
  T[] data;
  int size;
  int top = -1;
  
  public int Count
  {
    get // 읽을때 실행
    {
      return top+1;
    }
    // set이 없어서 값을 쓸수없음
  }

  public Stack(int size)
  {
    data = new T[size];  
    this.size = size;
  }

  public bool Push(T value)
  {
    if(top == size-1)
      return false;
    data[++top] = value;
    return true;
  }

  public bool Pop(out T v)
  {
    if(top == -1)
    {
      v = default(T);
      return false;
    } 
    v = data[top--];
    return true;
  }

  public string Stringify()
  {
    T[] list = new T[top+1];
    Array.Copy(data, list, top+1);

    return list.Stringify();
  }

}

public static class ClassExtension
{
  public static string Stringify<T>(this IEnumerable<T> list)
  {
    return String.Join(" ", list);
  }
}