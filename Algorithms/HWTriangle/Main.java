import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        int[][] array = null;
        Scanner sc = new Scanner(System.in);
        boolean first = true;
        int rowLength = 1;
        String[] rowData = new String[rowLength];
        while (sc.hasNextLine()) {
            if (first) {
                array = new int[Integer.parseInt(sc.nextLine())][];
                first = false;
            } else {
                rowData = sc.nextLine().split(" ");
                array[rowLength - 1] = new int[rowLength];
                for (int j = 0; j < rowLength; j++) {
                    array[rowLength - 1][j] = Integer.parseInt(rowData[j]);
                 }
                rowLength++;
            }
        }
        Triangle t = new Triangle(array);
        System.out.println(t.solve());
    }
    
}

class Triangle {
    
    private int[][] array;
    
    public Triangle(int[][] array) {
        this.array = array;
    }
    
    public int solve() {
        for (int i = array.length - 2; i > -1; i--) {
            for (int j = 0; j < array[i].length; j++) {
                array[i][j] = array[i][j] + Math.max(array[i + 1][j], array[i + 1][j + 1]);
            }
        }
        return array[0][0];
    }
    
}
