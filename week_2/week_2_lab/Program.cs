//task 1
using System.Numerics;
using System.Reflection;

Console.WriteLine();
Console.WriteLine("task 1");
Console.WriteLine();

Person person1 = new Person("test",23); 
Person person2 = new Person("test2", 32 , [person1]);

person2.AddChild(person1);


person2.DisplayInfo();




//task 2
Console.WriteLine();
Console.WriteLine("task 2");
Console.WriteLine();


void PrintArray(int[] arr){
    foreach( int num in arr){
        Console.WriteLine(num);
    }
    return;
}

int[] numbers = {10,20,5,8,15};

PrintArray(numbers);

Console.WriteLine("Max Value: " + numbers.Max());

// matrix stuff
int[,] input = { {1, 4, 2}, {3, 6, 8}};
Matrix matrix1 = new Matrix(input);

int[,] input2 = { {1, 4, 2}, {3, 6, 8}};
Matrix matrix2 = new Matrix(input2);

Matrix resualt = new Matrix( matrix1.AddMatrix(matrix2));

resualt.Display();

//task 3
Console.WriteLine();
Console.WriteLine("task 3");
Console.WriteLine();


LinkedList<int> test = new LinkedList<int>();

LinkedList link_list = new LinkedList(test);

link_list.InsertionEnd(43);
link_list.InsertionEnd(32);
link_list.display();
link_list.Deletion(43);
link_list.display();
Console.WriteLine(link_list.Search(32));


//task 1 class
/// <summary>
/// Private fields: name (string), age (int), children (Person[]) <br />
/// Public properties for each field <br />
/// A constructor to initialize the fields <br />
/// A method DisplayInfo() to print Person details 
/// </summary>
public class Person{

    private string person_name {get;set;}
    private int person_age {get;set;}
    private List<Person>? person_children {get;set;} // can be null

    /// <summary>
    /// constructs the class
    /// </summary>
    /// <param name="name">name of the person</param>
    /// <param name="age">age of the person</param>
    /// <param name="children">a list of all persons children, can be null</param>
    public Person(string name, int age, List<Person>? child = null){
        person_name = name;
        person_age = age;
        if (child != null){
            person_children = child;
        }
        else{
            person_children = null;
        }
    }

    /// <summary>
    /// prints out the name and age <br />
    ///  if the person has a child it will print their name and age, <br />
    /// then also do the same for their child if they have one  
    /// </summary>
    public void DisplayInfo(){
        Console.WriteLine("name : " + person_name);
        Console.WriteLine("age : " + person_age);
        if (person_children != null){
            Console.WriteLine("children: ");
            foreach (Person child in person_children){
                child.DisplayInfo();
                }
        }
    }
    public void AddChild(Person child){
        person_children.Add(child);
        return;
    }
    public void AddChildren(List<Person> children){
        foreach (Person child in children){
            person_children.Add(child);
        }
        return;
    }

}

//task 2 class

public class Matrix{

    public int[,] main_matrix {get;set;}
    public int length {get;set;}


    public Matrix(int[,] Matrix){
        main_matrix = Matrix;
        length = Matrix.Length;
        Console.WriteLine($"length : {length}");
    }

    public void CheckDimensions(Matrix second_matrix){
        if (second_matrix.length != length){
            throw new Exception("matrixes have diffrent amount of dimensions");
        }
        return;
    }

    public int[,] AddMatrix(Matrix second_matrix){
        int[,] resualt_matrix = main_matrix;
        try {
            CheckDimensions(second_matrix);
        }
        catch (Exception e){
            Console.WriteLine(e);
        }

        int[,] second = second_matrix.main_matrix;
        for (int i = 0; i < main_matrix.GetLength(0); i++) 
        { 
            for (int j = 0; j < main_matrix.GetLength(1); j++) 
            { 
                Console.WriteLine($"{main_matrix[i, j]} + {second[i, j]} = {main_matrix[i, j] + second[i, j]}"); 
                resualt_matrix[i, j] = main_matrix[i, j] + second[i, j];
            } 
        } 


        return resualt_matrix;
    }


    public void Display(){
        for (int i = 0; i < main_matrix.GetLength(0); i++) 
        { 
            for (int j = 0; j < main_matrix.GetLength(1); j++) 
            { 
                Console.WriteLine(main_matrix[i, j]); 
            } 
        }
    }

}


//task 3 class
public class LinkedList{
    
    public LinkedList<int> int_link_list {get;set;}

    public LinkedList(LinkedList<int> Int_link_list){
        int_link_list = Int_link_list;
    }

    public void InsertionEnd(int num){
        int_link_list.AddLast(num);
    }
    
    public void Deletion(int num){
        int_link_list.Remove(num);
    }

    /// <summary>
    /// finds num in the link list and returns its full node <br />
    /// e.g if we have the value of 1234 stored and you search for 2 it will return 1234
    /// </summary>
    /// <param name="num">the int that we are searching for</param>
    /// <returns>an int of what num contains </returns>
    public int? Search(int num){
        return  int_link_list.Find(num).Value;
    }

    public void display(){
        foreach(var num in int_link_list){
            Console.WriteLine(num);
        }
    }
}