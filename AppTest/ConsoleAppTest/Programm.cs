public class Program
{
    public static void Main()
    {
        var N = int.Parse(Console.ReadLine());
        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        InsertionSort(input);
    }

    static void InsertionSort(int[] array)
    {
        int buffer;
        for (int i = 1; i < array.Length; i++)
        {
            var flag = false;
            buffer = array[i]; // запоминаем в буфер элемент, который нужно вставить нужное место

            int j = i; // индекс места, куда будем вставлять buffer

            // пока не дошли до начала массива и очередной элемент больше буфера
            while (j > 0 && array[j - 1] > buffer)
            {
                array[j] = array[j - 1]; // перемещаем больший элемент на одну позицию вправо
                j--; // передвигаем индекс для просмотра элемента, который стоит левее
                flag = true;
            }

            array[j] = buffer; // место найдено, вставить элемент
            if (flag)
            {
                Console.WriteLine(string.Join(" ", array));
            }
            
        }
    }
}