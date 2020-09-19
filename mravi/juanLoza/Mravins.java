/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package mravins;

import java.util.Scanner;
import javax.swing.JOptionPane;

/**
 *
 * @author Jloza
 */
public class Mravins {

    public static void main(String[] args) {
        Scanner leer=new Scanner(System.in);
        int n;
        //n = Integer.parseInt(JOptionPane.showInputDialog("ingrese el numero de nodos"));
        n=leer.nextInt();
        int[] pa = new int[n + 1];
        int[] pr = new int[n + 1];
        int[] tu = new int[n + 1];
        for (int i = 1; i < n; i++) {
            //int x = Integer.parseInt(JOptionPane.showInputDialog("ingrese daros de entrada"));
            //int y = Integer.parseInt(JOptionPane.showInputDialog("ingrese daos de entrada"));
            int x=leer.nextInt();
            int y=leer.nextInt();
            pa[y] = x;
            //pr[y] = Integer.parseInt(JOptionPane.showInputDialog("ingrese datos de entrada"));
            //tu[y] = Integer.parseInt(JOptionPane.showInputDialog("ingrese datos de entrada"));
            pr[y] = leer.nextInt();
            tu[y] = leer.nextInt();
        }
        double p = 0;
        for (int j = 1; j < n + 1; j++) {
            //double esp = Double.parseDouble(JOptionPane.showInputDialog("ingrese datos de entrada"));
            double esp = leer.nextDouble();
            if (esp >= 0) {
                int r = j;
                while (r > 1) {
                    if (tu[r] == 1) {
                        esp = Math.sqrt(esp);
                    }

                    esp = esp * (100.0 / pr[r]);
                    r = pa[r];

                }
                if (esp > p) {
                    p = esp;
                }
            }
        }
        //JOptionPane.showMessageDialog(null, "la salida es :  " + p);
        System.out.println(p);

    }
}
