namespace AtomicSeller.Helpers
{
    public class ThingResult<T>
    {
        public bool Success { get; set; }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                Success = false;
                _errorMessage = value;
            }
        }

        private T _result;
        public T Result
        {
            get { return _result; }
            set
            {
                Success = true;
                _result = value;
            }
        }
    }
}
