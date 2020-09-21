import java.text.DecimalFormat;
import java.util.Scanner;

public class Mravi {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
        int n=sc.nextInt();
        int m[][][]=new int[n][n][2];
        double elementos[]=new double[n];
        
        for (int i = 0; i < n - 1; i ++) {
        	
        	int a=sc.nextInt();
        	int b=sc.nextInt();
        	int x=sc.nextInt();
        	int t=sc.nextInt();
        	m[a-1][b-1][0]=x;
        	m[a-1][b-1][1]=t;
        }
        
        for (int i = 0; i < elementos.length; i++) {
			elementos[i]=sc.nextDouble();
		}
        for (int i = n - 1; i >= 0; i --) {
            double mayor = 0.0;
            for (int j = 0; j < n; j ++) {
                if (i != j && m[i][j][0]>0) {
                    if (m[i][j][1] == 0) {
                        elementos[i] = elementos[j] * 100 / m[i][j][0];
                    } else {
                        elementos[i] = Math.sqrt(elementos[j]) * 100 / m[i][j][0];
                    }
                    if (mayor < elementos[i]) {
                        mayor = elementos[i];
                    }
                }
            }
            if (mayor > 0) {
                elementos[i] = mayor;
            }
        }
        sc.close();
        DecimalFormat df=new DecimalFormat("##.###");
        System.out.println(df.format(elementos[0]));
	}

}
