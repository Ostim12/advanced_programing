//task 1

using System.ComponentModel.DataAnnotations.Schema;

IntQueue queue = new IntQueue(5);
queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);
Console.WriteLine(queue.Dequeue());

Queue<int> queue2 = new Queue<int>(5);
queue2.Enqueue(1);
queue2.Enqueue(2);
queue2.Enqueue(3);
Console.WriteLine(queue2.Dequeue());


//task 2
IntStack stack = new IntStack(5);
stack.Push(1);
stack.Push(2);
stack.Push(3);
Console.WriteLine(stack.Pop());

Stack<int> stack2 = new Stack<int>(5);
stack2.Push(1);
stack2.Push(2);
stack2.Push(3);
Console.WriteLine(stack2.Pop());

//task 3
SimpleHashTable hashTable = new SimpleHashTable();
hashTable.Insert("Alice",25);
hashTable.Insert("Bob",30);
Console.WriteLine(hashTable.GetValue("Alice"));


//task 1 class
class IntQueue{

    private int[] queue {get; set;}
    private int size {get;set;}

    public IntQueue(int capacity){
        queue = new int[capacity];
        size = 0;
    }

    public void Enqueue(int input){
        if (size == queue.Length)
            throw new InvalidOperationException("Queue is full");

        queue[size] = input;
        size ++;
    }

    public int Dequeue(){
        if(size == 0)
            throw new InvalidOperationException("Queue is empty");

        int return_item = queue[0];
        
        for (int i = 1; i <size; i++)
            queue[i-1] = queue[i];

        size--;
        return return_item;
        
    }

    public int Peek(){
        if (size == 0)
            throw new InvalidOperationException("Queue is empty");

        return queue[0];
    }
    

}


//task 2 class
class IntStack{
    private int[] stack {get; set;}
    private int size {get;set;}

    public IntStack(int capacity){
        stack = new int[capacity];
        size = 0;
    }

    public void Push(int input){
        if (size == stack.Length)
            throw new InvalidOperationException("Stack is full");

        stack[size] = input;
        size ++;
    }

    public int Pop(){
        if(size == 0)
            throw new InvalidOperationException("Stack is empty");

        int return_item = stack[size-1];
        size--;
        return return_item;
        
    }

    public int Peek(){
        if (size == 0)
            throw new InvalidOperationException("Stack is empty");

        return stack[size-1];
    }
}


//task 3 class
class SimpleHashTable{
    private int size = 10;
    private string[] keys;
    private int[] values;

    public SimpleHashTable(){
        keys = new string[size];
        values = new int[size];
    }

    private int GetHash(string key){
        int hash = 0;
        foreach (char c in key){
            hash += c;
        }
        return hash % size;
    }

    public void Insert(string key, int value){
        int index = GetHash(key);

        if (keys[index] == key || keys[index] ==null){
            keys[index] = key;
            values[index] =value;
        }
        else{
            throw new InvalidOperationException("Hash collision occurred");
        }
    }

    public int GetValue(string key){
        int index = GetHash(key);
        return values[index];
    }
}