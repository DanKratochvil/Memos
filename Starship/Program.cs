namespace Swapi
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var pilots = new ApiClient();
            var names = await pilots.GetShipNames();

            Console.WriteLine("Starhips with pilot from planet Kashyyyk:");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
