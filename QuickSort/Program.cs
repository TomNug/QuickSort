using System.Text;
class Program
{
    public static void OutputArray(int[] arr)
    {
        StringBuilder sb = new StringBuilder();
        foreach (int i in arr)
        {
            sb.Append(i.ToString());
            sb.Append(" ");
        }
        Console.WriteLine(sb.ToString());
    }
    public static void Swap(int[] sequence, int index1, int index2)
    {
        int temp = sequence[index1];
        sequence[index1] = sequence[index2];
        sequence[index2] = temp;
    }
    public static int Partition(int[] sequence, int leftBound, int rightBound)
    {
        // pivot value will be last in the sequence
        int pivot = sequence[rightBound];

        // first item from the left which is larger than the pivot
        int leftPartitionPos = 0;

        // For each element in the array
        for (int i = 0; i < rightBound; i++)
        {
            if (sequence[i] <= pivot)
            {
                Swap(sequence, i, leftPartitionPos);
                leftPartitionPos++;
            }
        }
        // Swap the pivot so it's to the right of the left partition
        Swap(sequence, rightBound, leftPartitionPos);
        return leftPartitionPos;
    }

    public static void QuickSort(int[] sequence, int leftBound, int rightBound)
    {
        if (leftBound < rightBound)
        {
            int partition = Partition(sequence, leftBound, rightBound);

            // Sort the left
            QuickSort(sequence, leftBound, partition - 1);

            // Sort the right
            QuickSort(sequence, partition + 1, rightBound);
        }      
    }
    public static void Main(string[] args)
    {
        int[] sequence = { 3, 3, 3, 3, 3, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1};
        QuickSort(sequence, 0, sequence.Length-1);
        Console.WriteLine("QuickSort complete");
        OutputArray(sequence);
    }
}