import java.util.*;

public class mravi{
    
    public static void main(String[] args) {
        Scanner ing = new Scanner(System.in);
        
        int n = ing.nextInt();
        int [] padre = new int [n + 1];
        int [] porcentaje = new int [n + 1];
        int [] tuberia = new int [n + 1];

        for (int i = 1; i<n ; i++)
 	{
            int x = ing.nextInt();
            int y = ing.nextInt();
            padre[y] = x;
            porcentaje[y] = ing.nextInt();
            tuberia[y] = ing.nextInt();
        }
        double aux = 0;

        for (int j=1;j<n+1;j++) 
	{
            double p = ing.nextDouble();
            if (p >= 0) 
		{
                  int k = i;
                  while (k > 1)
		  {
                    if (tuberia[k] == 1) 
	            {
                        p = Math.sqrt(p);
                    }
                    p *= (100.0/porcentaje[k]);
                    k= padres[k];
                    }
                if (p>aux) 
		{
                    aux=p;
                }
            }
        }

        	System.out.println(aux);
        }
}
