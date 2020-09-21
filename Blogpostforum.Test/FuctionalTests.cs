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
    public class FuctionalTests
    {
        //injecting IBlogPostService interface to access all method
        private readonly IBlogPostServices _services;
        //mocking IBlogPostRepository to access all Repository method
        public readonly Mock<IBlogPostRepository> mockservice = new Mock<IBlogPostRepository>();
        private readonly Post _blogPost;
        private readonly Comment _comment;
        public FuctionalTests()
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
        static FuctionalTests()
        {
            if (!File.Exists("../../../output_revised.txt"))
                try
                {
                    File.Create("../../../output_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../output_revised.txt");
                File.Create("../../../output_revised.txt").Dispose();
            }
        }

        /// <summary>
        /// using this test method retriving all post as list
        /// </summary>
        /// <returns>post list and if list is present return true and write output in text file</returns>
        [Fact]
        public async Task Test_Get_GetAllPost()
        {
            // Arrange
            var res = false;
            // Act
            mockservice.Setup(blogRepo => blogRepo.GetAllPost());
            var result = await _services.GetAllPost();
            if (result != null)
            {
                res = true;
            }
            // Assert
            //writing tset boolean output in text file, that is present in project directory
            File.AppendAllText("../../../output_revised.txt",
                "Test_Get_GetAllPost="
                + res.ToString() + "\n");
        }

        /// <summary>
        /// using this method create new BlogPost
        /// </summary>
        /// <returns>return true if post is created and write output in text file</returns>
        [Fact]
        public async Task Test_Post_CreateBlogPostAsync()
        {
            // Arrange
            var res = false;
            // Act
            mockservice.Setup(blogRepo => blogRepo.Create(_blogPost)).ReturnsAsync(_blogPost);
            var result = await _services.Create(_blogPost);
            if (result == _blogPost)
            {
                res = true;
            }
            // Assert
            //writing tset boolean output in text file, that is present in project directory
            File.AppendAllText("../../../output_revised.txt",
                "Test_Post_CreateBlogPost="
                + res.ToString() + "\n");
        }
        /// <summary>
        /// using this method get a single BlogPost
        /// </summary>
        /// <returns>return true if post is exists and write output in text file</returns>
        [Fact]
        public async Task Test_Get_GetOnePostById()
        {
            // Arrange
            var res = false;
            // Act
            mockservice.Setup(blogRepo => blogRepo.GetPostById(_blogPost.PostId)).ReturnsAsync(_blogPost);
            var result = await _services.GetPostById(_blogPost.PostId);
            if (result != null)
            {
                res = true;
            }
            // Assert
            //writing tset boolean output in text file, that is present in project directory
            File.AppendAllText("../../../output_revised.txt",
                "Test_Get_GetOnePostById="
                + res.ToString() + "\n");
        }

        /// <summary>
        /// using this method create a commnet on BlogPost
        /// </summary>
        /// <returns>return true if comment inserted and write output in text file</returns>
        [Fact]
        public async void Test_Post_CreateBlogPostComment()
        {
            // Arrange
            var res = false;

            // Act
            mockservice.Setup(blogRepo => blogRepo.Comments(_blogPost.PostId, _comment)).ReturnsAsync(_comment);
            var result = await _services.Comments(_blogPost.PostId, _comment);
            if (result == _comment)
            {
                res = true;
            }
            // Assert
            //writing tset boolean output in text file, that is present in project directory
            File.AppendAllText("../../../output_revised.txt",
                "Test_Post_CreateBlogPostComment="
                + res.ToString() + "\n");
        }

        /// <summary>
        /// using this method get a list of comment related BlogPost
        /// </summary>
        /// <returns>return true if comment is exists and write output in text file</returns>
        [Fact]
        public async Task Test_Get_GetAllCommentById()
        {
            // Arrange
            var res = false;
            // Act
            mockservice.Setup(blogRepo => blogRepo.GetAllComments(_blogPost.PostId));
            var result = await _services.GetAllComments(_blogPost.PostId);
            if (result != null)
            {
                res = true;
            }
            // Assert
            //writing tset boolean output in text file, that is present in project directory
            File.AppendAllText("../../../output_revised.txt",
                "Test_Get_GetAllCommentById="
                + res.ToString() + "\n");
        }
    }
}
