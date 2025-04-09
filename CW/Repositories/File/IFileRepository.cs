
        public interface IFileRepository{
            public Task<string> Save(IFormFile file);
        }
        