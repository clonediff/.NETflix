namespace DtoLibrary;

public class PaginationDataDto<T>
{
    public IEnumerable<T> Data { get; set; }
    public int Count { get; set; }
}