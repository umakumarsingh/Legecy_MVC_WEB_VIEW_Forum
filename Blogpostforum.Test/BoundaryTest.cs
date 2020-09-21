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
    public class BoundaryTest
    {
        //injecting IBlogPostService interface to access all method
        private readonly IBlogPostServices _services;
        //mocking IBlogPostRepository to access all Repository method
        public readonly Mock<IBlogPostRepository> mockservice = new Mock<IBlogPostRepository>();
        private readonly Post _blogPost;
        private readonly Comment _comment;
        public BoundaryTest()
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
        /// creating static constructor for creating text file if not exists.
        /// </summary>
        static BoundaryTest()
        {
            if (!File.Exists("../../../output_boundary_revised.txt"))
                try
                {
                    File.Create("../../../output_boundary_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../output_boundary_revised.txt");
                File.Create("../../../output_boundary_revised.txt").Dispose();
            }
        }
        /// <summary>
        /// validate BlogPostId
        /// </summary>
        /// <returns>return true if postId is exists write output in text file</returns>
        [Fact]
        public async Task<bool> Testfor_ValidatePostId()
        {
            //Arrange
            bool res = false;
            try
            {
                //Assigning values for new post
                //Act
                mockservice.Setup(repo => repo.Create(_blogPost)).ReturnsAsync(_blogPost);
                var result = await _services.Create(_blogPost);
                if (result.PostId == _blogPost.PostId)
                {
                    res = true;
                }
                //Assert
                //writing tset boolean output in text file, that is present in project directory
                File.AppendAllText("../../../output_boundary_revised.txt",
                    "Testfor_ValidatePostId=" + res + "\n");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return res;
        }

        /// <summary>
        /// validate BlogPost Title Property
        /// </summary>
        /// <returns>return true if Title is not null and write output in text file</returns>
        [Fact]
        public async Task<bool> Test_ValidateBlogPost_TitleProperty_Empty()
        {
            //Arrange
            bool res = false;
            try
            {
                //Act
                mockservice.Setup(repo => repo.Create(_blogPost)).ReturnsAsync(_blogPost);
                var result = await _services.Create(_blogPost);
                if (result.Title != null)
                {
                    res = true;
                }
                //Assert
                //writing tset boolean output in text file, that is present in project directory
                File.AppendAllText("../../../output_boundary_revised.txt",
                    "Test_ValidateBlogPost_TitleProperty_Empty=" + res + "\n");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return res;
        }
        /// <summary>
        /// validate BlogPost Abstract Property
        /// </summary>
        /// <returns>return true if Abstract is not null and write output in text file</returns>
        [Fact]
        public async Task<bool> Test_ValidateBlogPost_AbstractProperty_Empty()
        {
            //Arrange
            bool res = false;
            try
            {
                //Act
                mockservice.Setup(repo => repo.Create(_blogPost)).ReturnsAsync(_blogPost);
                var result = await _services.Create(_blogPost);
                if (result.Abstract != null)
                {
                    res = true;
                }
                //Assert
                //writing tset boolean output in text file, that is present in project directory
                File.AppendAllText("../../../output_boundary_revised.txt",
                    "Test_ValidateBlogPost_AbstractProperty_Empty=" + res + "\n");

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return res;
        }
        /// <summary>
        /// validate BlogPost Description Property
        /// </summary>
        /// <returns>return true if Description is not null and write output in text file</returns>
        [Fact]
        public async Task<bool> Test_ValidateBlogPost_DescriptionProperty_Empty()
        {
            //Arrange
            bool res = false;
            try
            {
                //Act
                mockservice.Setup(repo => repo.Create(_blogPost)).ReturnsAsync(_blogPost);
                var result = await _services.Create(_blogPost);
                if (result.Description != null)
                {
                    res = true;
                }
                //Assert
                //writing tset boolean output in text file, that is present in project directory
                File.AppendAllText("../../../output_boundary_revised.txt",
                    "Test_ValidateBlogPost_DescriptionProperty_Empty=" + res + "\n");

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return res;
        }
        /// <summary>
        /// validate Comment CommentMsg Property
        /// </summary>
        /// <returns>return true if CommentMsg is not null and write output in text file</returns>
        [Fact]
        public async Task<bool> Test_ValidateComment_CommentMsgProperty_Empty()
        {
            //Arrange
            bool res = false;
            try
            {
                //Act
                mockservice.Setup(repo => repo.Comments(_blogPost.PostId, _comment)).ReturnsAsync(_comment);
                var result = await _services.Comments(_blogPost.PostId, _comment);
                if (result.CommentMsg != null)
                {
                    res = true;
                }
                //Assert
                //writing tset boolean output in text file, that is present in project directory
                File.AppendAllText("../../../output_boundary_revised.txt",
                    "Test_ValidateComment_CommentMsgProperty_Empty=" + res + "\n");

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return res;
        }
    }
}
