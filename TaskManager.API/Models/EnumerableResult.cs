namespace TaskManager.API.Models
{
    public class EnumerableResult<T>
    {
        public IEnumerable<T> Result { get; set; }
        public int Length { 
            get {
                return Result.Count();
            } 
        }
    }
}
