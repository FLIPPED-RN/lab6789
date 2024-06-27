using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using lab6789_nazarov.Models;

namespace lab6789_nazarov;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private LinkedList _linkedList = new LinkedList();
    
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        lab6.ProcessInput(inputDinamic.Text, polNumDinamic);
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        lab6.ProcessInput(inputDinamic.Text, viewRsltDinamic);
    }

    private lab7 _queue = new lab7();

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        if (double.TryParse(stackInput.Text, out double value))
        {
            _queue.Enqueue(value); 
            _queue.ProcessInput("", stackView, null); 
            stackInput.Clear();
            double sum = _queue.Sum();
            string sumSrtring = sum.ToString();
            stackView2.Text = sumSrtring;

        }
        else
        {
            MessageBox.Show("Ошибка: Пустое значение, либо не числа :(");
        }
    }

    private void Button_Click_3(object sender, RoutedEventArgs e)
    {
        try
        {
            double selectedValue = (double)stackView.SelectedItem;
            _queue.Remove(selectedValue);
            _queue.ProcessInput("", stackView, null);

            double sum = _queue.Sum();
            string sumSrtring = sum.ToString();
            stackView2.Text = sumSrtring;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void Button_Click_4(object sender, RoutedEventArgs e)
    {
        if (int.TryParse(inputList.Text, out int value))
        {
            _linkedList.Add(value);
            UpdateListView();
            UpdateSumView();
            RemoveAndDisplayValues();
        }
        else
        {
            MessageBox.Show("Введите корректное целое число.");
        }
    }

    private void UpdateListView()
    {
        var current = _linkedList.Head;
        listView.Text = "";
        while (current != null)
        {
            listView.Text += current.Value + " ";
            current = current.Next;
        }
    }
    
    private void UpdateSumView()
    {
        int sum = _linkedList.SumOfValuesGreaterOrEqualTo(15);
        sumListView.Text = sum.ToString();
    }
    
    private void RemoveAndDisplayValues()
    {
        var current = _linkedList.Head;
        string removedValues = "";
        while (current != null)
        {
            if (current.Value < 5)
            {
                removedValues += current.Value + " ";
            }
            current = current.Next;
        }
        removedListView.Text = removedValues;
        _linkedList.RemoveValuesLessThan(5);
        UpdateListView();
    }
    
    private void OnFindRareWordClick(object sender, RoutedEventArgs e)
    {
        string input = inputTextBox.Text;
        string rareWord = WordProcessor.FindRareWord(input);
        outputTextBlock.Text = rareWord;
    }
}