using Xunit;

namespace ReviewsSite.Tests
{
    public class ReviewRepositoryTests
    {
        [Fact]
        public void GetAll_Returns_3_Reviews()
        {
            var underTest = new ReviewRepository();

            var result = underTest.GetAll();

            Assert.Equal(3, result.Count);
        }
        
        [Fact]
        public void FindById_Returns_Correct_Review()
        {
            var underTest = new ReviewRepository();

            var result = underTest.FindById(1);

            Assert.Equal(1, result.Id);
            Assert.Equal("Spiderman", result.Title);
        }
    }
}
