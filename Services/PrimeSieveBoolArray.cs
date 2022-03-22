namespace MyMudBlazorApplication.Services
{
    public class PrimeSieveBoolArray
    {
        private readonly bool[] _boolArray;
        private readonly long _size;

        public PrimeSieveBoolArray(long size)
        {
            _size = size;
            _boolArray = new bool[_size - 2];
            Array.Fill(_boolArray, true);
        }

        public void Run()
        {
            const int d = 2;
            var t = Math.Sqrt(_size);

            for (var i = 0; i < t; i++)
            {
                if (!_boolArray[i]) continue;
                for (var j = (i + d - 1) * 2; j < _size - d; j += (i + d))
                {
                    _boolArray[j] = false;
                }
            }
        }

        public long GetPrimeCount()
        {
            return _boolArray.Count(x => x);
        }

        public List<int> GetPrimes()
        {
            return _boolArray.Select((x, p) => new { IsPrime = x, Index = p }).Where(x => x.IsPrime).Select(x => x.Index + 2).ToList();
        }

        public override string ToString()
        {
            return string.Join(", ", GetPrimes());
        }
    }
}
