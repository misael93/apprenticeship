
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        int[] doors;
        int [] keys;
        Scanner sc = new Scanner(System.in);
        doors = new int[Integer.parseInt(sc.nextLine())];
        String[] doorSizes = sc.nextLine().split(" ");
        keys = new int[Integer.parseInt(sc.nextLine())];
        String[] keySizes = sc.nextLine().split(" ");
        
        for (int i = 0; i < doors.length; i++) {
            doors[i] = Integer.parseInt(doorSizes[i]);
        }
        
        for (int i = 0; i < keys.length; i++) {
            keys[i] = Integer.parseInt(keySizes[i]);
        }
        
        Solution s = new Solution(doors, keys);
        System.out.println(s.solve());
    }
    
}

class Solution {
    
    private int[] doors;
    private int[] keys;
    
    public Solution(int[] doors, int[] keys) {
        this.doors = doors;
        this.keys = keys;
    }
    
    int binarySearch(int key, int low, int high) {
        if (high < low) return 0;
        
        int mid = (high + low) / 2;
        if (doors[mid] == key) {
            return mid + 1;
        } else if (doors[mid] > key) {
            return binarySearch(key, low, mid - 1);
        } else {
            return binarySearch(key, mid + 1, high);
        }
    }
    
    String solve() {
		String result = "";
        for (int i = 0; i < keys.length; i++) {
			result += binarySearch(keys[i], 0, doors.length - 1) + " ";
        }
		return result.trim();
    }
    
}
