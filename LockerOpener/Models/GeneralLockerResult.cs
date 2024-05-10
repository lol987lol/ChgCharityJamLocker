namespace LockerOpener.Models
{
    public class GeneralLockerResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
