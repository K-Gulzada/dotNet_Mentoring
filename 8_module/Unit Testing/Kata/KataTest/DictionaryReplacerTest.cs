using Kata;
using NUnit.Framework;

namespace KataTest
{
    [TestFixture]
    public class DictionaryReplacerTest
    {
        [TestCaseSource(nameof(GetDictionaryEmpty))]
        [TestCaseSource(nameof(GetDictionaryCountOne))]
        [TestCaseSource(nameof(GetDictionaryCountTwo))]
        public void ReplaceWordsCorrespondingValue_Returns_Replaced_Words(string input, Dictionary<string, string> dict, string expected)
        {
            var dictionaryReplacer = new DictionaryReplacer();
            var actual = dictionaryReplacer.ReplaceWordsCorrespondingValue(input, dict);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReplaceWordsCorrespondingValue_Throws_ArgumentNullException()
        {
            var dictionaryReplacer = new DictionaryReplacer();
            var dict = new Dictionary<string, string>();
            Assert.That(() => dictionaryReplacer.ReplaceWordsCorrespondingValue(null, dict), Throws.ArgumentNullException);
            Assert.That(() => dictionaryReplacer.ReplaceWordsCorrespondingValue("", null), Throws.ArgumentNullException);
        }

        private static IEnumerable<object[]> GetDictionaryEmpty()
        {
            var dict = new Dictionary<string, string>();
            return new[] { new object[] { "", dict, "" }, };
        }

        private static IEnumerable<object[]> GetDictionaryCountOne()
        {
            var dict = new Dictionary<string, string> { ["temp"] = "temporary" };
            return new[] { new object[] { "$temp$", dict, "temporary" }, };
        }

        private static IEnumerable<object[]> GetDictionaryCountTwo()
        {
            var dict = new Dictionary<string, string>
            {
                ["temp"] = "temporary",
                ["name"] = "John Doe"
            };
            return new[] { new object[] { "$temp$ here comes the name $name$", dict, "temporary here comes the name John Doe" }, };
        }
    }
}
