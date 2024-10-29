using OurAppWithHangfire.Interface;
using OurAppWithHangfire.Repository;

namespace OurAppWithHangfire.Services
{
    public class CustomJobService : IBackGroundJobService
    {
        private readonly ICustomJob _customJobRepository;

        public CustomJobService(ICustomJob customJobRepository) 
        {
            _customJobRepository = customJobRepository;
        }

        public async Task RunJob()
        {
            await Task.Run(() => _customJobRepository.RunJob());
        }
    }
}
