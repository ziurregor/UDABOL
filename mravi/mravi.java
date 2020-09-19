
//Joan Lian Pantigoso Velasco
import java.util.*;
import java.util.Scanner;
public class mravi
{
  public static void main ( String [] args)
  {
   Scanner resultado = new Scanner ( System.in);
    int n= resultado.nextInt();
    int[] s1 = new int [n+1];
    int[] s2 = new int [n+1];
    int[] s3 = new int [n+1];
    for (int j= 1 ;j <n ;j++)
    {
      int a = resultado.nextInt();
      int b = resultado.nextInt();
      s1 [b] = a;
      s2 [b] = resultado.nextInt();
      s3 [b] = resultado.nextInt();
    }
    double c= 0;
    for (int i= 1; i <n +1 ; i++)
    {
      double ans = resultado. nextDouble ();
      if (ans >= 0)
      {
        int d= i;
        while (d > 1)
        {
            if (s3 [d] == 1)
            {
              ans = Math. sqrt (ans);
            }
            ans = ans* (100.0/ s2 [d]);
            d = s1 [d];
          }
          if (ans > c)
          {
            c=ans;
          }
        }
      }
      System.out.println(c);
    }
  }
  
