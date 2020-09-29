import java.util.*;

public class Tarea3
    {
        public static void main(String[] args)
        {
            Scanner dato = new Scanner(System.in);
            int n = dato.nextInt();
            int[] z = new int[n + 1];
            int[] xi = new int[n + 1];
            int[] ti = new int[n + 1];

            for (int i = 1; i < n; i++)
            {
                int x = dato.nextInt();
                int y = dato.nextInt();
                z[y] = x;
                xi[y] = dato.nextInt();
                ti[y] = dato.nextInt();
            }
            double p = 0;
            for (int j = 1; j < n + 1; j++)
            {
                double resp = dato.nextDouble();
                if (resp >= 0)
                {
                    int r = j;
                    while (r > 1)
                    {
                        if (ti[r] == 1){
                            resp = Math.sqrt(resp);
                    }
                        resp = resp * (100.0 / xi[r]);
                        r = z[r];

                    }
                    if (resp > p){
                        p = resp;
                    }                    
                }
            }
            System.out.println(p);
        }
    }