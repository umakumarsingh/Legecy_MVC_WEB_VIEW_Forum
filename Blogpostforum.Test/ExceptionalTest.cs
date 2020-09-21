using Blogpostforum.BussinessLayer.Interfaces;
using Blogpostforum.BussinessLayer.Services;
using Blogpostforum.BussinessLayer.Services.Repository;
using Blogpostforum.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Blogpostforum.Test
{
    public class ExceptionalTest
    {
        //injecting IBlogPostService interface to access all method
        private readonly IBlogPostServices _services;
        //mocking IBlogPostRepository to access all Repository method
        public readonly Mock<IBlogPostRepository> mockservice = new Mock<IBlogPostRepository>();
        private readonly Post _blogPost;
        private readonly Comment _comment;
        public ExceptionalTest()
        {
            _services = new BlogPostServices(mockservice.Object);
            _blogPost = new Post()
            {
                PostId = 1,
                Title = "Blog Post 1",
                Abstract = "Abstract - 1",
                Description = "Blog post Description",
                PostedDate = DateTime.Now
            };
            _comment = new Comment()
            {
                CommentMsg = "Post Title Comments -1 ",
                PostId = 1,
                CommentedDate = DateTime.Now
            };
        }

        /// <summary>
        /// creating static constructor for creating test output in text file 
        /// </summary>
        static ExceptionalTest()
        {
            if (!File.Exists("../../../output_exception_revised.txt"))
                try
                {
                    File.Create("../../../output_exception_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../output_exception_revised.txt");
                File.Create("../../../output_exception_revised.txt").Dispose();
            }
        }
        /// <summary>
        /// Check if blog post is null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateNewPost_Null_Failure()
        {
            // Arrange
            // Arrange
            var res = false;
            var blogPost = new Post()
            {
                Title = "Post-Title",
                Abstract = "Post Abstract-1",
                Description = "Post Description -1"
            };
            blogPost = null;
            //Act 
            mockservice.Setup(blogRepo => blogRepo.Create(blogPost));
            var result = await _services.Create(blogPost);
            if (result == null)
            {
                res = true;
            }
            //writing tset boolean output in text file, that is present in project directory
            File.AppendAllText("../../../output_exception_revised.txt", "CreateNewPost_Null_Failure=" + res + "\n");

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateNewComment_Null_Failure()
        {
            // Arrange
            // Arrange
            var res = false;
            var commnet = new Comment()
            {
                CommentMsg = "Post Title Comments -1 ",
                PostId = 1,
                CommentedDate = DateTime.Now
            };
            commnet = null;
            //Act 
            mockservice.Setup(blogRepo => blogRepo.Comments(_blogPost.PostId, commnet));
            var result = await _services.Comments(_blogPost.PostId, commnet);
            if (result == null)
            {
                res = true;
            }
            //writing tset boolean output in text file, that is present in project directory
            File.AppendAllText("../../../output_exception_revised.txt", "CreateNewComment_Null_Failure=" + res + "\n");
        }
    }
}
