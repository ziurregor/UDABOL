//package mravins;

import java.util.Scanner;
import javax.swing.JOptionPane;

/**
 *
 * 
 */
public class Mravins {

    public static void main(String[] args) {
        Scanner leer=new Scanner(System.in);
        
        int n=leer.nextInt();
        int[] a = new int[n + 1];
        int[] b = new int[n + 1];
        int[] t = new int[n + 1];
        for (int i = 1; i < n; i++) 
        {  
            int x=leer.nextInt();
            int y=leer.nextInt();
            a[y] = x;
            b[y] = leer.nextInt();
            t[y] = leer.nextInt();
        }
        double z = 0;
        for (int j = 1; j < n + 1; j++) {
            
            double l = leer.nextDouble();
            if (l >= 0) {
                int r = j;
                while (r > 1) {
                    if (t[r] == 1) {
                        l = Math.sqrt(l);
                    }

                    l = l * (100.0 / b[r]);
                    r = a[r];

                }
                if (l > z) {
                    z = l ;
                }
            }
        }
        
        System.out.println(z);

    }
}