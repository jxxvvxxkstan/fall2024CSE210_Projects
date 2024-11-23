public class Scripture
{
    // Attributes
    private Reference _reference;
    private List<Word> _words;

    // Constructor
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    // Method to hide random words
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int hiddenCount = 0;

        while (hiddenCount < numberToHide)
        {
            int index = random.Next(_words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }
        }
    }

    // Method to reveal random words
    public void RevealWords(int numberToReveal)
    {
        Random random = new Random();
        int revealedCount = 0;

        while (revealedCount < numberToReveal)
        {
            int index = random.Next(_words.Count);
            if (_words[index].IsHidden())
            {
                _words[index].Reveal();
                revealedCount++;
            }
        }
    }

    // Method to get display text
    public string GetDisplayText()
    {
        return $"{_reference.GetDisplayText()} {string.Join(" ", _words.Select(word => word.GetDisplayText()))}";
    }

    // Method to check if all words are hidden
    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}