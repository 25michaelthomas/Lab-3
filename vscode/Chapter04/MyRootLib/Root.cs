namespace MyRootLib;


public class Root
{
    
    public static double MyRoot(double number) {
        double root;
        root = Math.Pow(number, 2);

        Console.WriteLine("The square root of " + number + " is " + root);
        return root;
    }
}
