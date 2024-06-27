using System.Windows.Controls;

namespace lab6789_nazarov.Models;

public class lab7
{
    //
    //СРЕДНИЙ УРОВЕНЬ 6 ЗАДАНИЕ <------------------------------------------------------
    //Назаров Руслан 23-ИСП-2/1
    private class Node
    {
        public double Data { get; set; }
        public Node Next { get; set; }

        public Node(double data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node _front;
    private Node _rear;

    public lab7()
    {
        _front = null;
        _rear = null;
    }

    public void Enqueue(double data)
    {
        Node newNode = new Node(data);
        if (_rear == null)
        {
            _front = newNode;
            _rear = newNode;
        }
        else
        {
            _rear.Next = newNode;
            _rear = newNode;
        }
    }

    public double Dequeue(double s)
    {
        if (_front == null)
        {
            throw new InvalidOperationException("Очередь пуста :(");
        }

        double data = _front.Data;
        _front = _front.Next;
        if (_front == null)
        {
            _rear = null;
        }
        return data;
    }

    public void Remove(double value)
    {
        Node current = _front;
        Node previous = null;

        while (current != null && current.Data != value)
        {
            previous = current;
            current = current.Next;
        }
        if (current != null)
        {
            if (previous == null)
            {
                _front = _front.Next;
                if (_front == null)
                {
                    _rear = null;
                }
            }
            else
            {
                previous.Next = current.Next;
                if (current.Next == null)
                {
                    _rear = previous;
                }
            }
        }
        else
        {
            throw new Exception("Элемент не найден в очереди");
        }
    }

    public double Sum()
    {
        double sum = 0;
        Node current = _front;
        while (current != null)
        {
            sum += current.Data;
            current = current.Next;
        }
        return sum;
    }

    public void ProcessInput(string input, ListBox output, TextBox textBox )
    {
        output.Items.Clear();
        Node current = _front;
        while (current != null)
        {
            output.Items.Add(current.Data);
            current = current.Next;
        }
    }
}