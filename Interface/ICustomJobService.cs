namespace OurAppWithHangfire.Interface
{
    public interface IBackGroundJobService
    {
        public Task RunJob();
    }
}
