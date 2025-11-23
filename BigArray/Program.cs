namespace BigArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MaxRnd = (int) 10E8;
            const int arrSize = (int) 10E6;

            var rnd = new Random();
            var arr =new int[arrSize];
            var hashset = new HashSet<int>();
            
            for (int i=0; i<arr.Length; i++)
                arr[i] = rnd.Next(MaxRnd);

            for (int i = 0; i < arr.Length; i++)
            {
                if (hashset.Contains(arr[i]))
                {
                    Console.Write($"{arr[i]} ");
                }
                else
                {
                    hashset.Add(arr[i]);
                }
            }
        }
    }
}
