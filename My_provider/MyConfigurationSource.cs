using Microsoft.Extensions.Configuration;

namespace My_provider
{
    public class MyConfigurationSource : IConfigurationSource
    {
        public string _filePath { get; private set; }
        public MyConfigurationSource(string filePath)
        {
            _filePath = filePath;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            string physicalPath = builder.GetFileProvider()
                .GetFileInfo(_filePath).PhysicalPath;
            return new MyConfigurationProvider(physicalPath);
        }
    }
}
