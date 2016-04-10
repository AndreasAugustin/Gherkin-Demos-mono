

namespace csharp
{
    using TechTalk.SpecFlow;
    using FluentAssertions;
    using System.Linq;

    [Binding]
    public class SoundexAlgorithmSteps
    {
        private Soundex _soundex;
        private string _encoded;

        [Given(@"A soundex instance")]
        public void GivenASoundexInstance()
        {
            _soundex = new Soundex();
        }
        
        [When(@"I enter a word as ""(.*)""")]
        public void WhenIEnterAWordAs(string word)
        {
            _encoded = _soundex.Encode(word);
        }
        
        [When(@"I enter the word ""(.*)""")]
        public void WhenIEnterTheWord(string word)
        {
            _encoded = _soundex.Encode(word);
        }
        
        [When(@"I enter the lower case word ""(.*)""")]
        public void WhenIEnterTheLowerCaseWord(string word)
        {
            _encoded = _soundex.Encode(word);
        }
        
        [When(@"I enter the character ""(.*)""")]
        public void WhenIEnterTheCharacter(string character)
        {
            _encoded = _soundex.EncodedDigit(character.First());
        }
        
        [When(@"I enter the string ""(.*)""")]
        public void WhenIEnterTheString(string word)
        {
            _encoded = _soundex.Encode(word);
        }
        
        [Then(@"it is encoded to ""(.*)""")]
        public void ThenItIsEncodedTo(string encoded)
        {
            _encoded.Should().Be(encoded);
        }
        
        [Then(@"the encoded length is equal to ""(.*)""")]
        public void ThenTheEncodedLengthIsEqualTo(int length)
        {
            _encoded.Should().HaveLength(length);
        }
        
        [Then(@"the encoded first letter is equal to ""(.*)""")]
        public void ThenTheEncodedFirstLetterIsEqualTo(string firstLetter)
        {
            _encoded.Should().StartWith(firstLetter);
        }
        
        [Then(@"it is equal to other encoded character ""(.*)""")]
        public void ThenItIsEqualToOtherEncodedCharacter(string otherCharacter)
        {
            _encoded.Should().Be(_soundex.EncodedDigit(otherCharacter.First()));
        }
        
        [Then(@"it is equal to other encoded string ""(.*)""")]
        public void ThenItIsEqualToOtherEncodedString(string otherString)
        {
            _encoded.Should().Be(_soundex.Encode(otherString));
        }
    }
}
