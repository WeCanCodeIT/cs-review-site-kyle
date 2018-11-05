using NSubstitute;
using ReviewsSite.Controllers;
using ReviewsSite.Models;
using Xunit;

namespace ReviewsSite.Tests
{
    public class TagsControllerTests
    {
        [Fact]
        public void Details_Displays_Reviews_Related_To_Tag()
        {
            var tagId = 1;
            var expectedModel = new Tag();
            var tagRepo = Substitute.For<ITagRepository>();
            tagRepo.GetById(tagId).Returns(expectedModel);
            var underTest = new TagsController(tagRepo);

            var result = underTest.Details(tagId);
            var model = result.Model;

            Assert.Same(expectedModel, model);
        }
    }
}
