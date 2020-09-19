import java.util.*;

public class mravi {
    
    public static void main(String[] args) {
        Scanner ing = new Scanner(System.in);
        
        int n = ing.nextInt();
        int [] t1 = new int[n+1];
        int [] t2 = new int [n+1];
        int [] t3 = new int [n+1];

        for (int i=1;i<n;i++) {
            int a = ing.nextInt();
            int b = ing.nextInt();
            t1[b] = a;
            t2[b] = ing.nextInt();
            t3[b] = ing.nextInt();
        }
        double max2 = 0;

        for (int i =1;i<n+1;i++) {
            double ans = ing.nextDouble();
            if (ans>=0) {
                int j =i;
                while (j>1){
                    if (t3[j]==1) {
                        ans = Math.sqrt(ans);
                    }
                    ans *= (100.0/t2[j]);
                    j= t1[j];
                }
                if (ans>max2) {
                    max2=ans;
                }
            }
        }

        System.out.println(max2);

    }
}