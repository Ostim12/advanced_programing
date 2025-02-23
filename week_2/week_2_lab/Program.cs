// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


Person person1 = new Person("test",23);

Person person2 = new Person("test2", 32 , person1);

person2.displayInfo();


public class Person{

    public string person_name {get;set;}
    public int person_age {get;set;}
    public Person? person_child {get;set;}


    public Person(string name, int age, Person? child = null){
        person_name = name;
        person_age = age;
        if (child != null){
            person_child = child;
        }
        else{
            person_child = null;
        }
    }


    public void displayInfo(){
        Console.WriteLine("name : " + person_name);
        Console.WriteLine("age : " + person_age);
        if (person_child != null){
            Console.WriteLine("child: ");
            person_child.displayInfo();
        }
    }
}