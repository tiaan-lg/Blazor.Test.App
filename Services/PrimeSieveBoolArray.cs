namespace MyMudBlazorApplication.Services
{
    public class PrimeSieveBoolArray
    {
        private bool[] BoolArray { get; set; }

        public long Size { get; set; }

        public PrimeSieveBoolArray(long size)
        {
            Size = size;
            BoolArray = new bool[Size - 2];
            Array.Fill(BoolArray, true);
        }

        public void Run()
        {
            var d = 2;
            var t = Math.Sqrt(Size);

            for (var i = 0; i < t; i++)
            {
                if (BoolArray[i])
                {
                    for (var j = (i + d - 1) * 2; j < Size - d; j += (i + d))
                    {
                        BoolArray[j] = false;
                    }
                }
            }
        }

        public long GetPrimeCount()
        {
            return BoolArray.Count(x => x);
        }

        public List<int> GetPrimes()
        {
            return BoolArray.Select((x, p) => new { IsPrime = x, Index = p }).Where(x => x.IsPrime).Select(x => x.Index + 2).ToList();
        }

        public override string ToString()
        {
            return string.Join(",", GetPrimes());
        }

        public void PrintResults(bool showResults, double duration, int passes)
        {
            Console.WriteLine("Passes: " + passes + ", Time: " + duration + ", Avg: " + (duration / passes) + ", Limit: " + this.Size + ", Count: " + GetPrimeCount());
        }
    }
}
