using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialMediaContext _context;
        public PostRepository(SocialMediaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Post>> GetPosts() 
        {
            var posts = await _context.Posts.ToListAsync();
            //MOCK
            //var post = Enumerable.Range(1, 10).Select(x => new Post
            //{
            //    PostId = x,
            //    Description = $"Description {x}",
            //    Date = DateTime.Now,
            //    Image = $"https://misapis.com/{x}",
            //    UserId = x * 2,
            //});
            //await Task.Delay(10);
            return posts;
        }

        public async Task<Post> GetPost(int id)
        {
            var post = await _context.Posts.SingleOrDefaultAsync(x => x.PostId == id);
            return post;
        }
        public async Task InsertPost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }
    }
}
