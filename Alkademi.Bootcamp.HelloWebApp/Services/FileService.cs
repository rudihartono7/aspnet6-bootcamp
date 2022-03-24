using Alkademi.Bootcamp.HelloWebApp.Models;

namespace Alkademi.Bootcamp.HelloWebApp.Services
{
    public class FileService : IFileService
    {
        private const string FILE_NAME = "_data.txt";
        public async Task<List<TweetViewModel>> Read()
        {
            if(!File.Exists(System.AppContext.BaseDirectory + FILE_NAME)){
                return new List<TweetViewModel>();
            }
            var res = await File.ReadAllLinesAsync(System.AppContext.BaseDirectory + FILE_NAME);
            if(res == null)
                return new List<TweetViewModel>();

            List<TweetViewModel> tweets = new List<TweetViewModel>();
            foreach (var item in res)
            {
                var dataSplit = item.Split(":").ToArray();
                tweets.Add(new TweetViewModel(int.Parse(dataSplit[0]), dataSplit[1], dataSplit[2]));
            }

            return tweets;
        }

        public async Task Write(TweetViewModel request)
        {
            if(!File.Exists(System.AppContext.BaseDirectory + FILE_NAME)){
                using (var fileStream = File.Create(System.AppContext.BaseDirectory + FILE_NAME)){
                    fileStream.Close();
                }
            }
            using(var fileStream = File.AppendText(System.AppContext.BaseDirectory + FILE_NAME)){
                await fileStream.WriteLineAsync($"{request.Id}:{request.Title}:{request.Desc}");
            }
        }
    }
}
