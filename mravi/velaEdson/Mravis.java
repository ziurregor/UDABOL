package E_1;
import java.util.Scanner;
public class Mravis {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n;
        n = sc.nextInt();
        if (1 <= n && n <= 1000) {
            int M[][] = new int[n + 1][5];
            int Vk[] = new int[n + 1];
            int a[] = new int[n + 1];
            int x[] = new int[n + 1];
            int p[] = new int[n + 1];
            double auxRes = 0;
            for (int i = 1; i < n; i++) {
                for (int j = 1; j <= 4; j++) {
                    M[i][j] = sc.nextInt();
                }
            }
            for (int i = 1; i < Vk.length; i++) {
                Vk[i] = sc.nextInt();
            }
            for (int i = 1; i < n; i++) {
                a[M[i][2]] = M[i][1];
                x[M[i][2]] = M[i][3];
                p[M[i][2]] = M[i][4];
            }
            int c=1;
            while (c < n+1 ) {
                double aux = Vk[c];
                if (aux >= 0) {
                    int au = c;
                    while (au > 1) {
                        if (p[au] == 1) {
                            aux = Math.sqrt(aux);
                        }
                        aux = aux * (100.0/ x[au]);
                        au = a[au];
                    }
                    if (aux > auxRes) {
                        auxRes = aux;
                    }
                }
                c++;
            }
            System.out.println(auxRes);
        }
    }
}
