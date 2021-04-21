using Xunit;
using YouLookGoodInPrint.Shared;

namespace YouLookGoodInPrint.Tests.Shared
{
    public class HashGenTests
    {
        [Fact]
        public void TestCorrectHash1()
        {
            string password = "!ab23&bhg@#";
            string hash = password.GetHash();
            Assert.Equal("8d7dc63731bc9f582aea9e265edd50d3907350919d705a52de3c628371634271", hash);
        }

        [Fact]
        public void TestCorrectHash2()
        {
            string password = "wupTuzyMeTFMf6XXPCu2uZJgehVJMtj6XBnynUWJQFvE5HY5v4fjcm3y9P7LsjsZETZtgnsWTM9MqTF4AMXL7Z3WHcSDyh3XNHBj";
            string hash = password.GetHash();
            Assert.Equal("4461cd4e710ed23a14f2a851fc22c2220be95459b740bae7410aeba1718b4fb2", hash);
        }

        [Fact]
        public void TestDistinctHashes2()
        {
            string password1 = "deeEYA8s3SGRCK6C8UVyjjksXmt8yP";
            string password2 = "5MNUVmUJ25gnt3EfUKVrkKR";

            string hash1 = password1.GetHash();
            string hash2 = password2.GetHash();

            Assert.NotEqual(hash1, hash2);
        }
    }
}
