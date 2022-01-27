using cronos.entity.Entity;
using cronos.repository.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cronos.service.Service
{
    public class PostService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Post> DeleteAsync(long id)
        {
            Post post;

            using (_unitOfWork)
            {
                post = await _unitOfWork.PostRepository.GetAsync(id);

                if (post == null)
                    return null;

                await _unitOfWork.PostRepository.DeleteAsync(post);
            }

            return post;
        }

        public async Task<Post> GetAsync(long id)
        {
            Post post;

            using (_unitOfWork)
            {
                post = await _unitOfWork.PostRepository.GetAsync(id);
            }

            return post;
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            IEnumerable<Post> posts;

            using (_unitOfWork)
            {
                posts = await _unitOfWork.PostRepository.GetAllAsync();
            }

            return posts;
        }

        public async Task<Post> InsertAsync(Post post)
        {
            using (_unitOfWork)
            {
                await _unitOfWork.PostRepository.InsertAsync(post);
            }

            return post;
        }

        public async Task<Post> UpdateAsync(Post post)
        {
            Post postupd;

            using (_unitOfWork)
            {
                postupd = await _unitOfWork.PostRepository.GetAsync(post.id);

                if (postupd == null)
                    return null;

                postupd.Update(post);
                await _unitOfWork.PostRepository.UpdateAsync(postupd);
            }

            return postupd;
        }
    }
}
