import java.util.Scanner;

public class TestApplication {
  public static void main(String[] args) {
    System.out.println("Enter a password: ");
    Scanner input = new Scanner(System.in);
    input.next();
    String s = input.toString();
    System.out.println(s);
  }
}