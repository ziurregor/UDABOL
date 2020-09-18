/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package mravi;

/**
 *
 * @author WILDER
 */
import java.util.*;

public class MraviWilder {
    public static void main(String[] args) {
        Scanner muestra = new Scanner(System.in);
        int n = muestra.nextInt();
	int [] parent = new int[n+1];
	int [] perc = new int [n+1];
	int [] issuper = new int [n+1];
        for (int c=1;c<n;c++) {
            int a = muestra.nextInt();
            int b = muestra.nextInt();
            parent[b] = a;
            perc[b] = muestra.nextInt();
            issuper[b] = muestra.nextInt();
        }
        double m = 0;
        for (int i =1;i<n+1;i++) {
            double ans = muestra.nextDouble();
            if (ans>=0) {
                int j =i;
                while (j>1){
                    if (issuper[j]==1) {
                        ans = Math.sqrt(ans);
                    }
                    ans *= (100.0/perc[j]);
                    j= parent[j];
                }
                if (ans>m) {
                    m=ans;
                }
            }
        }
        System.out.println(m);
    }
}

